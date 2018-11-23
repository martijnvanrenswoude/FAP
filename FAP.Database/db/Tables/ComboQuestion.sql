CREATE TABLE [dbo].[ComboQuestion]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [questionnaire_id] INT NULL, 
    [subject] NVARCHAR(50) NULL, 
    [inspector_id] INT NULL, 
    [answer] NVARCHAR(MAX) NULL,
	FOREIGN KEY (inspector_id) REFERENCES Inspector(Id),
	FOREIGN KEY (questionnaire_id) REFERENCES questionnaire(Id)
)
