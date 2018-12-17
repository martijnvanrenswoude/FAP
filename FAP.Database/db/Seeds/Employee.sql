MERGE INTO Employee AS Target  
USING (values 
	(1, 'Joris', 'Geffen', 1, 'Dit is zelfde als department?', '4101VM', 13, '1996-5-9'),
	(2, 'Henk', 'Maahboob', 1, 'Dit is zelfde als department?', '1111AA', 5, '1946-5-9'),
	(3, 'Jan', 'Janssen', 1, 'Dit is zelfde als department?', '2222BB', 12, '1956-5-9'),
	(1, 'Piet', 'Klaas', 1, 'Dit is zelfde als department?', '3333CC', 33, '1966-5-9'),
	(4, 'Gerrit', 'Geritsen', 1, 'Dit is zelfde als department?', '4444DD', 55, '1998-5-9'),
	(4, 'Liza', 'Loos', 1, 'Dit is zelfde als department?', '5555EE', 74, '2001-5-9'),
	(4, 'Irene', 'Webson', 1, 'Dit is zelfde als department?', '6666GG', 89, '1936-5-9')
) AS Source (department_id, name, surname, [acces level], position, postcode, [house number], date_of_birth) 
ON Target.name = Source.name  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (department_id, name, surname, [acces level], position, postcode, [house number], date_of_birth)  
VALUES (department_id, name, surname, [acces level], position, postcode, [house number], date_of_birth);