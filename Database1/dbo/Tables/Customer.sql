CREATE TABLE [dbo].[Customer]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [name] NVARCHAR(MAX) NULL, 
    [telephone_nr] INT NULL, 
    [postcode] NVARCHAR(6) NULL, 
    [house number] NVARCHAR(10) NULL, 
    [email] NVARCHAR(MAX) NULL
)