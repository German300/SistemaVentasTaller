USE [BDSistema_Ventas]
GO

-- 1. ELIMINAR EL PROCEDIMIENTO SI YA EXISTE
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_RegistrarVenta]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[usp_RegistrarVenta]
GO

-- 2. ELIMINAR EL TIPO DE TABLA SI YA EXISTE
IF EXISTS (SELECT * FROM sys.types WHERE name = 'EDetalle_Venta')
    DROP TYPE [dbo].[EDetalle_Venta]
GO

-- 3. CREAR EL TIPO DE TABLA PERSONALIZADO
CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
    [IdProducto] int NULL,
    [PrecioVenta] decimal(10,2) NULL,
    [Cantidad] int NULL,
    [Subtotal] decimal(10,2) NULL
)
GO

-- 4. CREAR EL PROCEDIMIENTO ALMACENADO QUE REGISTRA Y DECUENTA STOCK
CREATE PROCEDURE [dbo].[usp_RegistrarVenta](
    @IdUsuario int,
    @TipoDocumento varchar(50),
    @NumeroDocumento varchar(50),
    @DocumentoCliente varchar(50),
    @NombreCliente varchar(100),
    @MontoPago decimal(10,2),
    @MontoCambio decimal(10,2),
    @MontoTotal decimal(10,2),
    @DetalleVenta [EDetalle_Venta] READONLY,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    BEGIN TRY
        DECLARE @idventa int = 0
        SET @Resultado = 1
        SET @Mensaje = ''

        BEGIN TRANSACTION registro

        -- A. Insertar Encabezado de Venta
        INSERT INTO VENTA(IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal)
        VALUES(@IdUsuario, @TipoDocumento, @NumeroDocumento, @DocumentoCliente, @NombreCliente, @MontoPago, @MontoCambio, @MontoTotal)

        SET @idventa = SCOPE_IDENTITY()

        -- B. Insertar Detalle de Venta
        INSERT INTO DETALLE_VENTA(IdVenta, IdProducto, PrecioVenta, Cantidad, Subtotal)
        SELECT @idventa, IdProducto, PrecioVenta, Cantidad, Subtotal 
        FROM @DetalleVenta

        -- C. RESTAR EL STOCK EN LA TABLA PRODUCTO
        UPDATE p
        SET p.Stock = p.Stock - dv.Cantidad
        FROM PRODUCTO p
        INNER JOIN @DetalleVenta dv ON dv.IdProducto = p.IdProducto

        COMMIT TRANSACTION registro

    END TRY
    BEGIN CATCH
        SET @Resultado = 0
        SET @Mensaje = ERROR_MESSAGE()
        ROLLBACK TRANSACTION registro
    END CATCH
END
GO