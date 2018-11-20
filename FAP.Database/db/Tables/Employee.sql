CREATE TABLE [dbo].[Employee]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [department_id] INT NULL, 
    [name] NVARCHAR(MAX) NULL, 
    [surname] NVARCHAR(MAX) NULL, 
    [acces level] INT NULL, 
    [position] NVARCHAR(MAX) NULL, 
    [postcode] NVARCHAR(6) NULL, 
    [house number] NVARCHAR(10) NULL
	FOREIGN KEY (department_id) REFERENCES Department(id)
)
