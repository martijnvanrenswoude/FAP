CREATE TABLE [dbo].[Bank_Account]
(
	[account_number] INT NOT NULL PRIMARY KEY, 
    [employee_id] INT NULL,
	FOREIGN KEY (employee_id) REFERENCES ID(Id)
<<<<<<< HEAD:Database1/dbo/Tables/Bank_Account.sql
)
=======
)
>>>>>>> Martijn:FAP/Database1/Bank_Account.sql
