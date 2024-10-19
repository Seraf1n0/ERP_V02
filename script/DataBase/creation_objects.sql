/*
Name   : ERP
Link   : https://github.com/Seraf1n0/ERP_V02.git
Version: 19/10/2024
Autores: Yosimar Montenegro y Dylan Rodríguez
--------------------------------------------------------------------
*/

CREATE DATABASE ERP
GO

USE ERP
GO

CREATE SCHEMA Ventas
GO

CREATE SCHEMA Produccion
GO

CREATE SCHEMA RRHH -- Recursos humanos
GO

-- Tablas catalogo

CREATE TABLE Ventas.Estado ( -- Tabla catalogo_Estado
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	descripcion VARCHAR (20) NOT NULL
);

CREATE TABLE Ventas.Etapa ( -- Tabla catalogo_Etapa
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	descripcion VARCHAR (20) NOT NULL
);

CREATE TABLE Ventas.Zona ( -- Tabla catalogo_zona
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	descripcion VARCHAR (50) NOT NULL
);

CREATE TABLE Ventas.Sector ( -- Tabla catalogo_sector
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	descripcion VARCHAR (25) NOT NULL
);

CREATE TABLE Ventas.Probabilidad (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	descripcion INT NOT NULL
);

CREATE TABLE Ventas.TipoCedula ( -- Tabla catalogo_tipoCedula
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	tipo VARCHAR (50) NOT NULL
);

CREATE TABLE Ventas.Genero ( -- Tabla catalogo_Genero
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	descripcion VARCHAR (10) NOT NULL,
);

CREATE TABLE RRHH.Departamento ( -- Tabla catalogo_departamento
	nombre VARCHAR (20) PRIMARY KEY NOT NULL,
	codigo VARCHAR (10) NOT NULL
);

CREATE TABLE Ventas.TipoCotizacion (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	descripcion varchar (50) NOT NULL
);

-- Creacion de tablas

CREATE TABLE RRHH.Puesto (
	nombre VARCHAR (150) PRIMARY KEY NOT NULL,
	nombreD_Departamento VARCHAR (20) NOT NULL,
	FOREIGN KEY (nombreD_Departamento) REFERENCES RRHH.Departamento(nombre)
);

CREATE TABLE RRHH.Usuario (
	cedula VARCHAR (20) PRIMARY KEY NOT NULL,
	nombrePuesto_Puesto VARCHAR (150),
	primerNombre VARCHAR (20) NOT NULL,
	segundoNombre VARCHAR (20) null,
	primerApellido VARCHAR (20) NOT NULL,
	segundoApellido VARCHAR (20) NOT NULL,
	genero INT NOT NULL,
	email VARCHAR (50) NOT NULL,
	provincia VARCHAR (20) NOT NULL,
	canton VARCHAR (20) NOT NULL,
	distrito VARCHAR (20) NOT NULL,
	seniaExacta VARCHAR (100) NOT NULL,
	fechaRegistro DATE NOT NULL,
	fechaNacimiento DATE NOT NULL, 
	salarioActual FLOAT NOT NULL,
	tipoCedula INT NOT NULL,
	FOREIGN KEY (tipoCedula) REFERENCES Ventas.TipoCedula(ID),
	FOREIGN KEY (genero) REFERENCES Ventas.Genero(ID),

	-- CREDENCIALES 
	usuario VARCHAR (15) NOT NULL,
	contrasenia VARCHAR (15) NOT NULL,
	FOREIGN KEY (nombrePuesto_Puesto) REFERENCES RRHH.Puesto(nombre),
	CONSTRAINT AK_Usuario UNIQUE(usuario),

	--Checks
	CONSTRAINT Chk_fechaDeNacimientoNoMayorHoy CHECK(fechaNacimiento <= CAST(GETDATE() AS DATE)),
	CONSTRAINT Chk_salarioActualMayor0 CHECK(salarioActual > 0)
);

CREATE TABLE RRHH.Pago (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	cedulaAdjudicado_Usuario VARCHAR (20) NOT NULL,
	montoJornadaRegular INT NOT NULL, 
	montoHorasExtra INT, 
	horasExtra TIME,
	jornadaRegular TIME NOT NULL,
	fechaHora DATETIME NOT NULL, 
	FOREIGN KEY (cedulaAdjudicado_Usuario) REFERENCES RRHH.Usuario(cedula),

	--Checks
	CONSTRAINT Chk_montoJornadaRegularMayor0 CHECK(montoJornadaRegular > 0),
	CONSTRAINT Chk_montoHorasExtraMayor0 CHECK(montoHorasExtra > 0),
	CONSTRAINT Chk_fechaHoraMenorIgualHoy CHECK(fechaHora <= GETDATE())

);

