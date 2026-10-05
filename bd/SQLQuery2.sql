

use BDSistema_Ventas

USE BDSistema_Ventas
GO

-- 5. Tabla USUARIO
CREATE TABLE USUARIO(
    IdUsuario int primary key identity,
    Documento varchar(50),
    NombreCompleto varchar(50),
    Correo varchar(50),
    Clave varchar(50),
    IdRol int references ROL (IdRol),
    Estado bit,
    FechaRegistro datetime default getdate()
)
GO

-- 6. Tabla CATEGORIA
CREATE TABLE CATEGORIA(
    IdCategoria int primary key identity,
    Descripcion varchar(100),
    Estado bit,
    FechaRegistro datetime default getdate()
)
GO

-- 7. Tabla PRODUCTO
CREATE TABLE PRODUCTO(
    IdProducto int primary key identity,
    IdCategoria int references CATEGORIA (IdCategoria),
    Codigo varchar(50),
    Nombre varchar(50),
    Descripcion varchar(50),
    Stock int not null default 0,
    PrecioCompra decimal(10,2) default 0,
    PrecioVenta decimal(10,2) default 0,
    Estado bit,
    FechaRegistro datetime default getdate()
)
GO

-- 8. Tabla COMPRA
CREATE TABLE COMPRA(
    IdCompra int primary key identity,
    IdUsuario int references USUARIO(IdUsuario),
    IdProveedor int references PROVEEDOR(IdPROVEEDOR), -- Corregido nombre de columna de referencia
    TipoDocumento varchar(50),
    NumeroDocumento varchar(50),
    MontoTotal decimal(10,2),
    FechaRegistro datetime default getdate()
)
GO

-- 9. Tabla DETALLE_COMPRA
CREATE TABLE DETALLE_COMPRA(
    IdDetalleCompra int primary key identity,
    IdCompra int references COMPRA (IdCompra),
    IdProducto int references PRODUCTO (IdProducto),
    PrecioCompra decimal(10,2) default 0,
    PrecioVenta decimal(10,2) default 0,
    Cantidad int,
    MontoTotal decimal(10,2),
    FechaRegistro datetime default getdate()
)
GO

-- 10. Tabla VENTA
CREATE TABLE VENTA(
    IdVenta int primary key identity,
    IdUsuario int references USUARIO(IdUsuario),
    TipoDocumento varchar(50),
    NumeroDocumento varchar(50),
    DocumentoCliente varchar(50),
    NombreCliente varchar(100),
    MontoPago decimal(10,2),
    MontoCambio decimal(10,2),
    MontoTotal decimal(10,2),
    FechaRegistro datetime default getdate()
)
GO

-- 11. Tabla DETALLE_VENTA
CREATE TABLE DETALLE_VENTA(
    IdDetalleVenta int primary key identity,
    IdVenta int references VENTA (IdVenta),
    IdProducto int references PRODUCTO (IdProducto),
    PrecioVenta decimal(10,2),
    Cantidad int,
    Subtotal decimal(10,2),
    FechaRegistro datetime default getdate()
)
GO

