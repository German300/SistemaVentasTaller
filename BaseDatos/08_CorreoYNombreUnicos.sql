USE BDSistema_Ventas
GO

-- No se puede repetir el correo en USUARIO, CLIENTE ni PROVEEDOR,
-- ni el nombre en PRODUCTO. Si se repite, el SP devuelve el mensaje
-- y el formulario lo muestra (no se guarda nada).

-- USUARIO: el correo es opcional, solo se controla si viene cargado
ALTER PROC [dbo].[SP_REGISTRARUSUARIO](
    @Documento varchar(50),
    @NombreCompleto varchar(100),
    @Correo varchar(100),
    @Clave varchar(100),
    @IdRol int,
    @Estado bit,
    @IdUsuarioResultado int output,
    @Mensaje varchar(500) output
)
as
begin
    set @IdUsuarioResultado = 0
    set @Mensaje = ''

    if exists (select * from USUARIO where Documento = @Documento)
        set @Mensaje = 'No se puede repetir el mismo documento para más de un usuario'
    else if @Correo <> '' and exists (select * from USUARIO where Correo = @Correo)
        set @Mensaje = 'Ya existe un usuario con ese correo'
    else
    begin
        insert into USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado)
        values (@Documento, @NombreCompleto, @Correo, @Clave, @IdRol, @Estado)
        set @IdUsuarioResultado = SCOPE_IDENTITY()
    end
end
GO

-- además ahora guarda el correo (antes el UPDATE no lo incluía)
ALTER PROC [dbo].[SP_EDITARUSUARIO](
    @IdUsuario int,
    @Documento varchar(50),
    @NombreCompleto varchar(100),
    @Correo varchar(100),
    @Clave varchar(100),
    @IdRol int,
    @Estado bit,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
as
begin
    set @Respuesta = 0
    set @Mensaje = ''

    if exists (select * from USUARIO where Documento = @Documento and IdUsuario != @IdUsuario)
        set @Mensaje = 'No se puede repetir el mismo documento para más de un usuario'
    else if @Correo <> '' and exists (select * from USUARIO where Correo = @Correo and IdUsuario != @IdUsuario)
        set @Mensaje = 'Ya existe un usuario con ese correo'
    else
    begin
        update USUARIO set
            Documento = @Documento,
            NombreCompleto = @NombreCompleto,
            Correo = @Correo,
            Clave = @Clave,
            IdRol = @IdRol,
            Estado = @Estado
        where IdUsuario = @IdUsuario
        set @Respuesta = 1
    end
end
GO

-- CLIENTE
ALTER PROC [dbo].[sp_RegistrarCliente](
    @Documento varchar(50),
    @NombreCompleto varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado int output,
    @Mensaje varchar(500) output
)
as
begin
    set @Resultado = 0
    set @Mensaje = ''

    if exists (select * from CLIENTE where Documento = @Documento)
        set @Mensaje = 'El numero de documento ya existe'
    else if exists (select * from CLIENTE where Correo = @Correo)
        set @Mensaje = 'Ya existe un cliente con ese correo'
    else
    begin
        insert into CLIENTE (Documento, NombreCompleto, Correo, Telefono, Estado)
        values (@Documento, @NombreCompleto, @Correo, @Telefono, @Estado)
        set @Resultado = SCOPE_IDENTITY()
    end
end
GO

ALTER PROC [dbo].[sp_ModificarCliente](
    @IdCliente int,
    @Documento varchar(50),
    @NombreCompleto varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
as
begin
    set @Resultado = 0
    set @Mensaje = ''

    if exists (select * from CLIENTE where Documento = @Documento and IdCliente != @IdCliente)
        set @Mensaje = 'El numero de documento ya existe'
    else if exists (select * from CLIENTE where Correo = @Correo and IdCliente != @IdCliente)
        set @Mensaje = 'Ya existe un cliente con ese correo'
    else
    begin
        update CLIENTE set
            Documento = @Documento,
            NombreCompleto = @NombreCompleto,
            Correo = @Correo,
            Telefono = @Telefono,
            Estado = @Estado
        where IdCliente = @IdCliente
        set @Resultado = 1
    end
end
GO

-- PROVEEDOR
ALTER PROC [dbo].[sp_RegistrarProveedor](
    @Documento varchar(50),
    @RazonSocial varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado int output,
    @Mensaje varchar(500) output
)
as
begin
    set @Resultado = 0
    set @Mensaje = ''

    if exists (select * from PROVEEDOR where Documento = @Documento)
        set @Mensaje = 'El numero de documento ya existe'
    else if exists (select * from PROVEEDOR where Correo = @Correo)
        set @Mensaje = 'Ya existe un proveedor con ese correo'
    else
    begin
        insert into PROVEEDOR (Documento, RazonSocial, Correo, Telefono, Estado)
        values (@Documento, @RazonSocial, @Correo, @Telefono, @Estado)
        set @Resultado = SCOPE_IDENTITY()
    end
end
GO

ALTER PROC [dbo].[sp_ModificarProveedor](
    @IdProveedor int,
    @Documento varchar(50),
    @RazonSocial varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
as
begin
    set @Resultado = 0
    set @Mensaje = ''

    if exists (select * from PROVEEDOR where Documento = @Documento and IdProveedor != @IdProveedor)
        set @Mensaje = 'El numero de documento ya existe'
    else if exists (select * from PROVEEDOR where Correo = @Correo and IdProveedor != @IdProveedor)
        set @Mensaje = 'Ya existe un proveedor con ese correo'
    else
    begin
        update PROVEEDOR set
            Documento = @Documento,
            RazonSocial = @RazonSocial,
            Correo = @Correo,
            Telefono = @Telefono,
            Estado = @Estado
        where IdProveedor = @IdProveedor
        set @Resultado = 1
    end
end
GO

-- PRODUCTO: no se repite el nombre
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

    if exists (select * from PRODUCTO where Nombre = @Nombre)
    begin
        set @Mensaje = 'Ya existe un producto con ese nombre'
        return
    end

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
    set @Resultado = 0
    set @Mensaje = ''

    if exists (select * from PRODUCTO where Nombre = @Nombre and IdProducto != @IdProducto)
        set @Mensaje = 'Ya existe un producto con ese nombre'
    else
    begin
        update PRODUCTO set
            Nombre = @Nombre,
            Descripcion = @Descripcion,
            IdCategoria = @IdCategoria,
            PrecioCompra = @PrecioCompra,
            PrecioVenta = @PrecioVenta,
            Estado = @Estado
        where IdProducto = @IdProducto
        set @Resultado = 1
    end
end
GO
