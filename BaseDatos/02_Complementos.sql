-- =====================================================================
-- Objetos que usa la aplicación y que no estaban en 01_BDSistema_Ventas.sql
-- Ejecutar después de 01_BDSistema_Ventas.sql
-- =====================================================================
USE [BDSistema_Ventas]
GO

-- ---------------------------------------------------------------------
-- Tabla de permisos por rol (la usa CD_Permiso para armar el menú)
-- ---------------------------------------------------------------------
CREATE TABLE [dbo].[ROL_PERMISO](
	[Id_rol] [int] NOT NULL REFERENCES [dbo].[ROL] ([IdRol]),
	[Id_permiso] [int] NOT NULL REFERENCES [dbo].[PERMISO] ([IdPermiso]),
	PRIMARY KEY ([Id_rol], [Id_permiso])
)
GO

-- ---------------------------------------------------------------------
-- Tipos tabla para el detalle de venta y de compra
-- ---------------------------------------------------------------------
CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
	[IdProducto] [int] NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[Subtotal] [decimal](10, 2) NULL
)
GO

CREATE TYPE [dbo].[EDetalle_Compra] AS TABLE(
	[IdProducto] [int] NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL
)
GO

-- ---------------------------------------------------------------------
-- Registrar venta: cabecera, detalle y descuento de stock
-- ---------------------------------------------------------------------
CREATE PROC [dbo].[usp_RegistrarVenta](
	@IdUsuario int,
	@TipoDocumento varchar(500),
	@NumeroDocumento varchar(500),
	@DocumentoCliente varchar(500),
	@NombreCliente varchar(500),
	@MontoPago decimal(18, 2),
	@MontoCambio decimal(18, 2),
	@MontoTotal decimal(18, 2),
	@DetalleVenta [EDetalle_Venta] READONLY,
	@Resultado bit output,
	@Mensaje varchar(500) output
)
as
begin
	begin try
		declare @idventa int = 0
		set @Resultado = 1
		set @Mensaje = ''

		if exists (select 1 from @DetalleVenta dv
				   inner join PRODUCTO p on p.IdProducto = dv.IdProducto
				   where p.Stock < dv.Cantidad)
		begin
			set @Resultado = 0
			set @Mensaje = 'Stock insuficiente para uno o más productos'
			return
		end

		begin transaction registro

		insert into VENTA (IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal)
		values (@IdUsuario, @TipoDocumento, @NumeroDocumento, @DocumentoCliente, @NombreCliente, @MontoPago, @MontoCambio, @MontoTotal)

		set @idventa = SCOPE_IDENTITY()

		insert into DETALLE_VENTA (IdVenta, IdProducto, PrecioVenta, Cantidad, Subtotal)
		select @idventa, IdProducto, PrecioVenta, Cantidad, Subtotal from @DetalleVenta

		update p set p.Stock = p.Stock - dv.Cantidad
		from PRODUCTO p
		inner join @DetalleVenta dv on dv.IdProducto = p.IdProducto

		commit transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		if @@TRANCOUNT > 0 rollback transaction
	end catch
end
GO

-- ---------------------------------------------------------------------
-- Registrar compra: cabecera, detalle, suma de stock y actualización de precios
-- ---------------------------------------------------------------------
CREATE PROC [dbo].[SP_RegistrarCompra](
	@IdUsuario int,
	@IdProveedor int,
	@TipoDocumento varchar(500),
	@NumeroDocumento varchar(500),
	@MontoTotal decimal(18, 2),
	@DetalleCompra [EDetalle_Compra] READONLY,
	@Resultado int output,
	@Mensaje varchar(500) output
)
as
begin
	begin try
		declare @idcompra int = 0
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro

		insert into COMPRA (IdUsuario, IdProveedor, TipoDocumento, NumeroDocumento, MontoTotal)
		values (@IdUsuario, @IdProveedor, @TipoDocumento, @NumeroDocumento, @MontoTotal)

		set @idcompra = SCOPE_IDENTITY()

		insert into DETALLE_COMPRA (IdCompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal)
		select @idcompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal from @DetalleCompra

		update p set p.Stock = p.Stock + dc.Cantidad,
					 p.PrecioCompra = dc.PrecioCompra,
					 p.PrecioVenta = dc.PrecioVenta
		from PRODUCTO p
		inner join @DetalleCompra dc on dc.IdProducto = p.IdProducto

		commit transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		if @@TRANCOUNT > 0 rollback transaction
	end catch
