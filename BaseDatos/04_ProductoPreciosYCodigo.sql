-- =====================================================================
-- Producto: precios de compra/venta y cantidad inicial al registrar,
-- y código generado automáticamente (P00001, P00002, ...)
-- Ejecutar después de 02_Complementos.sql
-- =====================================================================
USE [BDSistema_Ventas]
GO

ALTER PROC [dbo].[sp_RegistrarProducto](
	@Nombre varchar(50),
	@Descripcion varchar(50),
	@IdCategoria int,
	@PrecioCompra decimal(10, 2),
	@PrecioVenta decimal(10, 2),
	@Stock int,
	@Estado bit,
	@Resultado int output,
	@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 0
	set @Mensaje = ''

	begin try
		begin transaction

		insert into PRODUCTO (Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta, Estado)
		values (@Nombre, @Descripcion, @IdCategoria, @Stock, @PrecioCompra, @PrecioVenta, @Estado)

		set @Resultado = SCOPE_IDENTITY()

		-- El código se arma con el Id, así nunca se repite
		update PRODUCTO set Codigo = 'P' + RIGHT('00000' + CAST(@Resultado as varchar(10)), 5)
		where IdProducto = @Resultado

		-- La cantidad inicial queda registrada como ingreso de stock
		if @Stock > 0
			insert into MOVIMIENTO_STOCK (IdProducto, Tipo, Cantidad) values (@Resultado, 'INGRESO', @Stock)

		commit transaction
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback transaction
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
	end catch
end
GO

ALTER PROC [dbo].[sp_ModificarProducto](
	@IdProducto int,
	@Nombre varchar(50),
	@Descripcion varchar(50),
	@IdCategoria int,
	@PrecioCompra decimal(10, 2),
	@PrecioVenta decimal(10, 2),
	@Estado bit,
	@Resultado bit output,
	@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	set @Mensaje = ''

	update PRODUCTO set
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdCategoria = @IdCategoria,
		PrecioCompra = @PrecioCompra,
		PrecioVenta = @PrecioVenta,
		Estado = @Estado
	where IdProducto = @IdProducto
end
GO

-- Productos que hayan quedado sin código
update PRODUCTO set Codigo = 'P' + RIGHT('00000' + CAST(IdProducto as varchar(10)), 5)
where Codigo is null or LTRIM(RTRIM(Codigo)) = ''
GO
