CREATE TABLE [dbo].[Contact]
(
	[contact_id] INT NOT NULL,
    [customer_id] INT NOT NULL, 
    [name] NVARCHAR(MAX) NULL, 
    [surname] NVARCHAR(MAX) NULL, 
    [telephone_nr] INT NULL, 
    [email] NVARCHAR(MAX) NULL,
	Unique(contact_id),
	PRIMARY KEY([contact_id], customer_id),
	FOREIGN KEY (customer_id) REFERENCES Customer(id)
)
