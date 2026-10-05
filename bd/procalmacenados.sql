use BDSistema_Ventas


update USUARIO set estado = 0 where IdUsuario = 2



ALTER PROC SP_REGISTRARUSUARIO(
    @Documento varchar(50),
    @NombreCompleto varchar(100),
    @Correo varchar (100),
    @Clave varchar(100),
    @IdRol int,
    @Estado bit,
    @IdUsuarioResultado int output,
    @Mensaje varchar (500) output
)
as
begin
    set @IdUsuarioResultado = 0
    set @Mensaje = ''
    
    if not exists (select * from USUARIO where Documento = @Documento)
    begin
        -- AGREGAMOS 'Correo' en las columnas y '@Correo' en los values
        insert into USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado) 
        values (@Documento, @NombreCompleto, @Correo, @Clave, @IdRol, @Estado)
        
        set @IdUsuarioResultado = SCOPE_IDENTITY()
    end
    else
    begin
        set @Mensaje = 'No se puede repetir el mismo documento para más de un usuario'
    end
end








create proc SP_EDITARUSUARIO(
@IdUsuario int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar (100),
@Clave varchar(100),
@IdRol int,
@Estado bit,
@Respuesta bit output,
@Mensaje varchar (500) output
)
as
begin
set @Respuesta = 0
set @Mensaje = ''

if not exists ( select * from USUARIO where Documento = @Documento and idusuario != @IdUsuario)
begin
update USUARIO set 
Documento = @Documento,
NombreCompleto = @NombreCompleto,
Clave = @Clave,
IdRol = @IdRol,
Estado = @Estado

where IdUsuario = @IdUsuario

set @Respuesta = 1
 


end
else
 set @Mensaje = 'No se puede repetir el mismo documento para más de un usuario'

end




declare @idusuariogenerado int
declare @mensaje varchar(500)

exec SP_REGISTRARUSUARIO '987', 'pruebas', 'test@gmail.com','456',2,1,@idusuariogenerado output,@mensaje output

select @idusuariogenerado
select @mensaje


update USUARIO set Correo = 'teste@gmail.com' where IdUsuario =3;

select * from USUARIO





ALTER PROC SP_ELIMINARUSUARIO(
    @IdUsuario int,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''

    BEGIN TRY
        -- Ya no nos importan los IF EXISTS de compras o ventas, 
        -- porque el UPDATE no rompe ninguna clave foránea (FK).
        UPDATE USUARIO 
        SET Estado = 0 
        WHERE IdUsuario = @IdUsuario;

        SET @Respuesta = 1
        SET @Mensaje = 'Usuario dado de baja correctamente (Inactivo).'
    END TRY
    BEGIN CATCH
        SET @Respuesta = 0
        SET @Mensaje = 'Error al dar de baja al usuario: ' + ERROR_MESSAGE()
    END CATCH
END





ALTER PROC SP_EDITARUSUARIO(
    @IdUsuario int,
    @Documento varchar(50),
    @NombreCompleto varchar(100),
    @Correo varchar (100),
    @Clave varchar(100),
    @IdRol int,
    @Estado bit,
    @Respuesta bit output,
    @Mensaje varchar (500) output
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''

    IF NOT EXISTS (SELECT * FROM USUARIO WHERE Documento = @Documento AND IdUsuario != @IdUsuario)
    BEGIN
        UPDATE USUARIO SET 
            Documento = @Documento,
            NombreCompleto = @NombreCompleto,
            Correo = @Correo, -- <-- ¡Faltaba esta línea importante!
            Clave = @Clave,
            IdRol = @IdRol,
            Estado = @Estado
        WHERE IdUsuario = @IdUsuario;

        SET @Respuesta = 1
    END
    ELSE
    BEGIN
        SET @Mensaje = 'No se puede repetir el mismo documento para más de un usuario'
    END
END
