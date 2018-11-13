create database SparesDSP
GO

use SparesDSP
GO

create table genero
(
	id int primary key identity,
	Genero varchar(50) not null unique
);
GO

create table departamento
(
	id int primary key identity,
	Departamento varchar(50) not null unique
);
GO

create table municipio
(
	id int primary key identity,
	Municipio varchar(50) not null unique,
	Departamento int not null,
	constraint fk_departamento_municipio foreign key (Departamento) references departamento(id)
);
GO

create table empleado
(
	id int primary key identity,
	[Nombre de Empleado] varchar(50) not null,
	[Correo electronico] varchar(75) unique,
	[DUI] int not null unique,
	[Genero] int not null,
	Municipio int not null,
	constraint fk_municipio foreign key (Municipio) references municipio(id) On Update Cascade On Delete Cascade,
	constraint fk_genero foreign key ([Genero]) references genero(id) On Update Cascade On Delete Cascade
);
GO

create table tipoUsuario
(
	id int primary key identity,
	[Tipo de usuario] varchar(25) not null,
);
GO

create table usuario
(
	id int primary key identity,
	[Nombre de usuario] varchar(50) not null unique,
	[Contrasenya] varchar(30) not null,
	Tipo int not null,
	Empleado int not null unique,
	constraint fk_empleado_usuario foreign key (Empleado) references empleado(id) On Update Cascade On Delete Cascade,
	constraint fk_tipo_usuario foreign key (Tipo) references tipoUsuario (id) On Update Cascade On Delete Cascade
);
GO

create table categoria
(
	id int primary key identity,
	Categoria varchar(60) not null unique,
);
GO

create table marca
(
	id int primary key identity,
	Marca varchar(50) not null unique,
);
GO

create table proveedor
(
	id int primary key identity,
	Proveedor varchar(50) not null unique,
	[Correo electronico] varchar(75) not null unique,
	Telefono int not null unique,
);
GO

create table producto
(
	id int primary key identity,
	[Nombre de producto] varchar(60) not null,
	[Descripcion] varchar(150) not null,
	imagen image not null,
	Proveedor int not null,
	Receptor int not null,
	[Fecha de Ingreso] as CURRENT_TIMESTAMP,
	Categoria int not null,
	Marca int not null,
	Cantidad int not null,
	[Precio de compra] money not null,
	[Precio de venta] as [Precio de compra] * 0.20 + [Precio de compra],
	constraint fk_proveedor foreign key (Proveedor) references proveedor (id) On Update Cascade On Delete Cascade,
	constraint fk_categoria foreign key (Categoria) references categoria(id) On Update Cascade On Delete Cascade,
	constraint fk_marca foreign key (Marca) references marca (id) On Update Cascade On Delete Cascade,
	constraint fk_receptor_empleado foreign key (Receptor) references empleado(id) on Update Cascade on Delete Cascade
);
GO

-----------------------GENEROS-----------------------
insert into genero values ('Masculino');
insert into genero values ('Femenino');


-----------------------DEPARTAMENTOS-----------------------
insert into departamento values ('San Salvador');
insert into departamento values ('Ahuachapan');
insert into departamento values ('Sonsonate');
insert into departamento values ('Santa Ana');
insert into departamento values ('Cabañas');
insert into departamento values ('Chalatenango');
insert into departamento values ('Cuscatlan');
insert into departamento values ('La Libertad');
insert into departamento values ('La paz');
insert into departamento values ('San Vicente');
insert into departamento values ('Morazan');
insert into departamento values ('Usulutan');
insert into departamento values ('San Miguel');
insert into departamento values ('La Union');

select * from departamento order by id
GO


-----------------------MUNICIPIOS-----------------------

select * from municipio join departamento on municipio.Departamento = departamento.id order by municipio.Municipio
GO

--SAN SALVADOR ID:1
insert into municipio values ('San Martin',1);
insert into municipio values ('Soyapango',1);
insert into municipio values ('Apopa',1);
insert into municipio values ('San Marcos',1);
insert into municipio values ('Ciudad Delgado',1);
insert into municipio values ('Ilopango',1);
insert into municipio values ('San Salvador',1);

--AHUACHAPAN ID:2
insert into municipio values ('Apaneca',2);
insert into municipio values ('Concepcion de Ataco',2);
insert into municipio values ('Turin',2);
insert into municipio values ('San Lorenzo',2);
insert into municipio values ('Tacuba',2);
insert into municipio values ('Guaymango',2);

