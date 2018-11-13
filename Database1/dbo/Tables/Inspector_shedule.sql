CREATE TABLE [dbo].[Inspector_shedule]
(
	[inspector_id] INT NOT NULL PRIMARY KEY, 
    [date] DATE NULL, 
    [available_from] DATETIME NULL, 
<<<<<<< HEAD:Database1/dbo/Tables/Inspector_shedule.sql
    [available_until] DATETIME NULL
)
=======
    [available_until] DATETIME NULL,
	Foreign Key(inspector_id) References Inspector(id)
)
>>>>>>> Martijn:FAP/Database1/Inspector_shedule.sql
