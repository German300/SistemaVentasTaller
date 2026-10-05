/* ----------- PROCEDIMIENTOS PARA CATEGORIA -----------*/

--PROCEDIMIENTO PARA GUARDAR CATEGORIA
create PROC SP_RegistrarCategoria(
@Descripcion varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
	begin
		insert into CATEGORIA(Descripcion,Estado) values (@Descripcion,@Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
	set @Mensaje = 'No se puede repetir la descripcion de una categoria'
end



go

--PROCEDIMIENTO PARA MODIFICAR CATEGORIA
create procedure sp_EditarCategoria(
@IdCategoria int,
@Descripcion varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    SET @Resultado = 1
    IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion and IdCategoria != @IdCategoria)
    begin
        update CATEGORIA set
        Descripcion = @Descripcion,
        Estado = @Estado

        where IdCategoria = @IdCategoria
    end
    ELSE
    begin
        SET @Resultado = 0
        set @Mensaje = 'No se puede repetir la descripcion de una categoria'
    end

end


go

--PROCEDIMIENTO PARA ELIMINAR CATEGORIA
create procedure sp_EliminarCategoria(
@IdCategoria int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    SET @Resultado = 1
    IF NOT EXISTS (
        select * from CATEGORIA c
        inner join PRODUCTO p on p.IdCategoria = c.IdCategoria
        where c.IdCategoria = @IdCategoria
    )
    begin
        delete top(1) from CATEGORIA where IdCategoria = @IdCategoria
    end
    ELSE
    begin
        SET @Resultado = 0
        set @Mensaje = 'La categoria se encuentara relacionada a un producto'
    end

end










