
select * from PRODUCTO

ALTER TABLE PRODUCTO ADD Stock int null;
SELECT p.IdProducto, p.Codigo, p.Nombre, p.Descripcion, c.IdCategoria, c.Descripcion[DescripcionCategoria], p.Stock, p.PrecioCompra, p.PrecioVenta, p.Estado
FROM PRODUCTO p
LEFT JOIN CATEGORIA c ON c.IdCategoria = p.IdCategoria;