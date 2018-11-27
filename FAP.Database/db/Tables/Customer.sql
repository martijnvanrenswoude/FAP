CREATE TABLE [dbo].[Customer]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [name] NVARCHAR(MAX) NOT NULL, 
    [telephone_nr] INT NOT NULL, 
    [postcode] NVARCHAR(6) NOT NULL, 
    [house number] NVARCHAR(10) NOT NULL, 
    [email] NVARCHAR(MAX) NOT NULL
)
