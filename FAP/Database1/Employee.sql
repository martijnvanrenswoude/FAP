﻿CREATE TABLE [dbo].[Medewerker]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [department_id] INT NULL, 
    [name] NVARCHAR(MAX) NULL, 
    [surname] NVARCHAR(MAX) NULL, 
    [acces level] INT NULL, 
    [position] NVARCHAR(MAX) NULL, 
    [postcode] NVARCHAR(6) NULL, 
    [house number] NVARCHAR(10) NULL
)