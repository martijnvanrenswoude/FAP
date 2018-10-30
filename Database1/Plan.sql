CREATE TABLE [dbo].[Plan]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [customer_id] INT NULL, 
    [event_id] INT NULL, 
    [questionnaire_id] INT NULL, 
    [start_date] DATETIME NULL
)
