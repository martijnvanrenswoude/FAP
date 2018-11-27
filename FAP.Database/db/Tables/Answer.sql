CREATE TABLE [dbo].[Answer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [questionId] INT NULL, 
    [Subject] NVARCHAR(MAX) NULL, 
    [answer] NVARCHAR(MAX) NULL,
	[Image] IMAGE NULL, 
    FOREIGN KEY (questionId) REFERENCES Question(Id)
)
