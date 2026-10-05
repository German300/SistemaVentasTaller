insert into PRODUCTO(Codigo,Nombre,Descripcion,IDCategoria) values
('101010','Gaseosa Pepsi','1Litro',5)

select * from PRODUCTO
UPDATE PRODUCTO SET Estado = 1



INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta, Estado) 
VALUES 
('P001', 'Leche Entera 1L', 'Larga vida primera marca', 1, 450, 950.50, 1450.00, 1),
('P002', 'Queso Tybo 250g', 'Feteado en origen', 1, 120, 2800.00, 4200.00, 1),
('P003', 'Manteca 200g', 'Calidad extra', 1, 85, 1500.00, 2300.00, 1),
('P004', 'Yerba Mate 1kg', 'Con palo - Especial', 3, 320, 3100.00, 4800.00, 1),
('P005', 'Aceite Girasol 1.5L', 'Puro de girasol', 3, 150, 1850.00, 2900.00, 1),
('P006', 'Fideos Tallarines', 'Sémola de trigo duro', 3, 600, 850.00, 1350.00, 1),
('P007', 'Arroz Largo Fino 1kg', 'No se pasa ni se pega', 3, 540, 1100.00, 1750.00, 1),
('P008', 'Jabón Líquido 3L', 'Para ropa delicada', 4, 90, 5200.00, 8500.00, 1),
('P009', 'Lavandina 1L', 'Máxima pureza', 4, 210, 750.00, 1250.00, 1),
('P010', 'Shampoo Anti-frizz', 'Uso diario 400ml', 4, 115, 2400.00, 3900.00, 1);













DELETE FROM PRODUCTO WHERE IdProducto BETWEEN 1 AND 11;