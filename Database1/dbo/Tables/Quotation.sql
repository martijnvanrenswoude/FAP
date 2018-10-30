CREATE TABLE [dbo].[Quotation]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [plan_id] INT NULL, 
    [customer_id] INT NULL, 
    [employee_id] INT NULL, 
    [event_id] INT NULL, 
    [sum] DECIMAL(18, 2) NULL, 
    [deadline] DATETIME NULL, 
    [date] DATE NULL,
	FOREIGN KEY (plan_id) REFERENCES Planning(Id),
	FOREIGN KEY (customer_id) REFERENCES Customer(Id),
	FOREIGN KEY (employee_id) REFERENCES Employee(Id),
	FOREIGN KEY (event_id) REFERENCES Event(Id)
)