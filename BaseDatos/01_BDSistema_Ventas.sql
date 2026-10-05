USE [master]
GO
/****** Object:  Database [BDSistema_Ventas]    Script Date: 19/5/2026 10:53:48 ******/
CREATE DATABASE [BDSistema_Ventas]
GO
ALTER DATABASE [BDSistema_Ventas] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDSistema_Ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDSistema_Ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BDSistema_Ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDSistema_Ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDSistema_Ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BDSistema_Ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDSistema_Ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDSistema_Ventas] SET  MULTI_USER 
GO
ALTER DATABASE [BDSistema_Ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDSistema_Ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDSistema_Ventas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDSistema_Ventas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDSistema_Ventas] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [BDSistema_Ventas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BDSistema_Ventas] SET QUERY_STORE = ON
GO
ALTER DATABASE [BDSistema_Ventas] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BDSistema_Ventas]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[NombreCompleto] [varchar](100) NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPRA]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPRA](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdProveedor] [int] NULL,
	[TipoDocumento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_COMPRA]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_COMPRA](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NULL,
	[IdProducto] [int] NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_VENTA]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_VENTA](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdProducto] [int] NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[Subtotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NEGOCIO]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NEGOCIO](
	[IdNegocio] [int] NOT NULL,
	[Nombre] [varchar](60) NULL,
	[RUC] [varchar](60) NULL,
	[Direccion] [varchar](60) NULL,
	[Logo] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISO]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[NombreMenu] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Stock] [int] NOT NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[IdPROVEEDOR] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[RazonSocial] [varchar](100) NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPROVEEDOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[NombreCompleto] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[IdRol] [int] NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[TipoDocumento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[DocumentoCliente] [varchar](50) NULL,
	[NombreCliente] [varchar](100) NULL,
	[MontoPago] [decimal](10, 2) NULL,
	[MontoCambio] [decimal](10, 2) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CATEGORIA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[CLIENTE] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[COMPRA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT ((0)) FOR [PrecioCompra]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT ((0)) FOR [PrecioVenta]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[DETALLE_VENTA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PERMISO] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [PrecioCompra]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [PrecioVenta]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PROVEEDOR] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[ROL] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[USUARIO] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[VENTA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdPROVEEDOR])
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
ALTER TABLE [dbo].[DETALLE_COMPRA]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[COMPRA] ([IdCompra])
GO
ALTER TABLE [dbo].[DETALLE_COMPRA]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[PERMISO]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([IdRol])
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIA] ([IdCategoria])
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([IdRol])
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarCategoria]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EditarCategoria](
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
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITARUSUARIO]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_EDITARUSUARIO](
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
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO PARA ELIMINAR CATEGORIA
create procedure [dbo].[sp_EliminarCategoria](
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
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarProducto]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[SP_EliminarProducto](
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
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarProveedor]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_EliminarProveedor](
@IdProveedor int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (
		select * from PROVEEDOR p
		inner join COMPRA c on p.IdProveedor = c.IdProveedor
		where p.IdProveedor = @IdProveedor
	)
	begin
		delete top(1) from PROVEEDOR where IdProveedor = @IdProveedor
	end
	ELSE
	begin
		SET @Resultado = 0
		set @Mensaje = 'El proveedor se encuentra relacionado a una compra'
	end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINARUSUARIO]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ELIMINARUSUARIO](
    @IdUsuario int,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''
    DECLARE @pasoreglas bit = 1

    -- No borrar si tiene compras
    IF EXISTS (SELECT * FROM COMPRA C
               INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario
               WHERE U.IdUsuario = @IdUsuario)
    BEGIN
        SET @pasoreglas = 0
        SET @Respuesta = 0
        SET @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una COMPRA' + CHAR(13)
    END

    -- No borrar si tiene ventas
    IF EXISTS (SELECT * FROM VENTA V    
               INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario
               WHERE U.IdUsuario = @IdUsuario)
    BEGIN
        SET @pasoreglas = 0
        SET @Respuesta = 0
        SET @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una VENTA' + CHAR(13)
    END

    --Si pasó todas las reglas, procedemos a borrar
    IF (@pasoreglas = 1)
    BEGIN
        DELETE FROM USUARIO WHERE IdUsuario = @IdUsuario
        SET @Respuesta = 1
        SET @Mensaje = 'Usuario eliminado correctamente'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarCliente]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROC [dbo].[sp_ModificarCliente](
@IdCliente int,
@Documento varchar(50),
@NombreCompleto varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
    SET @Resultado = 1
    DECLARE @IDPERSONA INT
    
    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento and IdCliente != @IdCliente)
    begin
        update CLIENTE set
        Documento = @Documento,
        NombreCompleto = @NombreCompleto,
        Correo = @Correo,
        Telefono = @Telefono,
        Estado = @Estado
        where IdCliente = @IdCliente
    end
    else
    begin
        SET @Resultado = 0
        set @Mensaje = 'El numero de documento ya existe'
    end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarProducto]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[sp_ModificarProducto](
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
/****** Object:  StoredProcedure [dbo].[sp_ModificarProveedor]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create PROC [dbo].[sp_ModificarProveedor](
@IdProveedor int,
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	DECLARE @IDPERSONA INT
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento and IdProveedor != @IdProveedor)
	begin
		update PROVEEDOR set
		Documento = @Documento,
		RazonSocial = @RazonSocial,
		Correo = @Correo,
		Telefono = @Telefono,
		Estado = @Estado
		where IdProveedor = @IdProveedor
	end
	else
	begin
		SET @Resultado = 0
		set @Mensaje = 'El numero de documento ya existe'
	end
end

GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarCategoria]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_RegistrarCategoria](
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
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCliente]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_RegistrarCliente](
@Documento varchar(50),
@NombreCompleto varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
    SET @Resultado = 0
    DECLARE @IDPERSONA INT

    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento)
    begin
        insert into CLIENTE(Documento, NombreCompleto, Correo, Telefono, Estado) values (
        @Documento, @NombreCompleto, @Correo, @Telefono, @Estado)

        set @Resultado = SCOPE_IDENTITY()
    end
    else
        set @Mensaje = 'El numero de documento ya existe'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProducto]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_RegistrarProducto](
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
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProveedor]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_RegistrarProveedor](
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento)
	begin
		insert into PROVEEDOR(Documento, RazonSocial, Correo, Telefono, Estado) values (
		@Documento, @RazonSocial, @Correo, @Telefono, @Estado)

		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'El numero de documento ya existe'
end

GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRARUSUARIO]    Script Date: 19/5/2026 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_REGISTRARUSUARIO](
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
GO
USE [master]
GO
ALTER DATABASE [BDSistema_Ventas] SET  READ_WRITE 
GO
