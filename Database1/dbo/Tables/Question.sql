CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [questionnaire_id] INT NOT NULL, 
    [question] NVARCHAR(MAX) NULL, 
    [answer] NVARCHAR(MAX) NULL,
	FOREIGN KEY (questionnaire_id) REFERENCES Questionnaire(Id)
)