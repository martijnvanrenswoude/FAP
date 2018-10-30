CREATE TABLE [dbo].[Plan_inspector]
(
	[plan_id] INT NOT NULL , 
	Primary Key([plan_id], inspector_id),
    [inspector_id] INT NOT NULL,
	FOREIGN KEY (plan_id) REFERENCES Planning(Id),
	FOREIGN KEY (inspector_id) REFERENCES Inspector(Id)
)