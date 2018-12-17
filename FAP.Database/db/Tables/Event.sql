CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [contact_id] INT not NULL, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [date] DATETIME NOT NULL, 
    [amount_visitors] INT NULL, 
    [surface area_m2] INT NULL, 
    [description] NVARCHAR(MAX) NULL,
	[postcode] NCHAR(10) NOT NULL, 
    [house_number] NCHAR(10) NOT NULL, 
    [customer_id] INT NULL, 
    FOREIGN KEY (contact_id) REFERENCES Contact([contact_id]),
	FOREIGN KEY (customer_id) References Customer(id)
)
