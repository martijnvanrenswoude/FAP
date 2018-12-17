MERGE INTO Customer AS Target  
USING (values 
	('Frenk Hendrik', 0621341557, '6883GZ', '21', 'Frenk.Hendriks@outlook.com' ),
	('Piet Spek', 0649147821, '4999KK', '13', 'Piet.Spekkie@live.nl' ),
	('Hassan Janssen', 0666666666, '1234QQ', '5', 'Hassan.voetbal12@live.com' ),
	('Jo Bonten', 0123312357, '4012MM', '49', 'Jo.BontenB@outlook.com' ),
	('Sanne de Kat', 0155512357, '9999ZZ', '14', 'Katers@live.nl' ),
	('Donald Obama', 123456789, '5000AA', '2', 'Donald.Trump@live.nl' ),
	('Barack Trump', 0987765412, '5000AA', '3', 'Barack.Obama@live.nl' )
) AS Source (name, telephone_nr, postcode, [house number], email)  
ON Target.name = Source.name  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (name, telephone_nr, postcode, [house number], email)  
VALUES (name, telephone_nr, postcode, [house number], email);