
-- SCRIPT DE INSERCIÓN DE DATOS DE PRUEBA



-- 1. INSERCIÓN EN TABLA: USUARIO
-- (Asume que los IdRol 1=Administrador y 2=Empleado ya existen)
-- ---------------------------------------------
INSERT INTO USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado) VALUES
('35123456', 'Juan Carlos Pérez', 'jperez@email.com', '123456', 1, 1),
('38987654', 'María Elena Gómez', 'mgomez@email.com', '123456', 2, 1),
('40111222', 'Roberto Carlos Silva', 'rsilva@email.com', '123456', 2, 1),
('37333444', 'Ana Laura Martínez', 'amartinez@email.com', '123456', 2, 1),
('39555666', 'Diego Fernando López', 'dlopez@email.com', '123456', 2, 1),
('41777888', 'Sofía Beatriz Rodríguez', 'srodriguez@email.com', '123456', 2, 1),
('36999000', 'Lucía Fernanda Díaz', 'ldiaz@email.com', '123456', 1, 1);

-- ---------------------------------------------
-- 2. INSERCIÓN EN TABLA: CLIENTE
-- ---------------------------------------------
INSERT INTO CLIENTE (Documento, NombreCompleto, Correo, Telefono, Estado) VALUES
('28111222', 'Carlos Alberto Ruiz', 'cruiz@gmail.com', '1145678901', 1),
('31333444', 'Patricia Noemí Torres', 'ptorres@gmail.com', '1156789012', 1),
('34555666', 'Gabriel Eduardo Romero', 'gromero@hotmail.com', '1167890123', 1),
('30777888', 'Valeria Inés Benítez', 'vbenitez@yahoo.com', '1178901234', 1),
('33999000', 'Fernando Gabriel Acosta', 'facosta@gmail.com', '1189012345', 1),
('29123987', 'Camila Belén Medina', 'cmedina@outlook.com', '1190123456', 1),
('32456789', 'Hugo Marcelo Castro', 'hcastro@gmail.com', '1123456789', 1);

-- ---------------------------------------------
-- 3. INSERCIÓN EN TABLA: PROVEEDOR
-- ---------------------------------------------
INSERT INTO PROVEEDOR (Documento, RazonSocial, Correo, Telefono, Estado) VALUES
('30711223344', 'Distribuidora Global S.A.', 'contacto@distribuidoraglobal.com', '08101112233', 1),
('30822334455', 'Logística y Mayorista Norte SRL', 'ventas@logisticanorte.com', '01143219876', 1),
('30933445566', 'Importadora del Plata S.A.', 'info@importadoradelplata.com', '01154328765', 1),
('30144556677', 'Comercializadora Centro SRL', 'contacto@comercialcentrosrl.com', '01165437654', 1),
('30255667788', 'Insumos Industriales Sur S.A.', 'ventas@insumossur.com', '01176546543', 1),
('30366778899', 'TecnoProveedores Argentina SRL', 'soporte@tecnoproveedores.com', '01187655432', 1),
('30477889900', 'Abastecedora Nacional S.A.', 'info@abastecedoranacional.com', '01198764321', 1);

-- ---------------------------------------------
-- 4. INSERCIÓN EN TABLA: PRODUCTO
-- (Asume que los IdCategoria 1, 2, 3... ya existen en la tabla CATEGORIA)
-- ---------------------------------------------
-- ---------------------------------------------
-- 4. INSERCIÓN EN TABLA: PRODUCTO (Sin la columna Stock)
-- ---------------------------------------------
INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, IdCategoria, PrecioCompra, PrecioVenta, Estado) VALUES
('PROD001', 'Monitor LED 24"', 'Monitor Full HD 1080p HDMI VGA', 1, 120000.00, 165000.00, 1),
('PROD002', 'Teclado Mecánico RGB', 'Teclado retroiluminado switch azul', 1, 25000.00, 38000.00, 1),
('PROD003', 'Mouse Óptico Inalámbrico', 'Mouse ergonómico 1600 DPI', 1, 8500.00, 14000.00, 1),
('PROD004', 'Disco Sólido SSD 480GB', 'SSD SATA3 lectura rápida 500MB/s', 2, 32000.00, 49000.00, 1),
('PROD005', 'Memoria RAM 16GB DDR4', 'RAM 3200MHz para PC de escritorio', 2, 45000.00, 68000.00, 1),
('PROD006', 'Auriculares Gamer 7.1', 'Auriculares con micrófono e iluminación LED', 3, 18000.00, 29000.00, 1),
('PROD007', 'Impresora Multifunción', 'Impresora a color con sistema continuo', 4, 180000.00, 245000.00, 1);