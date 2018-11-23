CREATE TABLE [dbo].[Inlogdata]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [username] NVARCHAR(50) NULL, 
    [password] NVARCHAR(24) NULL,
	FOREIGN KEY (Id) REFERENCES Employee(Id)
)
