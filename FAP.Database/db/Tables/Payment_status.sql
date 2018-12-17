CREATE TABLE [dbo].[Payment_status]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [name] NVARCHAR(MAX) NOT NULL, 
    [descriptiom] NVARCHAR(MAX) NULL
)
