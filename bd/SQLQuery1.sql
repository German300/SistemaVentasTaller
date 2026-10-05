SELECT p.IdPermiso, p.NombreMenu 
FROM PERMISO p
INNER JOIN ROL r ON r.IdRol = p.IdRol
INNER JOIN USUARIO U ON U.IdRol = r.IdRol

where u.IdUsuario = 2




insert into PERMISO(IdRol,NombreMenu) values
(1, 'menuusuarios'),
(1, 'menumantenimiento'),
(1, 'menuventas'),
(1, 'menucompras'),
(1, 'menuclientes'),
(1, 'menuproveedores'),
(1, 'menureportes'),
(1, 'menuacercade')



insert into ROL (Descripcion)
values ('EMPLEADO')


SELECT * FROM ROL



insert into PERMISO(IdRol,NombreMenu) values
(2, 'menuventas'),
(2, 'menucompras'),
(2, 'menuclientes'),
(2, 'menuproveedores'),
(2, 'menuacercade')



insert into USUARIO (Documento, NombreCompleto,Correo,Clave,IdRol,Estado)
values
('151617','EMPLEAD0', 'empleado@gmail.com','456',2,1)


select * from USUARIO



select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado, r.IdRol, r.Descripcion from usuario u
inner join rol r on r.IdRol = u.IdRol