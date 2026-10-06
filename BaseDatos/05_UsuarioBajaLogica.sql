USE BDSistema_Ventas
GO

-- Dar de baja un usuario: no se borra, se marca como inactivo (Estado = 0).
-- No permite dejar el sistema sin ningún administrador activo.
ALTER PROC [dbo].[SP_ELIMINARUSUARIO](
    @IdUsuario int,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''

    IF EXISTS (SELECT 1 FROM USUARIO WHERE IdUsuario = @IdUsuario AND IdRol = 1 AND Estado = 1)
       AND (SELECT COUNT(*) FROM USUARIO WHERE IdRol = 1 AND Estado = 1) <= 1
    BEGIN
        SET @Mensaje = 'No se puede dar de baja al único administrador activo'
        RETURN
    END

    BEGIN TRY
        UPDATE USUARIO SET Estado = 0 WHERE IdUsuario = @IdUsuario

        SET @Respuesta = 1
        SET @Mensaje = 'Usuario dado de baja correctamente'
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'Error al dar de baja al usuario: ' + ERROR_MESSAGE()
    END CATCH
END
GO
