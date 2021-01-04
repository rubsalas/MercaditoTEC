/*
--------------------------------------------------------------------
MercaditoTEC
--------------------------------------------------------------------
Instituto Técnológico de Costa Rica
Área Académica de Ingeniería en Computadores
Especificación y Diseño de Software (CE4101) 
II Semestre 2020
Prof. Luis Diego Noguera Mena
Cristhofer Azofeifa, Tatiana Mora & Rubén Salas
--------------------------------------------------------------------
MercaditoTEC - Objects Creator
--------------------------------------------------------------------
*/


/****** Object:  Database MercaditoTEC ******/
CREATE DATABASE [MercaditoTEC]
GO


USE [MercaditoTEC]
GO


/* Morado */

/****** Object:  Table Persona ******/
CREATE TABLE Persona(
	idPersona						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	nombre							VARCHAR(75)								NOT NULL,
	apellidos						VARCHAR(150)							NOT NULL,
	telefono						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Curso ******/
CREATE TABLE Curso(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table MetodoPago ******/
CREATE TABLE MetodoPago(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Categoria ******/
CREATE TABLE Categoria(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Provincia ******/
CREATE TABLE Provincia(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table TasaCambio ******/
CREATE TABLE TasaCambio(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/* Rosado */

/****** Object:  Table Estudiante ******/
CREATE TABLE Estudiante(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Canton ******/
CREATE TABLE Canton(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Empleador ******/
CREATE TABLE Empleador(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Administrador ******/
CREATE TABLE Administrador(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table EmpleadoLibreria ******/
CREATE TABLE EmpleadoLibreria(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/* Rojo */

/****** Object:  Table Tutor ******/
CREATE TABLE Tutor(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Tutorado ******/
CREATE TABLE Tutorado(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Vendedor ******/
CREATE TABLE Vendedor(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Ubicacion ******/
CREATE TABLE Ubicacion(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Comprador ******/
CREATE TABLE Comprador(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Aplicante ******/
CREATE TABLE Aplicante(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Canje ******/
CREATE TABLE Canje(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/* Anaranjado */

/****** Object:  Table CursoTutor ******/
CREATE TABLE CursoTutor(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Producto ******/
CREATE TABLE Producto(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Servicio ******/
CREATE TABLE Servicio(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table OferaLaboral ******/
CREATE TABLE OferaLaboral(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/* Amarillo */

/****** Object:  Table PracticaTutor ******/
CREATE TABLE PracticaTutor(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table CursoTutorado ******/
CREATE TABLE CursoTutorado(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table MetodoPagoProducto ******/
CREATE TABLE MetodoPagoProducto(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table UbicacionProducto ******/
CREATE TABLE UbicacionProducto(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table ImagenProducto ******/
CREATE TABLE ImagenProducto(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table MetodoPagoServicio ******/
CREATE TABLE MetodoPagoServicio(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table UbicacionServicio ******/
CREATE TABLE UbicacionServicio(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table ImagenServicio ******/
CREATE TABLE ImagenServicio(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table CompraProducto ******/
CREATE TABLE CompraProducto(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table ContratacionServicio ******/
CREATE TABLE ContratacionServicio(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table AplicanteOfertaLaboral ******/
CREATE TABLE AplicanteOfertaLaboral(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/* Verde */

/****** Object:  Table TemaPracticaTutor ******/
CREATE TABLE TemaPracticaTutor(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table PracticaTutorMetodoPago ******/
CREATE TABLE PracticaTutorMetodoPago(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table CompraPractica ******/
CREATE TABLE CompraPractica(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table PracticaTutorado ******/
CREATE TABLE PracticaTutorado(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table EvaluacionVendedorProducto ******/
CREATE TABLE EvaluacionVendedorProducto(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table EvaluacionVendedorServicio ******/
CREATE TABLE EvaluacionVendedorServicio(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO


/* Azul */

/****** Object:  Table EvaluacionTutor ******/
CREATE TABLE EvaluacionTutor(
	id								INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	atributo						VARCHAR(75)								NOT NULL
)
GO

