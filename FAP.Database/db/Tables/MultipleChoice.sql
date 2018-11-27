﻿CREATE TABLE [dbo].[MultipleChoice]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [questionnaire_id] INT NULL, 
    [answer] NVARCHAR(MAX) NULL, 
    [inspector_id] INT NULL
	FOREIGN KEY (inspector_id) REFERENCES Inspector(Id)
	FOREIGN KEY (questionnaire_id) REFERENCES questionnaire(Id),
)