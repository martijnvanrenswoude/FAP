CREATE TABLE [dbo].[Inspector]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1000,1), 
    [name] NVARCHAR(MAX) NOT NULL, 
    [surname] NVARCHAR(MAX) NOT NULL, 
    [telephone_nr] INT NULL, 
    [postcode] NVARCHAR(6) NULL, 
    [house number] NVARCHAR(5) NULL,
)
