CREATE TABLE [dbo].[Translation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NomProduit] NCHAR(100) NOT NULL, 
    [Quantité] INT NOT NULL, 
    [TypeTranslation] NCHAR(100) NOT NULL, 
    [User] NCHAR(100) NOT NULL, 
    [DateTranslation] DATETIME NOT NULL
)
