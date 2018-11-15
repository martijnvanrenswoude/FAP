CREATE TABLE [dbo].[MultiplechoiceAnswers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Answer1] NVARCHAR(MAX) NOT NULL, 
    [Answer2] NVARCHAR(MAX) NOT NULL, 
    [Answer3] NVARCHAR(MAX) NULL, 
    [Answer4] NVARCHAR(MAX) NULL, 
    [question_id] INT NOT NULL
)
