-- 1. Borrar todos los usuarios cuyo ID sea mayor a 2 (dejando el 1 y el 2)
DELETE FROM USUARIO WHERE IdUsuario > 2;

-- 2. Restablecer el contador del ID para que el siguiente comience en 3
DBCC CHECKIDENT ('USUARIO', RESEED, 2);

-- 3. Insertar 4 nuevos usuarios con distintos roles y contraseñas
INSERT INTO USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado, FechaRegistro) VALUES 
('40111222', 'Carlos Gómez', 'carlos.gomez@gmail.com', 'claveCarlos1', 2, 1, GETDATE()),
('38987654', 'Laura Martínez', 'laura.martinez@gmail.com', 'lauraPass2026', 2, 1, GETDATE()),
('41777888', 'Esteban Administrador', 'esteban.admin@gmail.com', 'adminPass99', 1, 1, GETDATE()),
('37333444', 'Valeria Ríos', 'valeria.rios@gmail.com', 'valeriaSec2', 2, 1, GETDATE());










select * from USUARIO