CREATE TABLE RRHH.HistoricoPuesto (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	puestoActual_Puesto VARCHAR (150) NOT NULL,
	cedulaU_Usuario VARCHAR (20) NOT NULL,
	fechaInicio DATE DEFAULT CAST(GETDATE() AS DATE) NOT NULL, --Falta constrait no puede ser mayor a hoy
	fechaFin DATE NOT NULL, --Falta constraint debe ser mayor o igual a la fecha de inicio
	FOREIGN KEY (puestoActual_Puesto) REFERENCES RRHH.Puesto(nombre),
	FOREIGN KEY (cedulaU_Usuario) REFERENCES RRHH.Usuario(cedula),

	--Checks
	CONSTRAINT Chk_fechaInicioIgualHoy CHECK(fechaInicio = CAST(GETDATE() AS DATE)),
	CONSTRAINT Chk_fechaFinMayorIgualInicio CHECK(fechaFin >=fechaInicio)
);

CREATE TABLE RRHH.HistoricoSalario (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	IDHistorico_HistoricoPuesto INT NOT NULL,
	fechaInicio DATE DEFAULT CAST(GETDATE() AS DATE) NOT NULL, --Falta constrait no puede ser mayor a hoy
	fechaFin DATE NOT NULL, --Falta constraint debe ser mayor o igual a la fecha de inicio
	monto INT NOT NULL, --No puede ser menor a 0
	FOREIGN KEY (IDHistorico_HistoricoPuesto) REFERENCES RRHH.HistoricoPuesto (ID),
	
	--Check
	CONSTRAINT Chk_fechaInicioIgualHoyHS CHECK(fechaInicio = CAST(GETDATE() AS DATE)),
	CONSTRAINT Chk_fechaFinMayorIgualInicioHS CHECK(fechaFin >=fechaInicio)

);

/*
Creacion de tablas del schema Ventas
*/

CREATE TABLE Ventas.Cliente (
	cedula VARCHAR (20) PRIMARY KEY NOT NULL,
	tipoCedula INT NOT NULL,
	fax VARCHAR (20) NOT NULL,
	primerNombre VARCHAR (20) NOT NULL, --Si fuera una empresa aquí se guardaría el nombre completo
	segundoNombre VARCHAR (20) NULL,
	primerApellido VARCHAR (20) NULL,
	segundoApellido VARCHAR (20) NULL,
	genero INT NOT NULL,
	email VARCHAR (50) NOT NULL,
	provincia VARCHAR (20) NOT NULL,
	canton VARCHAR (20) NOT NULL,
	distrito VARCHAR (20) NOT NULL,
	seniaExacta VARCHAR (100) NOT NULL
	FOREIGN KEY (tipoCedula) REFERENCES Ventas.TipoCedula(ID),
	FOREIGN KEY (genero) REFERENCES Ventas.Genero(ID),
);

-- Tabla del multievaluado Telefonos
CREATE TABLE Ventas.TelefonosCliente (
	numeroTelefono VARCHAR (20) PRIMARY KEY NOT NULL,
	duenio_Cliente VARCHAR (20) NOT NULL,
	FOREIGN KEY (duenio_Cliente) REFERENCES Ventas.Cliente(cedula)
);

CREATE TABLE Ventas.Cotizacion (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	cedulaCotizador_Cliente VARCHAR (20) NOT NULL,
	cedulaEmpleado_Usuario VARCHAR (20) NOT NULL,
	montoTotal INT, --No puede ser mayor a 0
	fechaCierreProyectada DATE NOT NULL, --Mayor o igual a la de hoy
	fechaCierre DATE, 
	fechaHoraRegistro DATETIME DEFAULT GETDATE() NOT NULL, 
	probabilidad INT NOT NULL,
	descripcion VARCHAR (255),
	zona VARCHAR (50) NOT NULL, --Viene del catálogo
	sector VARCHAR (25) NOT NULL, --Viene del catálogo
	FOREIGN KEY (cedulaCotizador_Cliente) REFERENCES Ventas.Cliente(cedula),
	FOREIGN KEY (cedulaEmpleado_Usuario) REFERENCES RRHH.Usuario(cedula),

	--Check
	CONSTRAINT Chk_montoTotalMayor0 CHECK(montoTotal >0),
	CONSTRAINT Chk_fechaCierreProyectadaMayorIgualHoy CHECK( fechaCierreProyectada >= CAST(GETDATE() AS DATE)),
	CONSTRAINT Chk_fechaHoraRegistroIgualHoy CHECK(fechaHoraRegistro= GETDATE())
);

