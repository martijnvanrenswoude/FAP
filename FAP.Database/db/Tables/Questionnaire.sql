﻿CREATE TABLE [dbo].[Questionnaire]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1)
	FOREIGN KEY (ID) references Questionnaire(ID)
)
