CREATE TABLE [dbo].[Bank_Account]
(
	[account_number] INT NOT NULL PRIMARY KEY, 
    [employee_id] INT NULL,
	FOREIGN KEY (employee_id) REFERENCES ID(Id)
)