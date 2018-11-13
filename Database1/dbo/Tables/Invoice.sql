CREATE TABLE [dbo].[Invoice]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [employee_id] INT NULL, 
    [quotation_id] INT NULL, 
    [payment_status] INT NULL, 
    [sum] DECIMAL(18, 2) NULL, 
    [deadline] DATETIME NULL, 
    [date] DATE NULL,
	FOREIGN KEY (employee_id) REFERENCES Employee(Id),
<<<<<<< HEAD:Database1/dbo/Tables/Invoice.sql
	FOREIGN KEY (quotation_id) REFERENCES Quotation(Id)
)
=======
	FOREIGN KEY (quotation_id) REFERENCES Quotation(Id),
	FOREIGN KEY (payment_status) REFERENCES Payment_status(Id)
)
>>>>>>> Martijn:FAP/Database1/Invoice.sql