--SONSONATE ID:3
insert into municipio values ('Acajutla',3);
insert into municipio values ('Armenia',3);
insert into municipio values ('Caluco',3);
insert into municipio values ('Izalco',3);
insert into municipio values ('Nahulingo',3);
insert into municipio values ('San Julian',3);

--SANTA ANA ID:4
insert into municipio values ('El Congo',4);
insert into municipio values ('Chalchuapa',4);
insert into municipio values ('Santa Ana',4);
insert into municipio values ('Masahuat',4);
insert into municipio values ('Metapan',4);
insert into municipio values ('Coatepeque',4);

--CABAÑAS ID:5
insert into municipio values ('Cinquera',5);
insert into municipio values ('Dolores',5);
insert into municipio values ('Ilobasco',5);
insert into municipio values ('Jutiapa',5);
insert into municipio values ('San Isidro',5);
insert into municipio values ('Sensuntepeque',5);

--CHALATENANGO ID:6
insert into municipio values ('Agua Caliente',6);
insert into municipio values ('Arcatao',6);
insert into municipio values ('Azacualpa',6);
insert into municipio values ('Citala',6);
insert into municipio values ('Comalapa',6);
insert into municipio values ('La Palma',6);

--CUSCATLAN ID:7
insert into municipio values ('Candelaria',7);
insert into municipio values ('El Carmen',7);
insert into municipio values ('El Rosario',7);
insert into municipio values ('Suchitoto',7);
insert into municipio values ('Tenancingo',7);
insert into municipio values ('San Rafael Cedros',7);

--LA LIBERTAD ID:8
insert into municipio values ('Antiguo Cuscatlan',8);
insert into municipio values ('Santa Tecla',8);
insert into municipio values ('Jicalapa',8);
insert into municipio values ('San Juan Opico',8);
insert into municipio values ('Quezaltepeque',8);
insert into municipio values ('Tamanique',8);

--LA PAZ ID:9
insert into municipio values ('Olocuilta',9);
insert into municipio values ('Jerusalen',9);
insert into municipio values ('Cuyultitan',9);
insert into municipio values ('San Pedro Nonualco',9);
insert into municipio values ('San Pedro Masahuat',9);
insert into municipio values ('San Luis Talpa',9);

--SAN VICENTE ID:10
insert into municipio values ('Apastepeque',10);
insert into municipio values ('Guadalupe',10);
insert into municipio values ('Santo Domingo',10);
insert into municipio values ('San Sebastian',10);
insert into municipio values ('San Vicente',10);
insert into municipio values ('Verapaz',10);

--MORAZAN ID:11
insert into municipio values ('Arambala',11);
insert into municipio values ('Chilanga',11);
insert into municipio values ('El Divisadero',11);
insert into municipio values ('Jocoro',11);
insert into municipio values ('Perquin',11);
insert into municipio values ('Yamabal',11);

--USULUTAN ID:12
insert into municipio values ('Berlin',12);
insert into municipio values ('California',12);
insert into municipio values ('El triunfo',12);
insert into municipio values ('Jiquilisco',12);
insert into municipio values ('Jucuapa',12);
insert into municipio values ('Tecapan',12);

--SAN MIGUEL ID:13
insert into municipio values ('Ciudad Barrios',13);
insert into municipio values ('Moncagua',13);
insert into municipio values ('Lolotique',13);
insert into municipio values ('Nueva Guadalupe',13);
insert into municipio values ('San Miguel',13);
insert into municipio values ('Uluazapa',13);

--LA UNION ID:14
insert into municipio values ('Anamoros',14);
insert into municipio values ('Conchagua',14);
insert into municipio values ('Pasaquina',14);
insert into municipio values ('La Union',14);
insert into municipio values ('Yucuaiquin',14);
insert into municipio values ('San Alejo',14);


-----------------------EMPLEADOS-----------------------

select empleado.id, [Nombre de Empleado],[Correo electronico],DUI,genero.Genero, municipio.Municipio, departamento.Departamento from empleado
join genero on empleado.Genero = genero.id join municipio on empleado.Municipio = municipio.id join departamento on municipio.Departamento = departamento.id;
GO

