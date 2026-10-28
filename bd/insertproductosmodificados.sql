USE BDSistema_Ventas;
GO

-- 1. Deshabilitar temporalmente las restricciones de clave foránea para limpiar sin errores de FK
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- 2. Limpiar las tablas operativas de prueba (Detalles, Ventas, Compras y Productos)
DELETE FROM DETALLE_VENTA;
DELETE FROM VENTA;
DELETE FROM DETALLE_COMPRA;
DELETE FROM COMPRA;
DELETE FROM PRODUCTO;

-- 3. Habilitar nuevamente las restricciones
EXEC sp_MSforeachtable "ALTER TABLE ? CHECK CONSTRAINT ALL";

-- 4. Restablecer el contador autoincremental del ID de Producto
DBCC CHECKIDENT ('PRODUCTO', RESEED, 0);

-- 5. Insertar 10 productos reales con código, precios, stock y categoría
-- Asumiendo que: IdCategoria 1 = Lácteos/Frescos, 2 = Embutidos/Fiambrería, 3 = Almacén, 4 = Limpieza/Higiene
INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta, Estado, FechaRegistro) VALUES
('P001', 'Leche Entera 1L', 'Leche entera ultra pasteurizada larga vida 1L', 1, 50, 950.00, 1450.00, 1, GETDATE()),
('P002', 'Manteca 200g', 'Manteca de primera calidad extra 200g', 1, 30, 1500.00, 2300.00, 1, GETDATE()),
('P003', 'Queso Cremoso 1kg', 'Queso cremoso horma fraccionada x kg', 1, 20, 4800.00, 6900.00, 1, GETDATE()),
('P004', 'Yerba Mate 1kg', 'Yerba mate con palo estacionamiento natural 1kg', 3, 40, 2200.00, 3200.00, 1, GETDATE()),
('P005', 'Aceite Girasol 1.5L', 'Aceite 100% puro de girasol 1.5 litros', 3, 35, 1850.00, 2600.00, 1, GETDATE()),
('P006', 'Arroz Largo Fino 1kg', 'Arroz elaborado no se pasa ni se pega 1kg', 3, 60, 1100.00, 1650.00, 1, GETDATE()),
('P007', 'Fideos Tallarines 500g', 'Fideos secos de sémola de trigo duro 500g', 3, 45, 850.00, 1300.00, 1, GETDATE()),
('P008', 'Jabón Líquido 3L', 'Jabón líquido para ropa marea baja 3L', 4, 15, 3200.00, 4800.00, 1, GETDATE()),
('P009', 'Lavandina 1L', 'Lavandina máxima pureza desinfectante 1L', 4, 25, 800.00, 1250.00, 1, GETDATE()),
('P010', 'Shampoo 400ml', 'Shampoo restauración y brillo 400ml', 4, 18, 2400.00, 3600.00, 1, GETDATE());