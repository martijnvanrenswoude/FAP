CREATE TABLE [dbo].[Questionnaire]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [image] IMAGE NULL, 
    [comment] NVARCHAR(MAX) NULL
)