insert into empleado values ('Denys Enrique Cruz Inestroza','dennyscruz20@gmail.com',45632125,1,1);
insert into empleado values ('Carlos Ariel Prez Bautista','necrarlos@gmail.com',45327865,1,5);
insert into empleado values ('Ignacion Bladimir Vidal Herrera','nachoherrera@gmail.com',21325487,1,1);
insert into empleado values ('Steeven Enrique Cruz Sosa','tytyuwu@gmail.com',54878954,1,7);
insert into empleado values ('Luis Miguel Hernandez Aquino','lmiguel7u7@gmail.com',96254752,1,7);
insert into empleado values ('Mireya Elizabeth Henriquez Perez','mireyaeli@gmail.com',75123456,2,5);
insert into empleado values ('Daniel Alexander Perez Prez','danialex@hotmail.com',65124536,1,45);
insert into empleado values ('Carlos Bladimir Hernandez Perez','carloshern@hotmail.com',56421378,1,46);
insert into empleado values ('William Roberto Perez Lopez','wilper@yahoo.com',32165478,1,7);
insert into empleado values ('Everaldo Vinicio Hernandez','evernandz@gmail.com',54621336,1,1);
GO

select * from empleado;
GO

create proc insertar_empleado
(
@nombre varchar(50),
@correo varchar(75),
@DUI int,
@genero int,
@municipio int
) as
begin
	insert into empleado values (@nombre,@correo,@DUI,@genero,@municipio);
end
GO

create proc modificar_empleado
(
@nombre varchar(50),
@correo varchar(75),
@DUI int,
@genero int,
@municipio int,
@id int
) as
begin
	update empleado set [Nombre de Empleado]=@nombre, [Correo electronico]=@correo,DUI=@DUI,Genero=@genero,Municipio=@municipio where id=@id;
end
GO

create proc eliminar_empleado
(
@id int
) as
begin
	delete from empleado where id=@id;
end
GO

create proc buscar_empleado
(
@busq varchar(75)
) as
begin
	select empleado.id, [Nombre de Empleado] as Empleado,[Correo electronico] as [E-mail],DUI,genero.Genero, municipio.Municipio, departamento.Departamento from empleado
	join genero on empleado.Genero = genero.id join municipio on empleado.Municipio = municipio.id join departamento on municipio.Departamento = departamento.id
	where empleado.id LIKE '%'+@busq+'%' OR [Nombre de Empleado] LIKE '%'+@busq+'%' OR [Correo electronico] LIKE '%'+@busq+'%' OR DUI LIKE '%'+@busq+'%'
	OR genero.Genero LIKE '%'+@busq+'%' OR municipio.Municipio LIKE '%'+@busq+'%' OR departamento.Departamento LIKE '%'+@busq+'%' order by [Nombre de Empleado]
end
GO

create proc mostrar_empleado
as
begin
	select empleado.id, [Nombre de Empleado] as Empleado,[Correo electronico] as [E-mail],DUI,genero.Genero, municipio.Municipio, departamento.Departamento from empleado
	join genero on empleado.Genero = genero.id join municipio on empleado.Municipio = municipio.id join departamento on municipio.Departamento = departamento.id;
end
GO

exec mostrar_empleado
exec insertar_empleado 'Kenia Elizabeth Rosa Lara','kendraliza@gmail.com',65431237,2,69;
exec modificar_empleado 'Kenia Elizabeth Lara Sosa','kendrasosa@yahoo.com',65431237,2,70,23;
exec eliminar_empleado 23;
exec buscar_empleado 'Kenia';


-----------------------TIPO DE USUARIOS-----------------------


select * from tipoUsuario;
GO

insert into tipoUsuario values ('administrador');
insert into tipoUsuario values ('usuario');


-----------------------USUARIOS-----------------------

select * from usuario;
GO

create proc logearse
(
@usuario varchar(50),
@pass nvarchar(30)
) as
begin
	select * from usuario where [Nombre de usuario]=@usuario AND Contrasenya = @pass;
end
GO

create proc insertar_usuario
(
@usuario varchar(50),
@pass varchar(30),
@tipo int,
@empleado int
) with encryption as
begin
	insert into usuario values (@usuario, @pass, @tipo, @empleado);
end
GO

create proc modificar_usuario
(
@usuario varchar(50),
@pass varchar(30),
@tipo int,
@empleado int,
@id int
) as
begin
	update usuario set [Nombre de usuario]=@usuario, Contrasenya=@pass, Tipo=@tipo, Empleado=@empleado where id=@id;
end
GO

create proc eliminar_usuario
(
@id int
) as
begin
	delete from usuario where id=@id
end
GO

create proc buscar_usuario
(
@busq varchar(50)
) as
begin
	select usuario.id, usuario.[Nombre de usuario] as Usuario, usuario.Contrasenya as Contraseña, tipoUsuario.[Tipo de usuario], empleado.[Nombre de Empleado] as Empleado
	from usuario join tipoUsuario on usuario.Tipo = tipoUsuario.id join empleado on usuario.Empleado = empleado.id
	where usuario.[Nombre de usuario] LIKE '%'+@busq+'%' OR usuario.id LIKE '%'+@busq+'%' OR empleado.[Nombre de Empleado] LIKE '%'+@busq+'%' OR [Tipo de usuario] LIKE '%'+@busq+'%';
