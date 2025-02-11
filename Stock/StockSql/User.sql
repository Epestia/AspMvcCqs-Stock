CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [nom] NCHAR(100) NULL,
    [prenom] NCHAR(100) NULL,
    [mail] NCHAR(100) NULL, 
    [MotDePasse] NVARCHAR(50) NULL
)
