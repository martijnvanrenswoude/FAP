CREATE TABLE [dbo].[Quotation]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [plan_id] INT NOT NULL, 
    [customer_id] INT NOT NULL, 
    [employee_id] INT NOT NULL, 
    [event_id] INT NOT NULL, 
    [sum] DECIMAL(18, 2) NOT NULL, 
    [deadline] DATETIME NOT NULL, 
    [date] DATE NOT NULL,
	[image] IMAGE NULL, 
    FOREIGN KEY (plan_id) REFERENCES Planning(Id),
	FOREIGN KEY (customer_id) REFERENCES Customer(Id),
	FOREIGN KEY (employee_id) REFERENCES Employee(Id),
	FOREIGN KEY (event_id) REFERENCES Event(Id)
)