CREATE TABLE Ventas.Caso (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	IDCotizacion_Cotización INT NOT NULL,
	estado INT NOT NULL,
	descripcion VARCHAR (255) NOT NULL,
	motivo VARCHAR (120) NOT NULL,
	resultado VARCHAR (120),
	FOREIGN KEY (IDCotizacion_Cotización) REFERENCES Ventas.Cotizacion(ID),
	FOREIGN KEY (estado) REFERENCES Ventas.Estado(ID) -- Estado de cotización
);

CREATE TABLE Ventas.Tarea (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	IDCaso_Caso INT NOT NULL,
	descripcion VARCHAR (100) NOT NULL,
	etapa INT,
	FOREIGN KEY (etapa) REFERENCES Ventas.Etapa(ID),
	FOREIGN KEY (IDCaso_Caso) REFERENCES Ventas.Caso(ID)
);



CREATE TABLE Ventas.Factura (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	responsable_Usuario VARCHAR (20) NOT NULL,
	comprador_Cliente VARCHAR (20) NOT NULL,
	fechaHora DATETIME DEFAULT GETDATE() NOT NULL,
	estado VARCHAR (15),
	montoTotal float NOT NULL,
	motivoAnulacion VARCHAR (200) NOT NULL, -- En caso que la factura haya sido cancelada antes de su confirmación
	FOREIGN KEY (responsable_Usuario) REFERENCES RRHH.Usuario(cedula),
	FOREIGN KEY (comprador_Cliente) REFERENCES Ventas.Cliente(cedula),

	--Checks
	CONSTRAINT Chk_fechaHoraIgualHoy CHECK(fechaHora = GETDATE())

);

CREATE TABLE Ventas.Salida (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	IDFactura_Factura INT NOT NULL,
	fechaHora DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY (IDFactura_Factura) REFERENCES Ventas.Factura(ID),

	--Checks
	CONSTRAINT Chk_fechaHoraIgualHoyS CHECK(fechaHora = GETDATE())
);

CREATE TABLE Produccion.Bodega (
	codigo VARCHAR (10) PRIMARY KEY NOT NULL,
	nombre VARCHAR (30) NOT NULL,
	provincia VARCHAR (20) NOT NULL,
	canton VARCHAR (20) NOT NULL,
	distrito VARCHAR (20) NOT NULL,
	seniaExacta VARCHAR (100) NOT NULL,
	toneladasCapacidad INT NOT NULL,
	espacioCubico INT NOT NULL,

	--Checks
	CONSTRAINT Chk_toneladasCapacidadMayor0 CHECK (toneladasCapacidad > 0),
	CONSTRAINT Chk_espacioCubicoMayor0 CHECK (espacioCubico >0)
);

CREATE TABLE Produccion.Familia (
	codigo VARCHAR (10) PRIMARY KEY NOT NULL,
	nombre VARCHAR (30) NOT NULL,
	descripcion VARCHAR (150) NOT NULL,
	activo VARCHAR (10)
	CONSTRAINT AK_Nombre UNIQUE(nombre)
);

CREATE TABLE Produccion.FamiliaBodega (
	codigoF_Familia VARCHAR (10) NOT NULL,
	codigoB_Bodega VARCHAR (10) NOT NULL,
	FOREIGN KEY (codigoF_Familia) REFERENCES Produccion.Familia(codigo),
	FOREIGN KEY (codigoB_Bodega) REFERENCES Produccion.Bodega(codigo)
);

CREATE TABLE Produccion.Articulo (
	nombre VARCHAR (130) PRIMARY KEY NOT NULL, -- Darle libertad de nombre por desconocer la empresa objetivo
	codigoF_Familia VARCHAR (10) NOT NULL,
	codigo INT NOT NULL,
	precio float NOT NULL,
	peso float NOT NULL,
	descripcion VARCHAR (255) NOT NULL, -- Libertar de descripción de producto 
	marca VARCHAR (50) NOT NULL,
	activo VARCHAR (10),
	FOREIGN KEY (codigoF_Familia) REFERENCES Produccion.Familia(codigo),
	CONSTRAINT AK_Codigo UNIQUE(codigo), -- Los codigos de productos deben ser unicos a no ser que sean eliminados del sistema

	--Checks
	CONSTRAINT Chk_precioMayor0 CHECK(precio > 0),
	CONSTRAINT Chk_pesoMayor0  CHECK(peso > 0)

);

