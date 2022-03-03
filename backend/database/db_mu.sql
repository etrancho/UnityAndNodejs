drop database if exists db_mu;
create database db_mu;
use db_mu;

create table regalos(
	idR int(9) not null auto_increment primary key,
	nombreR varchar(30) not null,
	descripcionR varchar(1000) not null,
	precioR varchar(100) not null,
	createdAt datetime default current_timestamp,
    updatedAt datetime default current_timestamp
)engine=InnoDB;

INSERT INTO regalos VALUES 
(1,'Bracelet','Elastic silk ribbon bracelet / necklace in 3 colors (black, pink and blue) with 3 pendants: world, cross and starfish',
	'10€',default,default),
(2,'A5 notebook','Soft-touch notebook with soft cover',
	'10€',default,default),
(3,'Scarf / Foulard','Cotton touch fiber scarf with campaign motives in blue and pink tones',
	'10€',default,default),
(4,'Glass bottle','350 ml glass bottle with silicone sleeve. Reusable and perfect to take anywhere',
	'10€',default,default),
(5,'Masks','Pack of 2 double layer 100% cotton masks, washable up to 35 washes. They comply with the UNE-0065 standard',
	'10€',default,default),
(6,'Shopping bag','Practice shopping bag with campaign motives',
	'10€',default,default),
(7,'Bookmark child pages','Two brands of magnetic books for the little ones to enjoy reading',
	'10€',default,default),
(8,'2021 Calendars','12 phrases and photos that will remind us of the work of Manos Unidas in defense of the common good and solidarity',
	'10€',default,default),
(9,'2021 Agenda','Reflections and examples of the work of Manos Unidas through its projects in Africa, America and Asia for each month of the year',
	'10€',default,default);

CREATE TABLE users (
	id int NOT NULL AUTO_INCREMENT,
	username varchar(255) not null,
	password varchar(255) not null,
	isAdmin tinyint(1) DEFAULT NULL,
	createdAt datetime default current_timestamp,
	updatedAt datetime default current_timestamp,
	PRIMARY KEY (id)
) ENGINE=InnoDB;

INSERT INTO `users` VALUES (1,'eva','eva',1,default,default);

