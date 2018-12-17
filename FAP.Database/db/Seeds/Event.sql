MERGE INTO Event AS Target  
USING (values 
	(1, 1, 'De groene tuin', '2018-12-17', 454, 14, 'Heel gezellig', '4105VM', '21', 80),
	(2, 1, 'De Gele tuin', '2018-12-18', 423, 14, 'Heel gezellig', '4105VM', '21', 80),
	(3, 1, 'De Blauwe tuin', '2018-12-19', 232, 14, 'Heel gezellig', '4105VM', '21', 80),
	(4, 1, 'De Rode tuin', '2018-12-20', 25223, 14, 'Heel gezellig', '4105VM', '21', 80),
	(5, 1, 'De Paarse tuin', '2018-12-21', 1233, 14, 'Heel gezellig', '4105VM', '21', 80),
	(6, 1, 'De Witte tuin', '2018-12-22', 523, 14, 'Heel gezellig', '4105VM', '21', 80),
	(7, 1, 'De Zwarte tuin', '2018-12-23', 2324, 14, 'Heel gezellig', '4105VM', '21', 80)
) AS Source (Id, contact_id, name, date, amount_visitors, [surface area_m2], description, postcode, house_number, customer_id)  
ON Target.name = Source.name  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, contact_id, name, date, amount_visitors, [surface area_m2], description, postcode, house_number, customer_id)  
VALUES (Id, contact_id, name, date, amount_visitors, [surface area_m2], description, postcode, house_number, customer_id);