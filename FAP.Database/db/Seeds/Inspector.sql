MERGE INTO Inspector AS Target  
USING (values 
	('Inspector 1', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17'),
	('Inspector 2', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17'),
	('Inspector 3', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17'),
	('Inspector 4', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17'),
	('Inspector 5', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17'),
	('Inspector 6', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17'),
	('Inspector 7', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17'),
	('Inspector 8', 'SPECC', 0623421366, '1111GG', '21', '1999-12-17')
) AS Source (name, surname, telephone_nr, postcode, [house number], date_of_birth)  
ON Target.name = Source.name  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (name, surname, telephone_nr, postcode, [house number], date_of_birth)
VALUES (name, surname, telephone_nr, postcode, [house number], date_of_birth);