CREATE TABLE [dbo].[QuestionnaireQuestion]
(
	[questionnaireId] INT NOT NULL, 
    [questionId] INT NOT NULL,
	PRIMARY KEY (questionId, questionnaireId), 
	FOREIGN KEY ([questionnaireId]) REFERENCES Questionnaire(Id),
	FOREIGN KEY ([questionId]) REFERENCES Question(Id)
)
