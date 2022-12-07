USE [Computer Service]

CREATE TABLE Customers
(
    	customer_id 		VARCHAR(7) PRIMARY KEY NOT NULL,
    	firstname 			VARCHAR(255) NOT NULL,
    	lastname 			VARCHAR(255) NOT NULL,
		email 				VARCHAR(255) NOT NULL,
    	phone 				INT NULL
);

CREATE TABLE Computers
(
	computer_id 			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	customer_id 			VARCHAR(7) NOT NULL,
	system_name 			VARCHAR(255) NULL,
	processor 				VARCHAR(255) NOT NULL,
	motherboard 			VARCHAR(255) NOT NULL,
	RAM 					VARCHAR(255) NOT NULL,
	graphics_card 			VARCHAR(255) NULL,
	FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

CREATE TABLE Services
(
	service_id 				VARCHAR(7) PRIMARY KEY NOT NULL,
	service_location 		VARCHAR(255) NOT NULL,
);

CREATE TABLE PriceList
(
	repair_type				VARCHAR(255) PRIMARY KEY NOT NULL,
	price 					FLOAT(10) NOT NULL
);

CREATE TABLE Repairs
(
	repair_id 				INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	computer_id 			INT NOT NULL,
	service_id 				VARCHAR(7) NOT NULL,
	repair_type 			VARCHAR(255) NOT NULL,
	filing_date	 			DATETIMEOFFSET NOT NULL,
	end_date 				DATETIMEOFFSET NOT NULL,
	FOREIGN KEY (computer_id) REFERENCES Computers(computer_id),
	FOREIGN KEY (service_id) REFERENCES Services(service_id),
	FOREIGN KEY (repair_type) REFERENCES PriceList(repair_type)
);

CREATE TABLE Credentials
(
	login 		VARCHAR(7) PRIMARY KEY NOT NULL,
	password 	VARCHAR(8) NOT NULL,
);


INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000001','Jacek','Alacek','123456789','a@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000002','Jacek','Blacek','223456789','b@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000003','Jacek','Clacek','323456789','c@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000004','Jacek','Dlacek','423456789','d@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000005','Jacek','Elacek','523456789','e@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000006','Jacek','Flacek','623456789','f@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000007','Jacek','Glacek','723456789','g@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000008','Zosia','Samosia','823456789','z@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,email)
VALUES ('K000009','Mikołaj','Święty','m@gmail.com');

INSERT INTO Customers(customer_id,firstname,lastname,phone,email)
VALUES ('K000010','Mateusz','Placek','133356789','mat@gmail.com');



INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000001','Windows 10','IntelCorei7','AMD','ASUS','8gb');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000002','Windows XP','IntelPentium','ASrock','4gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000001','Windows 8','IntelCorei3','MSI','8gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000003','Windows 7','IntelCorei7','MSI','16gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000004','Windows 10','IntelCorei5','Gigabite','8gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000005','Windows 10','IntelCorei7','MSI','8gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000006','Windows 11','IntelCorei9','MSI','32gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000006','Windows Vista','IntelCorei3','ASrock','4gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000007','Windows Vista','IntelCorei5','ASrock','8gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000008','Windows XP','IntelPentium','ASrock','4gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000009','Windows 11','IntelCorei9','ASUS','16gb','Nvidia');


INSERT INTO Services(service_id,service_location)
VALUES ('P000001','Częstochowa');

INSERT INTO Services(service_id,service_location)
VALUES ('P000002','Warszawa');

INSERT INTO Services(service_id,service_location)
VALUES ('P000003','Kraków');

INSERT INTO Services(service_id,service_location)
VALUES ('P000004','Gdańsk');

INSERT INTO Services(service_id,service_location)
VALUES ('P000005','Gdynia');

INSERT INTO Services(service_id,service_location)
VALUES ('P000006','Szczecin');

INSERT INTO Services(service_id,service_location)
VALUES ('P000007','Łódź');

INSERT INTO Services(service_id,service_location)
VALUES ('P000008','Kielce');

INSERT INTO Services(service_id,service_location)
VALUES ('P000009','Kędzierzyn-Koźle');

INSERT INTO Services(service_id,service_location)
VALUES ('P000010','Leszno');


INSERT INTO PriceList(repair_type,price)
VALUES ('RAM',450.50);

INSERT INTO PriceList(repair_type,price)
VALUES ('motherboard',224.50);

INSERT INTO PriceList(repair_type,price)
VALUES ('processor',152.50);

INSERT INTO PriceList(repair_type,price)
VALUES ('graphics_card',480.50);



INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (5,'P000001','RAM','01-JUN-2022','10-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (1,'P000002','motherboard','05-JUN-2022','10-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (2,'P000003','processor','05-JUN-2022','10-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (3,'P000004','processor','08-JUN-2022','15-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (4,'P000005','graphics_card','17-JUN-2022','21-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (6,'P000006','motherboard','20-JUN-2022','23-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (7,'P000007','motherboard','20-JUN-2022','24-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (8,'P000008','processor','21-JUN-2022','25-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (9,'P000009','processor','22-JUN-2022','29-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (10,'P000010','graphics_card','24-JUN-2022','28-JUN-2022');

INSERT INTO Repairs(computer_id,service_id,repair_type,filing_date,end_date)
VALUES (11,'P000001','RAM','27-JUN-2022','30-JUN-2022');



INSERT INTO Credentials(login,password)
VALUES ('P000001', 'P@ssw0rd');

INSERT INTO Credentials(login,password)
VALUES ('K000001', 'P@ssw0rd');
