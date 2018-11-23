CREATE TABLE [dbo].[Answers]
(
	[AnswerID] INT NOT NULL, 
    [QuestionID] INT NOT NULL, 
    [InspectorID] INT NOT NULL,
	[Answer] NVARCHAR(MAX) NULL, 
    primary key([AnswerID],QuestionID, InspectorID),
	FOREIGN KEY (QuestionID) REFERENCES Question(Id),
	FOREIGN KEY (InspectorID) REFERENCES Inspector(Id)
)
