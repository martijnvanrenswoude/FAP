CREATE TABLE [dbo].[StandardQuestionsList]
(
	[standardquestion_id] INT NOT NULL,
	primary key([standardquestion_id], questionnaire_id),
    [questionnaire_id] INT NOT NULL, 
    [answer] NVARCHAR(MAX) NULL
)
