create schema patientsdb;
use patientsdb;
create table patients(
	id INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(45) NOT NULL,
    lastname VARCHAR(45) NOT NULL,
    email VARCHAR(255) NOT NULL,
    dni VARCHAR(10) NOT NULL,
    phone VARCHAR(44),
    address VARCHAR(255),
    blood VARCHAR(3) NOT NULL,
    age int NOT NULL,
    height VARCHAR(6),
    weight VARCHAR(5),
    isSmooker bool,
    isDrinker bool
);