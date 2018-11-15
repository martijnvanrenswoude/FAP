CREATE TABLE [dbo].[OpenSubjectQuestion]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [inspector_id] NVARCHAR(MAX) NOT NULL, 
    [subject] NVARCHAR(MAX) NULL, 
    [answer] NVARCHAR(MAX) NULL
)
