CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [contact_id] INT NULL, 
    [name] NVARCHAR(MAX) NULL, 
    [date] NVARCHAR(MAX) NULL, 
    [amount_visitors] INT NULL, 
    [surface area_m2] INT NULL, 
    [description] NVARCHAR(MAX) NULL
)
