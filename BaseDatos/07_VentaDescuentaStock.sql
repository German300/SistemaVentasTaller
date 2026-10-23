-- =====================================================================
-- Deja usp_RegistrarVenta en su versión definitiva.
-- Hace falta si la base se creó con los scripts viejos (carpeta bd),
-- donde el SP no descontaba el stock. Desde ahora el stock lo descuenta SOLO el SP;
-- la aplicación (CD_Venta.Registrar) ya no lo toca.
-- Ejecutar después de 06_BajaLogicaGeneral.sql. Se puede ejecutar más de una vez.
-- =====================================================================
USE [BDSistema_Ventas]
GO

CREATE OR ALTER PROC [dbo].[usp_RegistrarVenta](
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
