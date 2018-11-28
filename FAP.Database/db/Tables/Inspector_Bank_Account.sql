CREATE TABLE [dbo].[Inspector_Bank_Account]
(
	[Inspector_ID] INT NOT NULL PRIMARY KEY, 
    [Banknumber] NVARCHAR(MAX) NOT NULL,
	FOREIGN KEY (Inspector_ID) REFERENCES inspector(Id)
)
