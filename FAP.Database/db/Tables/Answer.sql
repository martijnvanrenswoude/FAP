CREATE TABLE [dbo].[Answer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [questionId] INT NOT NULL, 
    [Subject] NVARCHAR(MAX) NOT NULL, 
    [answer] NVARCHAR(MAX) NULL,
	[Image] IMAGE NULL, 
    FOREIGN KEY (questionId) REFERENCES Question(Id)
)
