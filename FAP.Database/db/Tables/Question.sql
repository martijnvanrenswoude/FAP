CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
    [questionnaire_id] INT NOT NULL, 
	[answer] NVARCHAR(MAX) NULL, 
    [inspector_id] INT NULL, 
    FOREIGN KEY (questionnaire_id) REFERENCES Questionnaire(Id)
)
