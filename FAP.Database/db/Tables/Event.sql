CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [contact_id] INT not NULL, 
    [name] NVARCHAR(MAX) NULL, 
    [date] DATETIME NULL, 
    [amount_visitors] INT NULL, 
    [surface area_m2] INT NULL, 
    [description] NVARCHAR(MAX) NULL,
	FOREIGN KEY (contact_id) REFERENCES Contact([contact_id])
)
