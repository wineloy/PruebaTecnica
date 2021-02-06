--Script base de datos 
use Productos;

CREATE TABLE PRODUCTOS (
	IdProductos integer primary key identity(1,1),
	NombreProducto varchar(50),
	NombreProductoLargo text, 
	Precio decimal, 
	CantidadExistencia int 
)

Create Table VENTAS (
	IdVenta integer primary key identity(1,1),
	IdProductos integer,
	fecha date,
	PrecioVenta decimal,
	cantidad int
	foreign key (IdProductos) references PRODUCTOS(IdProductos)
)

SELECT * FROM PRODUCTOS;


delete from PRODUCTOS;

insert into PRODUCTOS(NombreProducto, NombreProductoLargo,Precio,CantidadExistencia )
VALUES ('XBOX SERIES S','CONSOLA MICROSOFT SERIES S 500 GB DISCO DURO, INCLUYE UN CONTROL CON FORZA HORIZON',9000,1000)

insert into PRODUCTOS(NombreProducto, NombreProductoLargo,Precio,CantidadExistencia )
VALUES ('PLAY STATION 4','CONSOLA SONY DIGITAL EDITION 500 GB DISCO DURO, INCLUYE UN CONTROL CON THE LAST OF US',10000,1500)

insert into PRODUCTOS(NombreProducto, NombreProductoLargo,Precio,CantidadExistencia )
VALUES ('NINTENDO SWICTH','NINTENDO SWITCH CON DOCK',9500,1000)

insert into PRODUCTOS(NombreProducto, NombreProductoLargo,Precio,CantidadExistencia )
VALUES ('NINTENDO 3DS','CONSOLA PORTATIL NINTENDO 3DS EDICION ZELDA MAJORAS MASK',4000,2000)


insert into ventas(IDProductos, fecha, PrecioVenta, cantidad) values (1,GETDATE(),1500, 10);


select * from ventas;

delete from VENTAS;
