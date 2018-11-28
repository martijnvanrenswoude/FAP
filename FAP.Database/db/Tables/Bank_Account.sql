CREATE TABLE [dbo].[Bank_Account]
(
	[account_number] NVARCHAR(MAX) NOT NULL , 
    [employee_id] INT NOT NULL primary key,
	FOREIGN KEY (employee_id) REFERENCES Employee(Id)
)
