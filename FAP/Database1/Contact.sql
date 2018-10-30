CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL,
    [customer_id] INT NOT NULL, 
    [name] NVARCHAR(MAX) NULL, 
    [surname] NVARCHAR(MAX) NULL, 
    [telephone_nr] INT NULL, 
    [email] NVARCHAR(MAX) NULL,
	PRIMARY KEY(Id, customer_id),
	FOREIGN KEY (customer_id) REFERENCES Customer(id)
)
