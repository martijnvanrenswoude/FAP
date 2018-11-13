CREATE TABLE [dbo].[Department]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [name] NVARCHAR(MAX) NULL, 
    [description] NVARCHAR(MAX) NOT NULL
)
