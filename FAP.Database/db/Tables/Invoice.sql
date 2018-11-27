CREATE TABLE [dbo].[Invoice]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [employee_id] INT NOT NULL, 
    [quotation_id] INT NOT NULL, 
    [payment_status] INT NOT NULL, 
    [sum] DECIMAL(18, 2) NOT NULL, 
    [deadline] DATETIME NOT NULL, 
    [date] DATE NOT NULL,
	[image] IMAGE NULL, 
    FOREIGN KEY (employee_id) REFERENCES Employee(Id),
	FOREIGN KEY (quotation_id) REFERENCES Quotation(Id),
	FOREIGN KEY (payment_status) REFERENCES Payment_status(Id)
)
