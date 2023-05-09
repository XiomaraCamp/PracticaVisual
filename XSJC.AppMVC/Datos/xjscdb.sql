create database XJSC

use XJSC

create table Bicicletas(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Modelo varchar(40) NOT NULL,
	Tipo varchar(40) NOT NULL,
	Descripcion_del_problema varchar(50) NOT NULL,
)