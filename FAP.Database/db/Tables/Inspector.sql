CREATE TABLE [dbo].[Inspector]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1000,1), 
    [name] NVARCHAR(MAX) NOT NULL, 
    [surname] NVARCHAR(MAX) NOT NULL, 
    [telephone_nr] INT NOT NULL, 
    [postcode] NVARCHAR(6) NOT NULL, 
    [house number] NVARCHAR(5) NOT NULL, 
    [date_of_birth] DATE NOT NULL,
)
