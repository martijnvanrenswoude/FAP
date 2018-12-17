MERGE INTO Department AS Target  
USING (values 
	('Sales', 'Hier werken de sales mensen'),
	('Marketing', 'Hier werken de Marketing mensen'),
	('CEO', 'Stephan'),
	('Worker', 'De andere werknemers')
) AS Source (name, description)  
ON Target.name = Source.name  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (name, description)  
VALUES (name, description);