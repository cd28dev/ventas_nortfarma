CREATE DATABASE db_nortfarma;
USE db_nortfarma


--Creacion de tablas

CREATE TABLE tipoDocumento(
	idTipo INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE tipoCliente(
	idTipo INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE tipoComprobante(
	idTipo INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE tipoEmpleado(
	idTipo INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE categoriaProducto(
	idTipo INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE entidadFinanciera(
	idEntidad INTEGER identity(1,1) PRIMARY KEY,
	razonSocial VARCHAR(50) not null,
	nroRuc	VARCHAR(11) not null,
	ubicacion VARCHAR(50) not null,
	estado	VARCHAR(50),

	CONSTRAINT ck_ruc_ef CHECK(nroRuc like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
);

CREATE TABLE medioPago(
	idMedio INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE rol(
	idRol INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE ciudad(
	idCiudad INTEGER identity(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado VARCHAR(50)
);

CREATE TABLE persona (
    idPersona		INTEGER identity(1,1) PRIMARY KEY,
    nombres			VARCHAR(50) NOT NULL,
    apellidos		VARCHAR(50) NOT NULL,
    nroDocumento	VARCHAR(11) NOT NULL,
    email			VARCHAR(50) NOT NULL,
    telefono		VARCHAR(9)	NOT NULL,
    fechaNacimiento DATE		NOT NULL,
    lugarNacimiento VARCHAR(50) NOT NULL,
    direccion		VARCHAR(50) NOT NULL,
    estado			VARCHAR(50) NOT NULL,
    idTipoDoc		INTEGER NOT NULL,
    UNIQUE (nroDocumento,email,telefono)
);

ALTER TABLE persona
ADD CONSTRAINT pers_tdoc_fk
FOREIGN KEY(idTipoDoc)
REFERENCES tipoDocumento(idTipo);

CREATE TABLE usuario(
    idUsuario INTEGER identity(1,1) PRIMARY KEY,
    idPersona INTEGER			NOT NULL,
    nombreUsuario VARCHAR(50)	NOT NULL,
    contraseña VARCHAR(8)		NOT NULL,
    estado VARCHAR(50)			NOT NULL,
    UNIQUE (nombreUsuario)
);

ALTER TABLE usuario
ADD CONSTRAINT usu_per_fk
FOREIGN KEY(idPersona)
REFERENCES Persona(idPersona);

CREATE TABLE Usuario_Rol (
    idUsuario INTEGER NOT NULL,
    idRol INTEGER NOT NULL,
    PRIMARY KEY (idUsuario, idRol),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario) ON DELETE CASCADE,
    FOREIGN KEY (idRol) REFERENCES Rol(idRol) ON DELETE CASCADE
);

CREATE TABLE Empleado (
    idEmpleado INT identity(1,1) PRIMARY KEY,    
    fechaIngreso DATE NOT NULL,
    salario DECIMAL(18, 2) NOT NULL,            
    estado VARCHAR(50) NOT NULL,
    idPersona INT NOT NULL,
    idTipoEmpleado INT NOT NULL
);

ALTER TABLE Empleado
ADD CONSTRAINT empleado_persona_fk
FOREIGN KEY(idPersona)
REFERENCES Persona(idPersona);

ALTER TABLE Empleado
ADD CONSTRAINT empleado_tipo_fk
FOREIGN KEY(idTipoEmpleado)
REFERENCES TipoEmpleado(idTipo);

CREATE TABLE Cliente (
    idCliente INTEGER identity(1,1) PRIMARY KEY,
    estado VARCHAR(50) NOT NULL,
    idPersona INTEGER NOT NULL,
    idTipo INTEGER NOT NULL
);

ALTER TABLE Cliente
ADD CONSTRAINT cli_per_fk
FOREIGN KEY(idPersona)
REFERENCES Persona(idPersona);

ALTER TABLE Cliente
ADD CONSTRAINT cli_tCli_fk
FOREIGN KEY(idTipo)
REFERENCES tipoCliente(idTipo);

CREATE TABLE TipoTarjeta (
    idTipo INT NOT NULL identity(1,1) PRIMARY KEY,
    nombreTipo VARCHAR(50) NOT NULL,
    idEntidad INT NOT NULL
);

ALTER TABLE TipoTarjeta
ADD CONSTRAINT tipo_tarjeta_fk
FOREIGN KEY(idEntidad)
REFERENCES EntidadFinanciera(idEntidad);


CREATE TABLE Producto (
    idProducto INT identity(1,1) PRIMARY KEY,      
    nombreProducto VARCHAR(50) NOT NULL,
    precioLista DECIMAL(18, 2) NOT NULL,             
    descripcion VARCHAR(50) NOT NULL,
    idCategoria INT NOT NULL
);

ALTER TABLE Producto
ADD CONSTRAINT producto_categ_fk
FOREIGN KEY(idCategoria)
REFERENCES CategoriaProducto(idTipo);

CREATE TABLE CarritoCompra (
    idCarrito INT identity(1,1) PRIMARY KEY,      
    items VARCHAR(50) NOT NULL,
    total_pagar DECIMAL(18, 2) NOT NULL             
);

CREATE TABLE Pedido (
    idPedido INT NOT NULL PRIMARY KEY,              
    fechaRecojo DATE NOT NULL,
    direccionEntrega VARCHAR(50) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    idCarritoCompra INT NOT NULL
);

ALTER TABLE Pedido
ADD CONSTRAINT pedido_carrito_fk
FOREIGN KEY(idCarritoCompra)
REFERENCES CarritoCompra(idCarrito);

CREATE TABLE Item (
    idItem INT identity(1,1) PRIMARY KEY,          
    nombreProducto VARCHAR(50) NOT NULL,
    cantidad INT NOT NULL,
    sub_total DECIMAL(18, 2) NOT NULL,             
    estado VARCHAR(50) NOT NULL,
    idCarrito INT NOT NULL,
    idProducto INT NOT NULL
);

ALTER TABLE Item
ADD CONSTRAINT item_carrito_fk
FOREIGN KEY(idCarrito)
REFERENCES CarritoCompra(idCarrito);

ALTER TABLE Item
ADD CONSTRAINT item_producto_fk
FOREIGN KEY(idProducto)
REFERENCES Producto(idProducto);


CREATE TABLE Farmacia (
    idFarmacia INT identity(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    direccion VARCHAR(50) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    idCiudad INT NOT NULL
);

ALTER TABLE Farmacia
ADD CONSTRAINT farmacia_ciudad_fk
FOREIGN KEY(idCiudad)
REFERENCES Ciudad(idCiudad);


CREATE TABLE Venta (
    idVenta INT identity(1,1) PRIMARY KEY,
    fecha DATE NOT NULL,
    total DECIMAL(18, 2) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    idPedido INT NOT NULL,
    idFarmacia INT NOT NULL,
    idEmpleado INT NOT NULL
);


ALTER TABLE Venta
ADD CONSTRAINT pedido_venta_fk
FOREIGN KEY(idPedido)
REFERENCES Pedido(idPedido);

ALTER TABLE Venta
ADD CONSTRAINT farmacia_venta_fk
FOREIGN KEY(idFarmacia)
REFERENCES Farmacia(idFarmacia);

ALTER TABLE Venta
ADD CONSTRAINT empleado_venta_fk
FOREIGN KEY(idEmpleado)
REFERENCES Empleado(idEmpleado);


CREATE TABLE Pago (
    idPago INT identity(1,1) PRIMARY KEY,      
    fecha DATE NOT NULL,
    total DECIMAL(18, 2) NOT NULL,                 
    estado VARCHAR(50) NOT NULL,
    idEmpleado INT NOT NULL,
    idVenta INT NOT NULL
);


CREATE TABLE Comprobante (
    idComprobante INT identity(1,1) PRIMARY KEY,            
    nroComprobante VARCHAR(50) NOT NULL,                    
    fechaEmision DATE NOT NULL,
    idTipoComprobante INT NOT NULL,
    idPago INT NOT NULL,
);
ALTER TABLE Comprobante
ADD CONSTRAINT comp_tcomp_fk
FOREIGN KEY(idTipoComprobante)
REFERENCES tipoComprobante(idTipo);

ALTER TABLE Comprobante
ADD CONSTRAINT comp_pago_fk
FOREIGN KEY(idPago)
REFERENCES Pago(idPago);

CREATE TABLE DetalleDeVenta (
    idDetalleDeVenta INT identity(1,1) PRIMARY KEY,        
    cantidad INT NOT NULL,
    dscto DECIMAL(5, 2) NOT NULL,                         
    subTotal DECIMAL(18, 2) NOT NULL,                     
    idVenta INT NOT NULL,
	idProducto INT NOT NULL
);


ALTER TABLE DetalleDeVenta
ADD CONSTRAINT dtventa_venta
FOREIGN KEY(idVenta)
REFERENCES Venta(idVenta);

ALTER TABLE DetalleDeVenta
ADD CONSTRAINT dtventa_producto
FOREIGN KEY(idProducto)
REFERENCES Producto(idProducto);

CREATE TABLE Anulacion (
    idAnulacion INT identity(1,1) PRIMARY KEY,           
    estado VARCHAR(50) NOT NULL,
    idVenta INT NOT NULL,
    idEmpleado INT NOT NULL,
    idDetalleDeVenta INT NOT NULL
);


ALTER TABLE Anulacion
ADD CONSTRAINT venta_anulacion_fk
FOREIGN KEY(idVenta)
REFERENCES Venta(idVenta);

ALTER TABLE Anulacion
ADD CONSTRAINT empleado_anulacion_fk
FOREIGN KEY(idEmpleado)
REFERENCES Empleado(idEmpleado);

ALTER TABLE Anulacion
ADD CONSTRAINT detalle_anulacion_fk
FOREIGN KEY(idDetalleDeVenta)
REFERENCES DetalleDeVenta(idDetalleDeVenta);

CREATE TABLE Tarjeta (
    idTarjeta INT identity(1,1) PRIMARY KEY,          
    nroCuenta VARCHAR(50) NOT NULL,
    nroTarjeta VARCHAR(50) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    idCliente INT NOT NULL,
    idTipoTarjeta INT NOT NULL,
    CONSTRAINT UQ_Tarjeta_Cuenta_Tarjeta UNIQUE (nroCuenta, nroTarjeta) 
);

ALTER TABLE Tarjeta
ADD CONSTRAINT tarjeta_tipo_fk
FOREIGN KEY(idTipoTarjeta)
REFERENCES TipoTarjeta(idTipo);

ALTER TABLE Tarjeta
ADD CONSTRAINT tarjeta_cliente_fk
FOREIGN KEY(idCliente)
REFERENCES Cliente(idCliente);

CREATE TABLE DetalleDePago (
    idDetalleDePago INT identity(1,1) PRIMARY KEY,     
    monto DECIMAL(18, 2) NOT NULL,                
    idTarjeta INT NOT NULL,
    idMedio INT NOT NULL,
    idPago INT NOT NULL
);

ALTER TABLE DetalleDePago
ADD CONSTRAINT detalle_medio_fk
FOREIGN KEY(idMedio)
REFERENCES MedioPago(idMedio);

ALTER TABLE DetalleDePago
ADD CONSTRAINT detalle_tarjeta_fk
FOREIGN KEY(idTarjeta)
REFERENCES Tarjeta(idTarjeta);

ALTER TABLE DetalleDePago
ADD CONSTRAINT detalle_pago_fk
FOREIGN KEY(idPago)
REFERENCES Pago(idPago);
