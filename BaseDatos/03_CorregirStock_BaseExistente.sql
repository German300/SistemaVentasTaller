-- =====================================================================
-- SOLO para una base creada con los scripts de la carpeta bd.
-- bd/correcionesnuevas.sql borró la columna Stock y bd/modificarproducto.sql
-- la volvió a crear como "Stock int null" sin valor por defecto.
-- Con Stock en NULL, "Stock - Cantidad" sigue dando NULL y el stock nunca baja.
-- =====================================================================
USE [BDSistema_Ventas]
GO

UPDATE PRODUCTO SET Stock = 0 WHERE Stock IS NULL
GO

ALTER TABLE PRODUCTO ALTER COLUMN Stock int NOT NULL
GO

IF NOT EXISTS (SELECT * FROM sys.default_constraints
               WHERE parent_object_id = OBJECT_ID('PRODUCTO')
                 AND COL_NAME(parent_object_id, parent_column_id) = 'Stock')
    ALTER TABLE PRODUCTO ADD CONSTRAINT DF_PRODUCTO_Stock DEFAULT 0 FOR Stock
GO
