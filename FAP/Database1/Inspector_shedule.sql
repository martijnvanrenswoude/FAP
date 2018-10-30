CREATE TABLE [dbo].[Inspector_shedule]
(
	[inspector_id] INT NOT NULL PRIMARY KEY, 
    [date] DATE NULL, 
    [available_from] DATETIME NULL, 
    [available_until] DATETIME NULL,
	Foreign Key(inspector_id) References Inspector(id)
)
