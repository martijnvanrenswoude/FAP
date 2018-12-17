MERGE INTO CONTACT AS Target  
USING (values 
	(80, 'Henk', 'Hendrik', 0623591563, 'Henk.Hendriks@live.nl')
) AS Source (customer_id, name, surname, telephone_nr, email)  
ON Target.customer_id = Source.customer_id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (customer_id, name, surname, telephone_nr, email)  
VALUES (customer_id, name, surname, telephone_nr, email);