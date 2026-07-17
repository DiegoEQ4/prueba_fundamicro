create database clientes;
create table dbo.usuarios(
	id int IDENTITY(1,1)  primary key ,
	nombre_completo varchar(150) not null,
	username varchar(100) not null,
	pass varchar(max) not null
);
create table dbo.bitacora(
	id int IDENTITY(1,1)  primary key,
	action varchar(100),
	cliente_id int,
	fecha_hora DATETIME2,
	usuario varchar(100)
);
create table dbo.clientes(
	id int IDENTITY(1,1)  primary key,
	nombre varchar(150),
	apellido varchar(150),
	email varchar(250),
	direccion varchar(250)
)