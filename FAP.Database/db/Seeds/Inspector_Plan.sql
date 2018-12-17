MERGE INTO Plan_inspector AS Target  
USING (values 
	(1, 1000),
	(2, 1001),
	(3, 1001),
	(4, 1002),
	(5, 1002),
	(6, 1002),
	(7, 1002)
) AS Source (plan_id, inspector_id)  
ON Target.plan_id = Source.plan_id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (plan_id, inspector_id)
VALUES (plan_id, inspector_id);