USE [Computer_Service]

CREATE TABLE Klienci
(
    	client_id 			INT NOT NULL,
    	firstname 				VARCHAR(30) NOT NULL,
    	lastname 			VARCHAR(60) NOT NULL,
    	phone 	INT NOT NULL,
	email 			VARCHAR(30)NULL,
	PRIMARY KEY (client_id)
);

CREATE TABLE Komputery
(
	computer_id 		INT NOT NULL,
	client_id 			INT NOT NULL,
	model 			VARCHAR(30) NOT NULL,
	system_name 			VARCHAR(30) NULL,
	processor 			VARCHAR(30) NOT NULL,
	graphic_card 		VARCHAR(30) NULL,
	motherboard 		VARCHAR(30) NOT NULL,
	RAM 				VARCHAR(30) NOT NULL,
	PRIMARY KEY (computer_id),
	FOREIGN KEY (client_id) REFERENCES Klienci(client_id)
);

CREATE TABLE Serwis_naprawczy
(
	service_id 			INT NOT NULL,
	client_id 			INT NOT NULL,
	service_location 		VARCHAR(30) NOT NULL,
	employee 			VARCHAR(30) NOT NULL,
	PRIMARY KEY (service_id)
);

CREATE TABLE Naprawy
(
	repair_id 			INT NOT NULL,
	computer_id 		INT NOT NULL,
	client_id 			INT NOT NULL,
	issue 			VARCHAR(30) NOT NULL,
	time_required 		DATE NOT NULL,
	backup_required 			BIT NOT NULL,
	PRIMARY KEY (repair_id),
	FOREIGN KEY (computer_id) REFERENCES Komputery(computer_id),
	FOREIGN KEY (client_id) REFERENCES Klienci(client_id)
);

CREATE TABLE Cennik
(
	repair_id 			INT NOT NULL,
	price 		INT NOT NULL,
	margin 			NUMERIC(6,2) NOT NULL,
	PRIMARY KEY (repair_id),
	FOREIGN KEY(repair_id) REFERENCES Naprawy(repair_id)
);

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (1,'Jacek','Alacek','123456789','a@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (2,'Jacek','Blacek','223456789','b@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (3,'Jacek','Clacek','323456789','c@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (4,'Jacek','Dlacek','423456789','d@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (5,'Jacek','Elacek','523456789','e@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (6,'Jacek','Flacek','623456789','f@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (7,'Jacek','Glacek','723456789','g@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (8,'Zosia','Samosia','823456789','z@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (9,'Mikołaj','Święty','923456789','m@gmail.com');

INSERT INTO Klienci(client_id,firstname,lastname,phone,email)
VALUES (10,'Mateusz','Placek','133356789','mat@gmail.com');



INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (1,1,'ASUS','Windows 10','IntelCorei7','AMD','ASUS','8gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (2,1,'Lenovo','Windows XP','IntelPentium','Nvidia','ASrock','4gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (3,2,'HP','Windows 10','IntelCorei3','AMD','MSI','8gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (4,3,'Acer','Windows 7','IntelCorei7','AMD','MSI','16gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (5,4,'Dell','Windows 10','IntelCorei5','Nvidia','Gigabite','8gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (6,5,'ASUS','Windows 10','IntelCorei7','AMD','MSI','8gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (7,6,'Lenovo','Windows 11','IntelCorei9','AMD','MSI','32gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (8,7,'Acer','Windows Vista','IntelCorei3','Nvidia','ASrock','4gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (9,8,'HP','Windows Vista','IntelCorei5','Nvidia','ASrock','8gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (10,9,'Acer','Windows XP','IntelPentium','Nvidia','ASrock','4gb');

INSERT INTO Komputery(computer_id,client_id,model,system_name,processor,graphic_card,motherboard,RAM)
VALUES (11,10,'ASUS','Windows 11','IntelCorei9','Nvidia','ASUS','16gb');


INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (1,1,'Częstochowa','Jessica Polanski');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (2,2,'Warszawa','Mateusz Trąbka');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (3,3,'Kraków','Jurij Gagarin');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (4,4,'Kraków','Andrzej Piaseczny');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (5,5,'Kraków','Sławomir Peszko');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (6,6,'Warszawa','Mateusz Puzon');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (7,7,'Wrocław','Zosia Samosia');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (8,8,'Warszawa','Mateusz Kontrabas');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (9,9,'Kędzierzyn-Koźle','Robert Pasut');

INSERT INTO Serwis_naprawczy(service_id,client_id,service_location,employee)
VALUES (10,10,'Leszno','Patryk Zielonka');



INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (1,1,1,'płyta głowna','05-JUN-2022',1);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (2,2,1,'processor','05-JUN-2022',1);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (3,3,2,'processor','08-JUN-2022',1);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (4,4,3,'karta graficzna','17-JUN-2022',0);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (5,5,4,'RAM','01-JUN-2022',0);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (6,6,5,'płyta głowna','03-JUN-2022',1);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (7,7,6,'płyta głowna','15-JUN-2022',1);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (8,8,7,'processor','13-JUN-2022',1);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (9,9,8,'processor','18-JUN-2022',1);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (10,10,9,'karta graficzna','07-JUN-2022',0);

INSERT INTO Naprawy(repair_id,computer_id,client_id,issue,time_required,backup_required)
VALUES (11,11,10,'RAM','01-JUN-2022',0);




INSERT INTO Cennik(repair_id,price,margin)
VALUES (1,800,450.50);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (2,400,224.50);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (3,800,450.50);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (4,300,152.50);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (5,600,310.00);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (6,900,480.50);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (7,800,410.00);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (8,900,480.50);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (9,200,110.00);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (10,720,373.50);

INSERT INTO Cennik(repair_id,price,margin)
VALUES (11,350,184.50);
