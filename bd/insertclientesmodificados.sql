USE BDSistema_Ventas;
GO

-- 1. Deshabilitar temporalmente las restricciones de clave foránea
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- 2. Limpiar las tablas dependientes de ventas y vaciar Cliente
DELETE FROM DETALLE_VENTA;
DELETE FROM VENTA;
DELETE FROM CLIENTE;

-- 3. Habilitar nuevamente las restricciones
EXEC sp_MSforeachtable "ALTER TABLE ? CHECK CONSTRAINT ALL";

-- 4. Restablecer el contador autoincremental del ID de Cliente a 0
DBCC CHECKIDENT ('CLIENTE', RESEED, 0);

-- 5. Insertar 10 clientes reales con formato y datos consistentes
INSERT INTO CLIENTE (Documento, NombreCompleto, Correo, Telefono, Estado, FechaCreacion) VALUES
('41222333', 'Lucas Nahuel Gómez', 'lucas.gomez@gmail.com', '3814556677', 1, GETDATE()),
('39444555', 'Sofía Belén Morales', 'sofia.morales@yahoo.com', '3816778899', 1, GETDATE()),
('36777888', 'Matías Ezequiel Sosa', 'matias.sosa@outlook.com', '3813112233', 1, GETDATE()),
('42111222', 'Camila Ayelén Paz', 'camila.paz@gmail.com', '3815998844', 1, GETDATE()),
('38333444', 'Gonzalo Javier Rossi', 'gonzalo.rossi@gmail.com', '3812233445', 1, GETDATE()),
('40555666', 'Julieta Anabel Navarro', 'julieta.navarro@hotmail.com', '3816443322', 1, GETDATE()),
('37888999', 'Franco Damián Herrera', 'franco.herrera@gmail.com', '3814887766', 1, GETDATE()),
('43000111', 'Agustina Belén Maidana', 'agustina.maidana@yahoo.com', '3817112233', 1, GETDATE()),
('35666777', 'Facundo Nicolás Benítez', 'facundo.benitez@outlook.com', '3813990011', 1, GETDATE()),
('44111999', 'Martina Luján Silva', 'martina.silva@gmail.com', '3815334455', 1, GETDATE());