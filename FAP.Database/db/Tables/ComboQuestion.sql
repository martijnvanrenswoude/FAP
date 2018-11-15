CREATE TABLE [dbo].[ComboQuestion]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [questionnaire_id] NCHAR(10) NULL, 
    [subject] NCHAR(10) NULL, 
    [inspector_id] NCHAR(10) NULL, 
    [answer] NCHAR(10) NULL
)
