CREATE TABLE [dbo].[Quotation]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [plan_id] INT NULL, 
    [customer_id] INT NULL, 
    [employee_id] INT NULL, 
    [event_id] INT NULL, 
    [sum] DECIMAL(18, 2) NULL, 
    [deadline] DATETIME NULL, 
    [date] DATE NULL
)