end
GO

create proc mostrar_usuario
as
begin
	select usuario.id, usuario.[Nombre de usuario] as Usuario, usuario.Contrasenya as Contraseña, tipoUsuario.[Tipo de usuario], empleado.[Nombre de Empleado] as Empleado
	from usuario join tipoUsuario on usuario.Tipo = tipoUsuario.id join empleado on usuario.Empleado = empleado.id;
end
GO

exec insertar_usuario 'denys7u7','admin',1,1;
exec modificar_usuario 'denys','123',1,1,4;
exec eliminar_usuario 1;
exec buscar_usuario 'en';
exec mostrar_usuario;
exec logearse 'denys','123';



-----------------------CATEGORIAS-----------------------



select * from categoria
GO

create proc insertar_categoria
(
@categoria varchar(60)
) as
begin
	insert into categoria values (@categoria);
end
GO

create proc modificar_categoria
(
@categoria varchar(60),
@id int
) as
begin
	update categoria set Categoria=@categoria where id=@id
end
GO

create proc eliminar_categoria
(
@id int
) as
begin
	delete from categoria where id=@id
end
GO

create proc mostrar_categoria
as
begin
	select * from categoria;
end
GO

create proc buscar_categoria
(
@busq varchar(60)
)
as
begin
	select * from categoria where Categoria LIKE '%'+@busq+'%' OR id LIKE '%'+@busq+'%'
end

exec insertar_categoria 'Electronico';
exec insertar_categoria 'Mecanico';
exec modificar_categoria 'Electrico',1;
exec eliminar_categoria 1;
exec mostrar_categoria;
exec buscar_categoria 'an';


-----------------------MARCA-----------------------

select * from marca
GO

create proc insertar_marca
(
@marca varchar(60)
) as
begin
	insert into marca values (@marca);
end
GO

create proc modificar_marca
(
@marca varchar(60),
@id int
) as
begin
	update marca set Marca=@marca where id=@id
end
GO

create proc eliminar_marca
(
@id int
) as
begin
	delete from marca where id=@id
end
GO

create proc mostrar_marca
as
begin
	select * from marca order by id;
end
GO

create proc buscar_marca
(
@busq varchar(60)
)
as
begin
	select * from marca where Marca LIKE '%'+@busq+'%' OR id LIKE '%'+@busq+'%' order by id
end
GO

exec insertar_marca 'FOrd';
exec insertar_marca 'Toyota';
exec modificar_marca 'Ford',1;
exec eliminar_marca 1;
exec mostrar_marca;
exec buscar_marca '2';


-----------------------PROVEDOR-----------------------

select * from proveedor
GO

create proc insertar_proveedor
(
@proveedor varchar(50),
@correo varchar(75),
@telefono int
) as
begin
	insert into proveedor values (@proveedor,@correo,@telefono);
end
GO

create proc modificar_proveedor
(
@proveedor varchar(50),
@correo varchar(75),
@telefono int,
@id int
) as
begin
	update proveedor set Proveedor=@proveedor, [Correo electronico]=@correo,Telefono=@telefono where id=@id
end
GO

create proc eliminar_proveedor
(
@id int
) as
begin
	delete from proveedor where id=@id
end
GO

create proc mostrar_proveedor
as
begin
	select * from proveedor;
end
GO

create proc buscar_proveedor
(
@busq varchar(60)
)
as
begin
	select * from proveedor where Proveedor LIKE '%'+@busq+'%' OR id LIKE '%'+@busq+'%' 
	OR [Correo electronico] LIKE '%'+@busq+'%' OR Telefono LIKE '%'+@busq+'%'
end
GO

exec insertar_proveedor 'Didea','dideasv@gmail.com',22586341;
exec insertar_proveedor 'Diparvel','diparvelsv@gmail.com',22754163;
exec modificar_proveedor 'Didea','dideaint.sv@hotmail.com',22586341,1;
exec eliminar_proveedor 2;
exec mostrar_proveedor;
exec buscar_proveedor 'di';


-----------------------PRODUCTOS-----------------------

select * from producto
GO

