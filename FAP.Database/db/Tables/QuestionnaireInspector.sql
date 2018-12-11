CREATE TABLE [dbo].[QuestionnaireInspector]
(
	[InspectorId] INT NOT NULL, 
    [QuestionnaireId] INT NOT NULL,
	PRIMARY KEY (InspectorId, QuestionnaireId),
	FOREIGN KEY ([InspectorId]) REFERENCES Inspector(Id),
	FOREIGN KEY ([QuestionnaireId]) REFERENCES Questionnaire(Id)
)
