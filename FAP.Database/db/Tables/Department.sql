CREATE TABLE [dbo].[Department]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [name] NVARCHAR(MAX) NOT NULL, 
    [description] NVARCHAR(MAX) NULL
)