create proc insertar_producto
(
@nombre varchar(60),
@descripcion varchar(150),
@imagen varbinary(max),
@proveedor int,
@receptor int,
@categoria int,
@marca int,
@cantidad int,
@precio money
) as
begin
	insert into producto([Nombre de producto],Descripcion,imagen,Proveedor,Receptor,Categoria,Marca,Cantidad,[Precio de compra]) 
	values (@nombre,@descripcion,@imagen,@proveedor,@receptor,@categoria,@marca,@cantidad,@precio)
end
GO

create proc modificar_producto
(
@nombre varchar(60),
@descripcion varchar(150),
@imagen varbinary(max),
@proveedor int,
@receptor int,
@categoria int,
@marca int,
@cantidad int,
@precio money,
@id int
) as
begin
	update producto set [Nombre de producto]=@nombre,Descripcion=@descripcion,imagen=@imagen,Proveedor=@proveedor,Receptor=@receptor,
	Categoria=@categoria,Marca=@marca,Cantidad=@cantidad,[Precio de compra]=@precio where id=@id
end
GO

create proc eliminar_producto
(
@id int
) as
begin
	delete from producto where id=@id
end

select producto.id,[Nombre de producto],Descripcion,imagen,proveedor.Proveedor, empleado.[Nombre de Empleado] as Receptor,[Fecha de ingreso], 
categoria.Categoria, marca.Marca, Cantidad, ROUND([Precio de compra],2,0) as [Precio de Compra], ROUND([Precio de venta],2,0) as [Precio de Venta] 
from producto join usuario on usuario.id=Receptor join empleado on empleado.id=usuario.Empleado join proveedor on proveedor.id=producto.Proveedor 
join categoria on categoria.id=producto.Categoria join marca on marca.id=producto.Marca;
GO

create proc buscar_producto
(@busq varchar(60)) with encryption as
begin
	select producto.id,[Nombre de producto] as Producto,Descripcion,proveedor.Proveedor,
	empleado.[Nombre de Empleado] as Receptor, [Fecha de Ingreso] as Ingreso,categoria.Categoria, marca.Marca, producto.Cantidad,
	ROUND([Precio de compra],2,0) as [Precio Compra], ROUND([Precio de venta],2,0) as [Precio Venta]
	from producto join proveedor on producto.Proveedor=proveedor.id join
	empleado on empleado.id = Receptor join categoria on producto.Categoria = categoria.id
	join marca on producto.Marca=marca.id where producto.id LIKE '%'+@busq+'%' 
	OR [Nombre de producto] LIKE '%'+@busq+'%' OR Descripcion LIKE '%'+@busq+'%' OR proveedor.Proveedor LIKE '%'+@busq+'%' OR [Nombre de Empleado]
	LIKE '%'+@busq+'%' OR [Fecha de ingreso] LIKE '%'+@busq+'%' OR categoria.Categoria LIKE '%'+@busq+'%' OR marca.Marca LIKE '%'+@busq+'%'
	OR [Precio de compra] LIKE '%'+@busq+'%' OR [Precio de venta] LIKE '%'+@busq+'%';
end
GO

create proc mostrar_producto
as
begin
	select producto.id,[Nombre de producto] as Producto,Descripcion,proveedor.Proveedor,
	empleado.[Nombre de Empleado] as Receptor, [Fecha de Ingreso] as Ingreso,categoria.Categoria, marca.Marca, producto.Cantidad,
	ROUND([Precio de compra],2,0) as [Precio Compra], ROUND([Precio de venta],2,0) as [Precio Venta]
	from producto join proveedor on producto.Proveedor=proveedor.id join
	empleado on empleado.id = Receptor join categoria on producto.Categoria = categoria.id
	join marca on producto.Marca=marca.id
end
GO

create proc mostrar_producto_web
as
	select producto.id,[Nombre de producto] as Producto,imagen,Descripcion,
	categoria.Categoria, marca.Marca, ROUND([Precio de venta],2,0) as Precio
	from producto join categoria on producto.Categoria = categoria.id
	join marca on producto.Marca=marca.id
GO

exec mostrar_producto_web

exec mostrar_producto;

exec mostrar_usuario

select * from producto

select producto.id,[Nombre de producto] as Producto,Descripcion,proveedor.Proveedor,
empleado.[Nombre de Empleado] as Receptor, [Fecha de Ingreso] as Ingreso,categoria.Categoria, marca.Marca,
ROUND([Precio de compra],2,0) as [Precio Compra], ROUND([Precio de venta],2,0) as [Precio Venta]
from producto join proveedor on producto.Proveedor=proveedor.id join
empleado on empleado.id = Receptor join categoria on producto.Categoria = categoria.id
join marca on producto.Marca=marca.id