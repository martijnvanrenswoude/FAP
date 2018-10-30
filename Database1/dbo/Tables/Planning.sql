CREATE TABLE [dbo].[Planning]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [customer_id] INT NULL, 
    [event_id] INT NULL, 
    [questionnaire_id] INT NULL, 
    [start_date] DATETIME NULL,
	[employee_id] INT NULL, 
    FOREIGN KEY (customer_id) REFERENCES Customer(Id),
	FOREIGN KEY (employee_id) REFERENCES Employee(Id),
	FOREIGN KEY (questionnaire_id) REFERENCES questionnaire(Id),
	FOREIGN KEY (event_id) REFERENCES Event(Id)
)