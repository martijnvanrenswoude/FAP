CREATE TABLE [dbo].[StandardQuestionsList]
(
	[standardquestion_id] INT NOT NULL,
	primary key([standardquestion_id], questionnaire_id),
    [questionnaire_id] INT NOT NULL, 
    [answer] NVARCHAR(MAX) NULL,
	FOREIGN KEY (standardquestion_id) REFERENCES StandardQuestion(Id),
	FOREIGN KEY (questionnaire_id) REFERENCES Questionnaire(Id)
)
