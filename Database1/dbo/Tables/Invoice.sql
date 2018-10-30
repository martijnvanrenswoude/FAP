CREATE TABLE [dbo].[Invoice]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [employee_id] INT NULL, 
    [quotation_id] INT NULL, 
    [payment_status] INT NULL, 
    [sum] DECIMAL(18, 2) NULL, 
    [deadline] DATETIME NULL, 
    [date] DATE NULL,
	FOREIGN KEY (employee_id) REFERENCES Employee(Id),
	FOREIGN KEY (quotation_id) REFERENCES Quotation(Id)
)