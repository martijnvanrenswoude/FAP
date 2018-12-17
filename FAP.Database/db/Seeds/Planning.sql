MERGE INTO Planning AS Target  
USING (values 
	(80, 1, 1, '2018-12-17', 1),
	(80, 2, 1, '2018-12-18', 2),
	(80, 3, 1, '2018-12-19', 3),
	(80, 4, 2, '2018-12-20', 4),
	(80, 5, 2, '2018-12-21', 5),
	(80, 6, 3, '2018-12-22', 6),
	(80, 7, 3, '2018-12-23', 7)
) AS Source (customer_id, event_id, questionnaire_id, start_date, employee_id)  
ON Target.customer_id = Source.customer_id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (customer_id, event_id, questionnaire_id, start_date, employee_id)  
VALUES (customer_id, event_id, questionnaire_id, start_date, employee_id);