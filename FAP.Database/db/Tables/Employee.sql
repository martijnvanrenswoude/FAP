CREATE TABLE [dbo].[Employee]
(
	[id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [department_id] INT NOT NULL, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [surname] NVARCHAR(MAX) NOT NULL, 
    [acces level] INT NULL, 
    [position] NVARCHAR(MAX) NULL, 
    [postcode] NVARCHAR(6) NOT NULL, 
    [house number] NVARCHAR(10) NOT NULL
	FOREIGN KEY (department_id) REFERENCES Department(id), 
    [date_of_birth] DATE NOT NULL
)
