

create table NEGOCIO (
IdNegocio int primary key,
Nombre varchar(60),
RUC varchar (60),
Direccion varchar(60),
Logo varbinary (max) null
)

select * from NEGOCIO

insert into NEGOCIO (IdNegocio, Nombre, RUC,Direccion) values
('1', 'Sistema De Ventas C#', '101010' ,'avenida.tucuman123')