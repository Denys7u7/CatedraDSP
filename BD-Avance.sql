create database SparesDSP;
GO

use SparesDSP;
GO

create table tipo_user(
	id int primary key identity(1,1),
	tipo nvarchar(30) not null
);
GO

create table users(
	id int primary key identity(1,1),
	DUI int unique,
	nomUser nvarchar(30) unique not null,
	pass nvarchar(30) not null,
	nombre varchar(75) not null,
	email varchar(60) not null unique,
	telefono int unique not null,
	tipo nvarchar(30) not null,
	/*id_tipo int,
	CONSTRAINT fk_tipo_usuario FOREIGN KEY (id_tipo) REFERENCES tipo_user(id)*/
);
GO

insert into tipo_user values('administrador');
insert into tipo_user values('cliente');

create proc insertarUsuario
(
@DUI int,
@nomUsuario nvarchar(30),
@password nvarchar(30),
@nombre varchar(75),
@email varchar(60),
@telefono int,
@tipo nvarchar(30)
) with encryption as
begin
	insert into users ([DUI], [nomUser], [pass], [nombre],[email],[telefono],[tipo]) values (@DUI, @nomUsuario, ENCRYPTBYPASSPHRASE('password', @password), @nombre, @email, @telefono, @tipo);
end
GO

create proc mostrarUsuarios
with encryption as
begin
	select * from users;
end
GO

create proc editarUsuario (
@DUI int,
@nomUsuario nvarchar(30),
@password nvarchar(30),
@nombre varchar(75),
@email varchar(60),
@telefono int,
@tipo nvarchar(30),
@id int
) with encryption as
begin
	update users set DUI = @DUI, nomUser = @nomUsuario, pass = ENCRYPTBYPASSPHRASE('password', @password), nombre = @nombre, email = @email, telefono = @telefono, tipo = @tipo where id=@id;
end
GO

create proc eliminarUsuario (
@id int
) with encryption as
begin
	delete users where id = @id;
end
GO

create proc buscarUser
(
@nomUser nvarchar(30),
@pass nVarchar(30)
) with encryption as
begin
	select * from users where nomUser = @nomUser AND CONVERT(VARCHAR(30), DECRYPTBYPASSPHRASE('password', pass)) = @pass;
end
GO

execute insertarUsuario 12345678,'Denys7u7','gatitoxd','Denys Enrique Cruz','dennyscruz20@gmail.com',75074903,'administrador';
execute insertarUsuario 12345679,'DenysX2','gatitoxd','Denys Enrique Cruz','kikecruz247@gmail.com',75354857,'vendedor';

exec buscarUser 'Denys7u7','gatitoxd';
exec buscarUser 'DenysX2', 'gatitoxd';

select * from users where pass = '';


create table producto(
	id int primary key identity(1,1),
	nombreProducto varchar(30) unique not null,
	descripcion varchar(30) not null,
	categoria varchar(30) not null,
	marca varchar(30) not null,
	catidadExistentes int not null,
	precio money not null,
);
GO

create proc insertarProducto(
@nombre varchar(30),
@descripcion varchar(30),
@categoria varchar(30),
@marca varchar(30),
@cantidad int,
@precio money
) with encryption as
begin
	insert into producto ([nombreProducto],[descripcion],[categoria],[marca],[catidadExistentes],[precio])
	values (@nombre,@descripcion,@categoria,@marca,@cantidad,@precio)
end
GO

exec insertarProducto 'culata FR','Culata nueva para Ford Ranger','Carroseria','Ford', 11, 35.55;
exec insertarProducto 'Culata TOYOTA','Culata nueva para Hilux','Carroseria','Toyota', 17, 50.55;
exec insertarProducto 'Puerta Mitsubishi','Puerta para Mitsubishi Lancer','Carroseria','Mitsubishi', 5, 75.00;
exec insertarProducto 'Radio Hyundai','Radio nueva para Hyundai Elantra','Electronica','Hyundai', 3, 35.55;
exec insertarProducto 'Camara Nissa','Camara para Nissan Frontier','Electronica','Nissan', 7, 60.35;
exec insertarProducto 'llantas FR','Llantas en buen estado para Ford Ranger','Carroseria','Ford', 15, 225.55;
exec insertarProducto 'Transistores TOYOTA','Transistores para Hilux','Electrico','Toyota', 11, 12.00;
exec insertarProducto 'Inyectores Mitsubishi','Inyectores para Mitsubishi Lancer','Hidrahulico','Mitsubishi', 8, 65.00;
exec insertarProducto 'Resistencias Hyundai','Resistencias nuevas para Hyundai Elantra','Electronica','Hyundai', 55, 12.00;
exec insertarProducto 'Luces traseras Nissan','Stops para Nissan Frontier','Electronica','Nissan', 65, 25.00;

create view vistaProductos
with encryption as select id, nombreProducto as Nombre,descripcion,categoria,marca,catidadExistentes as Cantidad, precio as Precio
from producto;
GO

select * from vistaProductos;

create proc mostrarProducto
with encryption as
begin
	select * from vistaProductos;
end
GO

exec mostrarProducto;

create proc buscarProducto
(
@var varchar(30)
) with encryption as
begin
	select * from vistaProductos where Nombre LIKE '%'+@var+'%' OR descripcion LIKE '%'+@var+'%' OR categoria LIKE '%'+@var+'%' OR marca LIKE '%'+@var+'%';
end
GO
/*drop proc buscarProducto;*/
exec buscarProducto 'Carro';

create proc eliminarProducto
@idpro int
as
delete from producto where id = @idpro
GO

exec eliminarProducto 5;

create proc editarProductos
@nombre varchar(30),
@descripcion varchar(30),
@categoria varchar(30),
@marca varchar(30),
@cantidad int,
@precio money,
@id int
with encryption as
update producto set nombreProducto=@nombre, descripcion=@descripcion, marca=@marca, catidadExistentes=@cantidad, precio=@precio where id=@id
GO

exec editarProductos 'Culata FordRanger','Culata en buen estado 10 de 10','Carroseria','Ford',9,40,1;