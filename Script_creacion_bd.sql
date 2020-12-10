CREate table Clientes 
(CUIT integer primary key,
nombre varchar(15),
apellido varchar(15),
razonSocial varchar(30),
condicionIva integer references condicionIva (id_Iva),
condicionPago integer references CondicionPago (id_pago ),
mail varchar(30),
telefono integer,
domComercial varchar(50),
domEntrega varchar(50)
)

CREate table Proveedores 
(CUIT integer primary key,
nombre varchar(15),
apellido varchar(15),
razonSocial varchar(30),
mail varchar(30),
telefono integer,
)

Create table Productos
(id_producto varchar(30) primary key,
descripcion varchar(75),
stockDisponible integer,
stockMinimo integer,
fechaUltimaCompra date,
precio float
)

create table Factura 
(nroSucursal integer,
nroFactura integer,
cliente integer References Clientes (CUIT),
observaciones varchar(100),
total float,
tipoCambio float,
Primary key (nroSucursal, nroFactura)
)

create table DetalleFactura
(nroSucursal integer,
nroFactura integer,
id_producto varchar(30) references Productos (id_producto),
cantidad int,
primary key (nroSucursal, nroFactura, id_producto)
)
//Agregar foreign key aca a FACTURA 
alter table DetalleFactura ADD foreign key (nroSucursal,nroFactura) references Factura(nroSucursal,nroFactura)

create table Remito
(nroSucursal int,
nroRemito int,
cliente int references Clientes (CUIT),
observaciones varchar(100)
primary key (nroSucursal, nroRemito)
)

create table DetalleRemito
(nroSucursal int,
nroRemito int,
id_producto varchar(30) references Productos (id_producto),
cantidad int
primary key (nroSucursal,nroRemito,id_producto)
)
alter table DetalleRemito ADD
foreign key (nroSucursal,nroRemito) references Remito(nroSucursal,nroRemito)

create table NotaCredito 
(nroSucursal integer,
nroNC integer,
nroSucursalFacturada integer,
nroFactura integer,
cliente integer References Clientes (CUIT),
observaciones varchar(100),
total float,
tipoCambio float,
Primary key (nroSucursal, nroNC),
foreign key (nroSucursalFacturada,nroFactura) references Factura (nroSucursal, nroFactura)
)

create table DetalleNotaCredito
(nroSucursal integer,
nroNC integer,
id_producto varchar(30) references Productos (id_producto),
cantidad int,
primary key (nroSucursal, nroNC, id_producto)
)
alter table DetalleNotaCredito ADD
foreign key (nroSucursal,nroNC) references NotaCredito(nroSucursal,nroNC)

create table NotaDebito 
(nroSucursal integer,
nroND integer,
cliente integer References Clientes (CUIT),
observaciones varchar(100),
total float,
tipoCambio float,
Primary key (nroSucursal, nroND),
)

create table DetalleNotaDebito
(nroSucursal integer,
nroND integer,
nroOrden int,
detalle varchar(30),
primary key (nroSucursal, nroND, nroOrden),
foreign key (nroSucursal,nroND) references NotaDebito(nroSucursal,nroND)
)