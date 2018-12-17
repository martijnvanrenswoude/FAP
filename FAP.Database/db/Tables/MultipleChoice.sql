CREATE TABLE [dbo].[MultipleChoice]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [question] NVARCHAR(MAX) NOT NULL, 
    [inspector_id] INT NULL
	FOREIGN KEY (inspector_id) REFERENCES Inspector(Id), 
    [AmountOfAnswers] INT NOT NULL,
)
