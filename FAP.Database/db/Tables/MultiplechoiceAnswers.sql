CREATE TABLE [dbo].[MultiplechoiceAnswers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [question_id] INT NOT NULL,
	[Answer] NVARCHAR(MAX) NULL, 
    FOREIGN KEY (question_id) REFERENCES Multiplechoice(Id),
)
