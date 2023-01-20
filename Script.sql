CREATE DATABASE DBPRUEBA2;

USE DBPRUEBA2;

CREATE TABLE USUARIO(
	IdUsuario int primary key identity,
	NombreUsuario varchar(50),
	Correo varchar(50),
	Clave varchar(100)
);

SELECT * FROM USUARIO;