end
GO

-- ---------------------------------------------------------------------
-- Eliminar cliente
-- ---------------------------------------------------------------------
CREATE PROC [dbo].[SP_EliminarCliente](
	@IdCliente int,
	@Respuesta bit output,
	@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''

	delete from CLIENTE where IdCliente = @IdCliente
	set @Respuesta = 1
end
GO

-- ---------------------------------------------------------------------
-- Cambios de bd/correcionesnuevas.sql (sin borrar la columna Stock)
-- ---------------------------------------------------------------------
ALTER TABLE VENTA ADD IdCliente int NULL
GO
ALTER TABLE VENTA ADD CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente)
GO

CREATE TABLE MOVIMIENTO_STOCK (
	IdMovimiento int PRIMARY KEY IDENTITY(1,1),
	IdProducto int NOT NULL,
	Fecha datetime DEFAULT getdate(),
	Tipo varchar(10) NOT NULL, -- 'INGRESO' o 'EGRESO'
	Cantidad int NOT NULL,
	CONSTRAINT FK_Movimiento_Producto FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto)
)
GO

-- ---------------------------------------------------------------------
-- Datos iniciales (tomados de los scripts de la carpeta bd)
-- ---------------------------------------------------------------------
insert into ROL (Descripcion) values ('ADMINISTRADOR'), ('EMPLEADO')
GO

insert into USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado) values
('121314', 'ADMIN', 'german@gmail.com', '123', 1, 1),
('151617', 'EMPLEAD0', 'empleado@gmail.com', '456', 2, 1)
GO

-- Un permiso por menú del formulario Inicio (NombreMenu = Name del control)
insert into PERMISO (IdRol, NombreMenu) values
(1, 'menuusuarios'),
(1, 'menumantenimiento'),
(1, 'menuventas'),
(1, 'menucompras'),
(1, 'menuclientes'),
(1, 'menuproveedores'),
(1, 'menureportes'),
(1, 'menuacercade'),
(2, 'menuventas'),
(2, 'menucompras'),
(2, 'menuclientes'),
(2, 'menuproveedores'),
(2, 'menuacercade')
GO

-- CD_Permiso lee los menús desde ROL_PERMISO
insert into ROL_PERMISO (Id_rol, Id_permiso)
select IdRol, IdPermiso from PERMISO
GO

insert into NEGOCIO (IdNegocio, Nombre, RUC, Direccion) values
(1, 'Sistema De Ventas C#', '101010', 'avenida.tucuman123')
GO

insert into CATEGORIA (Descripcion, Estado) values ('Lacteos', 1), ('Embutidos', 1), ('Enlatados', 1)
GO

INSERT INTO CLIENTE (Documento, NombreCompleto, Correo, Telefono, Estado) VALUES
('28111222', 'Carlos Alberto Ruiz', 'cruiz@gmail.com', '1145678901', 1),
('31333444', 'Patricia Noemí Torres', 'ptorres@gmail.com', '1156789012', 1),
('34555666', 'Gabriel Eduardo Romero', 'gromero@hotmail.com', '1167890123', 1),
('30777888', 'Valeria Inés Benítez', 'vbenitez@yahoo.com', '1178901234', 1),
('33999000', 'Fernando Gabriel Acosta', 'facosta@gmail.com', '1189012345', 1),
('29123987', 'Camila Belén Medina', 'cmedina@outlook.com', '1190123456', 1),
('32456789', 'Hugo Marcelo Castro', 'hcastro@gmail.com', '1123456789', 1)
GO

INSERT INTO PROVEEDOR (Documento, RazonSocial, Correo, Telefono, Estado) VALUES
('30711223344', 'Distribuidora Global S.A.', 'contacto@distribuidoraglobal.com', '08101112233', 1),
('30822334455', 'Logística y Mayorista Norte SRL', 'ventas@logisticanorte.com', '01143219876', 1),
('30933445566', 'Importadora del Plata S.A.', 'info@importadoradelplata.com', '01154328765', 1),
('30144556677', 'Comercializadora Centro SRL', 'contacto@comercialcentrosrl.com', '01165437654', 1),
('30255667788', 'Insumos Industriales Sur S.A.', 'ventas@insumossur.com', '01176546543', 1),
('30366778899', 'TecnoProveedores Argentina SRL', 'soporte@tecnoproveedores.com', '01187655432', 1),
('30477889900', 'Abastecedora Nacional S.A.', 'info@abastecedoranacional.com', '01198764321', 1)
GO
