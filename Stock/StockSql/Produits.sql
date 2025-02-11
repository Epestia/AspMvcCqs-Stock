CREATE TABLE [dbo].[Produits]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [nom] NCHAR(10) NULL, 
    [marque] NCHAR(100) NULL,
    [GTIN] NCHAR(10) NULL,
    [prix] NCHAR(100) NOT NULL,
)
