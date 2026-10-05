-- 1. Agregamos la columna IdCliente en la tabla VENTA (si es que no existía)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('VENTA') AND name = 'IdCliente')
BEGIN
    ALTER TABLE VENTA ADD IdCliente int;
END
GO

-- 2. Creamos la restricción de Clave Foránea (FK) para relacionar formalmente ambas tablas
-- Esto es lo que la profesora va a buscar ver sí o sí en la base de datos.
ALTER TABLE VENTA 
ADD CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente) REFERENCES CLIENTES(IdCliente);
GO

DELETE FROM DETALLE_VENTA;
DELETE FROM VENTA;



-- 1. Vaciamos absolutamente todas las tablas de movimientos de prueba en orden
DELETE FROM DETALLE_VENTA;
DELETE FROM Venta;
DELETE FROM DETALLE_COMPRA;
DELETE FROM COMPRA;
delete from CLIENTE

-- 2. Ahora sí, creamos la relación de Clientes con Ventas
ALTER TABLE VENTA 
ADD CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente) REFERENCES CLIENTES(IdCliente);
GO
















-- 1. Apagamos temporalmente todas las restricciones de llaves foráneas
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- 2. Usamos DELETE en lugar de TRUNCATE para limpiar las tablas de prueba
DELETE FROM DETALLE_VENTA;
DELETE FROM VENTA;
DELETE FROM DETALLE_COMPRA;
DELETE FROM COMPRA;

-- 3. Volvemos a encender las restricciones de seguridad
EXEC sp_MSforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL";


-- Creamos la relación apuntando a tu tabla real: CLIENTE (en singular)
ALTER TABLE VENTA 
ADD CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente);
GO



CREATE TABLE MOVIMIENTO_STOCK (
    IdMovimiento int PRIMARY KEY IDENTITY(1,1),
    IdProducto int NOT NULL,
    Fecha datetime DEFAULT getdate(),
    Tipo varchar(10) NOT NULL, -- Acá se guardará estrictamente 'INGRESO' o 'EGRESO'
    Cantidad int NOT NULL,
    CONSTRAINT FK_Movimiento_Producto FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto)
);
GO


-- 1. Borramos la restricción por defecto usando el nombre exacto que te dio el error
ALTER TABLE PRODUCTO DROP CONSTRAINT DF__PRODUCTO__Stock__778AC167;
GO

-- 2. Ahora que no tiene dependencias, borramos la columna Stock tranquilamente
ALTER TABLE PRODUCTO DROP COLUMN Stock;
GO