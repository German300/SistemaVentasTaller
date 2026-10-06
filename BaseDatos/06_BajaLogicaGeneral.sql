USE BDSistema_Ventas
GO

-- Ningún registro se borra: "eliminar" pasa a ser dar de baja (Estado = 0).
-- Se mantienen los nombres y parámetros de cada procedimiento para no tocar la capa de datos.
-- Como el registro no se borra, ya no hace falta chequear ventas/compras relacionadas:
-- el historial sigue apuntando al registro dado de baja.

ALTER PROCEDURE [dbo].[sp_EliminarCategoria](
    @IdCategoria int,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Resultado = 0
    SET @Mensaje = ''

    BEGIN TRY
        UPDATE CATEGORIA SET Estado = 0 WHERE IdCategoria = @IdCategoria
        SET @Resultado = 1
        SET @Mensaje = 'Categoría dada de baja correctamente'
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'Error al dar de baja la categoría: ' + ERROR_MESSAGE()
    END CATCH
END
GO

ALTER PROC [dbo].[SP_EliminarCliente](
    @IdCliente int,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''

    BEGIN TRY
        UPDATE CLIENTE SET Estado = 0 WHERE IdCliente = @IdCliente
        SET @Respuesta = 1
        SET @Mensaje = 'Cliente dado de baja correctamente'
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'Error al dar de baja el cliente: ' + ERROR_MESSAGE()
    END CATCH
END
GO

ALTER PROC [dbo].[SP_EliminarProducto](
    @IdProducto int,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''

    BEGIN TRY
        UPDATE PRODUCTO SET Estado = 0 WHERE IdProducto = @IdProducto
        SET @Respuesta = 1
        SET @Mensaje = 'Producto dado de baja correctamente'
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'Error al dar de baja el producto: ' + ERROR_MESSAGE()
    END CATCH
END
GO

ALTER PROCEDURE [dbo].[sp_EliminarProveedor](
    @IdProveedor int,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Resultado = 0
    SET @Mensaje = ''

    BEGIN TRY
        UPDATE PROVEEDOR SET Estado = 0 WHERE IdProveedor = @IdProveedor
        SET @Resultado = 1
        SET @Mensaje = 'Proveedor dado de baja correctamente'
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'Error al dar de baja el proveedor: ' + ERROR_MESSAGE()
    END CATCH
END
GO
