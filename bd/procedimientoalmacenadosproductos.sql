CREATE PROC sp_RegistrarProducto(
    @Codigo varchar(20),
    @Nombre varchar(30),
    @Descripcion varchar(30),
    @IdCategoria int,
    @Estado bit,
    @Resultado int output,
    @Mensaje varchar(500) output
)
as
begin
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM producto WHERE Codigo = @Codigo)
    begin
        INSERT INTO producto(Codigo, Nombre, Descripcion, IdCategoria, Estado) 
        values (@Codigo, @Nombre, @Descripcion, @IdCategoria, @Estado)
        
        SET @Resultado = SCOPE_IDENTITY()
    end
    ELSE
    begin
        SET @Mensaje = 'Ya existe un producto con el mismo codigo'
    end
end
GO






CREATE PROC sp_ModificarProducto(
    @IdProducto int,
    @Codigo varchar(20),
    @Nombre varchar(30),
    @Descripcion varchar(30),
    @IdCategoria int,
    @Estado bit,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
as
begin
    SET @Resultado = 1
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE codigo = @Codigo and IdProducto != @IdProducto)
    begin
        update PRODUCTO set
            codigo = @Codigo,
            Nombre = @Nombre,
            Descripcion = @Descripcion,
            IdCategoria = @IdCategoria,
            Estado = @Estado
        where IdProducto = @IdProducto
    end
    ELSE
    begin
        SET @Resultado = 0
        SET @Mensaje = 'Ya existe un producto con el mismo codigo'
    end
end
GO



CREATE PROC SP_EliminarProducto(
    @IdProducto int,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
as
begin
    -- inicio las variables y no se puede borrar hasta que se demuestre lo contrario
    set @Respuesta = 0
    set @Mensaje = ''
    declare @pasoreglas bit = 1 -- pongo esta bandera para ver si el producto se puede boorrare

    /*  INTEGRIDAD CON COMPRAS
       No puedo borrar un producto que ya fue comprado, porque dejaríamos 
       los registros de la tabla 'DETALLE_COMPRA' huérfanos (sin saber qué producto se compró).
    */
    IF EXISTS (SELECT * FROM DETALLE_COMPRA dc
        INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto
        WHERE p.IdProducto = @IdProducto
    )
    BEGIN
        set @pasoreglas = 0
        set @Respuesta = 0
        set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una COMPRA' 
    END

    /* INTEGRIDAD CON VENTAS
       Si el producto ya se vendió, debe 
       permanecer en la base de datos para no romper el historial de ventas.
    */
    IF EXISTS (SELECT * FROM DETALLE_VENTA dv
        INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
        WHERE p.IdProducto = @IdProducto
    )
    BEGIN
        set @pasoreglas = 0
        set @Respuesta = 0
        set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una VENTA' + CHAR(13)
    END

    /* FINAL DE TRODO               
       Si después de los chequeos anteriores '@pasoreglas' sigue siendo 1, 
       significa que el producto está libre de relaciones y se puede borrar físicamente.
    */
    IF (@pasoreglas = 1)
    BEGIN
        DELETE FROM PRODUCTO WHERE IdProducto = @IdProducto
        set @Respuesta = 1
    END
end

select IdProducto,Codigo,Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioVenta,p.Estado from PRODUCTO p
inner join CATEGORIA c on c.IdCategoria = p.IdCategoria