CREATE TABLE Produccion.Movimiento (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	codigoOrigen_Bodega VARCHAR (10) NOT NULL,
	codigoDestino_Bodega VARCHAR (10) NOT NULL,
	responsable_Usuario VARCHAR (20) NOT NULL,
	fechaHora DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY (responsable_Usuario) REFERENCES RRHH.Usuario(cedula),
	FOREIGN KEY (codigoOrigen_Bodega) REFERENCES Produccion.Bodega (codigo),
	FOREIGN KEY (codigoDestino_Bodega) REFERENCES Produccion.Bodega (codigo),

	--Checks
	CONSTRAINT Chk_fechaHoraIgualHoy CHECK(fechaHora = GETDATE())
);

-- Tabla para agregar lineas de productos (cantidad) independientes a un movimiento
CREATE TABLE Produccion.MovimientoArticulo (
	IDMovimiento_Movimiento INT NOT NULL,
	nombreA_Articulo VARCHAR (130) NOT NULL,
	cantidadArticulo INT NOT NULL,
	FOREIGN KEY (IDMovimiento_Movimiento) REFERENCES Produccion.Movimiento (ID),
	FOREIGN KEY (nombreA_Articulo) REFERENCES Produccion.Articulo(nombre)
);

CREATE TABLE Produccion.Entrada (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	codigoDestino_Bodega VARCHAR (10) NOT NULL,
	responsable_Usuario VARCHAR(20) NOT NULL,
	fechaHora DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY (responsable_Usuario) REFERENCES RRHH.Usuario (cedula),
	FOREIGN KEY (codigoDestino_Bodega) REFERENCES Produccion.Bodega(codigo),

	--Check
	CONSTRAINT Chk_fechaHoraIgualHoyE CHECK (fechaHora = GETDATE())
);

CREATE TABLE Produccion.EntradaArticulo (
	IDEntrada_Entrada INT NOT NULL,
	nombreA_Articulo VARCHAR (130) NOT NULL,
	cantidadArticulo INT NOT NULL,
	FOREIGN KEY (nombreA_Articulo) REFERENCES Produccion.Articulo(nombre),
	FOREIGN KEY (IDEntrada_Entrada) REFERENCES Produccion.Entrada(ID),

	--Check
	CONSTRAINT Chk_cantidadArticuloMayor0 CHECK(cantidadArticulo > 0)
);

CREATE TABLE Produccion.Inventario ( -- Esta tabla pertenece al schema de producción pero puede ser visualizada desde la venta
	codigoB_Bodega VARCHAR (10) NOT NULL,
	nombreA_Articulo VARCHAR (130) NOT NULL,
	cantidad INT NOT NULL,
	FOREIGN KEY (codigoB_Bodega) REFERENCES Produccion.Bodega(codigo),
	FOREIGN KEY (nombreA_Articulo) REFERENCES Produccion.Articulo(nombre),
	
	--Check
	CONSTRAINT Chk_cantidadMayor0 CHECK(cantidad > 0)
);

-- Esta tabla es intermedia entre el esquema de ventas y produccion
CREATE TABLE Ventas.FacturaInventario (
	ID_Factura INT NOT NULL,
	nombreA_Articulo VARCHAR(130) NOT NULL,
	cantidadProducto INT NOT NULL, --No puede ser menor a 0
	precioProducto FLOAT NOT NULL, --No puede ser menor a 0
	FOREIGN KEY (ID_Factura) REFERENCES Ventas.Factura(ID),
	FOREIGN KEY (nombreA_Articulo) REFERENCES Produccion.Articulo(nombre),

	--Check
	CONSTRAINT Chk_cantidadProductoMayor0FI CHECK(cantidadProducto > 0),
	CONSTRAINT Chk_precioProductoMayor0FI CHECK(precioProducto > 0)
);

CREATE TABLE Ventas.CotizacionInventario ( -- Sirve como orden de compra
	ID_Cotizacion INT NOT NULL,
	nombreA_Articulo VARCHAR (130) NOT NULL,
	codigoB_Bodega VARCHAR (10) NOT NULL,
	cantidadProducto INT NOT NULL, --No puede ser menor a 0
	precioProducto FLOAT NOT NULL, --No puede ser menor a 0
	FOREIGN KEY (ID_Cotizacion) REFERENCES Ventas.Cotizacion(ID),
	FOREIGN KEY (nombreA_Articulo) REFERENCES Produccion.Articulo(nombre),
	FOREIGN KEY (codigoB_Bodega) REFERENCES Produccion.Bodega(codigo),

	--Check
	CONSTRAINT Chk_cantidadProductoMayor0CI CHECK (cantidadProducto > 0),
	CONSTRAINT Chk_precioProductoMayor0CI CHECK (precioProducto > 0)
);
