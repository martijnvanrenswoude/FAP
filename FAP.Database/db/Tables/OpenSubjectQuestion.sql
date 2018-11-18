CREATE TABLE [dbo].[OpenSubjectQuestion]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [inspector_id] INT NOT NULL, 
    [subject] NVARCHAR(MAX) NULL, 
    [answer] NVARCHAR(MAX) NULL, 
    [questionnaire_id] INT NULL,
	FOREIGN KEY (questionnaire_id) REFERENCES questionnaire(Id),
	FOREIGN KEY (inspector_id) REFERENCES Inspector(Id)
)
