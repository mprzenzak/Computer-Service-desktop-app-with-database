DROP USER 'employee'@'localhost';
DROP USER 'customer'@'localhost';
DROP TRIGGER BeforeInsertOnRepairsTrigger;
DROP TABLE Credentials;
DROP TABLE Repairs;
DROP TABLE PriceList;
DROP TABLE Services;
DROP TABLE Computers;
DROP TABLE Customers;


-- ------------------------------------------------------------------------------------------------------- Tables
CREATE TABLE Customers (
  `customer_id` varchar(7) unique NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `phone` integer DEFAULT NULL,
  PRIMARY KEY (`customer_id`)
);

CREATE TABLE Computers (
  `computer_id` integer unique NOT NULL AUTO_INCREMENT,
  `customer_id` varchar(7) NOT NULL,
  `system_name` varchar(255) DEFAULT NULL,
  `processor` varchar(255) NOT NULL,
  `motherboard` varchar(255) NOT NULL,
  `ram` varchar(255) NOT NULL,
  `graphics_card` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`computer_id`),
  CONSTRAINT `customer_id` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`)
);

CREATE TABLE Services (
  `service_id` varchar(7) unique NOT NULL,
  `service_location` varchar(255) NOT NULL,
  PRIMARY KEY (`service_id`)
);

CREATE TABLE PriceList (
  `repair_type` varchar(255) unique NOT NULL,
  `price` float NOT NULL,
  PRIMARY KEY (`repair_type`)
);

CREATE TABLE Repairs (
  `repair_id` integer unique NOT NULL AUTO_INCREMENT,
  `computer_id` int NOT NULL,
  `service_id` varchar(7) NOT NULL,
  `repair_type` varchar(255) NOT NULL,
  `filling_date` date NOT NULL,
  `end_date` date NOT NULL,
  PRIMARY KEY (`repair_id`),
  CONSTRAINT `computer_id` FOREIGN KEY (`computer_id`) REFERENCES `computers` (`computer_id`),
  CONSTRAINT `repair_type` FOREIGN KEY (`repair_type`) REFERENCES `pricelist` (`repair_type`),
  CONSTRAINT `service_id` FOREIGN KEY (`service_id`) REFERENCES `services` (`service_id`)
);

CREATE TABLE Credentials (
  `login` varchar(7) unique NOT NULL,
  `password` varchar(16) NOT NULL,
  PRIMARY KEY (`login`)
);

-- ------------------------------------------------------------------------------------------------------- Triggers
DELIMITER ;;
CREATE TRIGGER BeforeInsertOnRepairsTrigger BEFORE INSERT ON Repairs FOR EACH ROW
BEGIN
    SET NEW.filling_date = NOW();
END;;
DELIMITER ;


-- -------------------------------------------------------------------------------------------------------------------------------------- Users

-- ------------------------------------------------------------------------------------------------------- employee
CREATE USER 'employee'@'localhost' IDENTIFIED BY 'P@ssw0rd';
GRANT INSERT, UPDATE, SELECT ON computer_service.Computers TO 'employee'@'localhost' WITH GRANT OPTION;
GRANT INSERT, UPDATE, SELECT ON computer_service.Repairs TO 'employee'@'localhost' WITH GRANT OPTION;
GRANT SELECT ON computer_service.PriceList TO 'employee'@'localhost' WITH GRANT OPTION;
GRANT SELECT ON computer_service.Customers TO 'employee'@'localhost' WITH GRANT OPTION;
GRANT SELECT ON computer_service.Credentials TO 'employee'@'localhost' WITH GRANT OPTION;
GRANT SELECT ON computer_service.Services TO 'employee'@'localhost' WITH GRANT OPTION;


-- ------------------------------------------------------------------------------------------------------- Customer
CREATE USER 'customer'@'localhost' IDENTIFIED BY 'P@ssw0rd';
GRANT INSERT, UPDATE, SELECT ON computer_service.Customers TO 'customer'@'localhost' WITH GRANT OPTION;
GRANT SELECT ON computer_service.Repairs TO 'customer'@'localhost' WITH GRANT OPTION;
GRANT INSERT, SELECT ON computer_service.Credentials TO 'customer'@'localhost' WITH GRANT OPTION;
GRANT SELECT ON computer_service.PriceList TO 'customer'@'localhost' WITH GRANT OPTION;


-- -------------------------------------------------------------------------------------------------------------------------------------- Values

-- ------------------------------------------------------------------------------------------------------- Customers

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

UPDATE Customers
SET lastname = 'Majster', email = 'majster@wp.pl'
WHERE customer_id = 'K000007';


-- ------------------------------------------------------------------------------------------------------- Computers

INSERT INTO Computers(computer_id, customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES (0,'K000001','Windows 10','INTEGERelCorei7','AMD','ASUS','8gb');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000001','Windows 10','INTEGERelCorei7','AMD','ASUS','8gb');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000002','Windows XP','INTEGERelPentium','ASrock','4gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000001','Windows 8','INTEGERelCorei3','MSI','8gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000003','Windows 7','INTEGERelCorei7','MSI','16gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000004','Windows 10','INTEGERelCorei5','Gigabite','8gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000005','Windows 10','INTEGERelCorei7','MSI','8gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000006','Windows 11','INTEGERelCorei9','MSI','32gb','AMD');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000006','Windows Vista','INTEGERelCorei3','ASrock','4gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000007','Windows Vista','INTEGERelCorei5','ASrock','8gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000008','Windows XP','INTEGERelPentium','ASrock','4gb','Nvidia');

INSERT INTO Computers(customer_id,system_name,processor,motherboard,RAM,graphics_card)
VALUES ('K000009','Windows 11','INTEGERelCorei9','ASUS','16gb','Nvidia');


-- ------------------------------------------------------------------------------------------------------- Services

INSERT INTO Services(service_id,service_location)
VALUES ('P000001','Częstochowa');

INSERT INTO Services(service_id,service_location)
VALUES ('P000002','Warszawa');

INSERT 	 Services(service_id,service_location)
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


-- ------------------------------------------------------------------------------------------------------- PriceList

INSERT INTO PriceList(repair_type,price)
VALUES ('RAM',450.50);

INSERT INTO PriceList(repair_type,price)
VALUES ('motherboard',224.50);

INSERT INTO PriceList(repair_type,price)
VALUES ('processor',152.50);

INSERT INTO PriceList(repair_type,price)
VALUES ('graphics_card',480.50);


-- ------------------------------------------------------------------------------------------------------- Repairs

INSERT INTO Repairs(repair_id,computer_id,service_id,repair_type,end_date)
VALUES (0,1,'P000001','RAM','2022-02-12');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (2,'P000002','motherboard','2021-01-01');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (3,'P000003','processor','2022-12-03');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (4,'P000004','processor','2022-10-12');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (5,'P000005','graphics_card','2022-06-15');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (6,'P000006','motherboard','2022-04-15');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (7,'P000007','motherboard','2022-06-23');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (8,'P000008','processor','2022-03-14');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (9,'P000009','processor','2022-09-18');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (10,'P000010','graphics_card','2022-05-05');

INSERT INTO Repairs(computer_id,service_id,repair_type,end_date)
VALUES (11,'P000001','RAM','2022-06-06');


-- ------------------------------------------------------------------------------------------------------- Credentials

INSERT INTO Credentials(login,password)
VALUES ('P000001', 'P@ssw0rd');

INSERT INTO Credentials(login,password)
VALUES ('K000001', 'P@ssw0rd');