USE BDSistema_Ventas;
GO

-- 1. Deshabilitar temporalmente las restricciones de clave foránea
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- 2. Limpiar las tablas dependientes y vaciar Proveedor
DELETE FROM DETALLE_COMPRA;
DELETE FROM COMPRA;
DELETE FROM PROVEEDOR;

-- 3. Habilitar nuevamente las restricciones
EXEC sp_MSforeachtable "ALTER TABLE ? CHECK CONSTRAINT ALL";

-- 4. Restablecer el contador autoincremental del ID de Proveedor a 0
DBCC CHECKIDENT ('PROVEEDOR', RESEED, 0);

-- 5. Insertar 10 proveedores reales usando la columna correcta: FechaCreacion
INSERT INTO PROVEEDOR (Documento, RazonSocial, Correo, Telefono, Estado, FechaCreacion) VALUES
('30711223344', 'La Serenisima S.A.', 'contacto@laserenisima.com.ar', '08005552665', 1, GETDATE()),
('30685544332', 'Mastellone Hermanos S.A.', 'ventas@mastellone.com.ar', '01147558899', 1, GETDATE()),
('30554433221', 'Arcor Distribuidora S.R.L.', 'pedidos@arcor.com', '03514223344', 1, GETDATE()),
('30719888776', 'Molinos Río de la Plata S.A.', 'atencion@molinos.com.ar', '01143445566', 1, GETDATE()),
('30632112233', 'Mast S.A. Alimentos', 'comercial@mast.com.ar', '01148889900', 1, GETDATE()),
('30744556677', 'Unilever Argentina S.A.', 'contacto.unilever@unilever.com', '08008883333', 1, GETDATE()),
('30588990011', 'SC Johnson & Son de Argentina', 'ventas@scjohnson.com', '01147772233', 1, GETDATE()),
('30733221144', 'Procter & Gamble Argentina', 'atencionclientes@pg.com', '08003336666', 1, GETDATE()),
('30699887766', 'Frigorífico Paladini S.A.', 'paladini@paladini.com.ar', '03414777564', 1, GETDATE()),
('30511223344', 'Sancor Cooperativas Unidas Ltda.', 'info@sancor.com', '03493422000', 1, GETDATE());