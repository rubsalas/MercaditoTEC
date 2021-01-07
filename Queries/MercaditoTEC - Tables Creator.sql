
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
	telefono						VARCHAR(30)								NOT NULL
)
GO


/****** Object:  Table MetodoPago ******/
CREATE TABLE Carrera(
	idCarrera						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	nombre							VARCHAR(150)								NOT NULL,
)
GO


/****** Object:  Table MetodoPago ******/
CREATE TABLE MetodoPago(
	idMetodoPago					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	metodoPago						VARCHAR(75)								NOT NULL,
	puntaje							INT										NOT NULL
)
GO


/****** Object:  Table Categoria ******/
CREATE TABLE Categoria(
	idCategoria						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	categoria						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table Provincia ******/
CREATE TABLE Provincia(
	idProvincia						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	provincia						VARCHAR(75)								NOT NULL
)
GO


/****** Object:  Table TasaCambio ******/
CREATE TABLE TasaCambio(
	idTasaCambio					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	tasaCambio						INT										NOT NULL,
	fechaPublicacion				DATETIME2								NOT NULL
)
GO


/* Rosado */

/****** Object:  Table Estudiante ******/
CREATE TABLE Estudiante(
	idEstudiante					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idPersona						INT										NOT NULL,
	correoInstitucional				VARCHAR(150)							NOT NULL,
	contrasena						VARCHAR(75)								NOT NULL,
	puntosCanje						INT										NOT NULL,
	haIngresadoWeb					BIT										NOT NULL,
	haIngresadoApp					BIT										NOT NULL,
	FOREIGN KEY(idEstudiante)					REFERENCES Persona(idPersona)
)
GO


/****** Object:  Table Curso ******/
CREATE TABLE Curso(
	idCurso							INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	nombre							VARCHAR(150) 							NOT NULL,
	codigo							VARCHAR(30)								NOT NULL,
	idCarrera						INT										NOT NULL,
	FOREIGN KEY(idCarrera)						REFERENCES Carrera(idCarrera)
)
GO


/****** Object:  Table Canton ******/
CREATE TABLE Canton(
	idCanton						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idProvincia						INT										NOT NULL,
	canton							VARCHAR(75)								NOT NULL,
	FOREIGN KEY(idProvincia)					REFERENCES Provincia(idProvincia)
)
GO


/****** Object:  Table Empleador ******/
CREATE TABLE Empleador(
	idEmpleador						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idPersona						INT										NOT NULL,
	correo							VARCHAR(150)							NOT NULL,
	usuario							VARCHAR(75)								NOT NULL,
	contrasena						VARCHAR(75)								NOT NULL,
	puesto							VARCHAR(75)								NOT NULL,
	telefonoEmpresa					VARCHAR(30)								NOT NULL,
	correoEmpresa					VARCHAR(150)							NOT NULL,
	verificado						BIT										NOT NULL,
	FOREIGN KEY(idPersona)						REFERENCES Persona(idPersona)
)
GO


/****** Object:  Table Administrador ******/
CREATE TABLE Administrador(
	idAdministrador					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idPersona						INT										NOT NULL,
	usuario							VARCHAR(75)								NOT NULL,
	contrasena						VARCHAR(75)								NOT NULL,
	FOREIGN KEY(idPersona)						REFERENCES Persona(idPersona)
)
GO


/****** Object:  Table EmpleadoLibreria ******/
CREATE TABLE EmpleadoLibreria(
	idEmpleadoLibreria				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idPersona						INT										NOT NULL,
	usuario							VARCHAR(75)								NOT NULL,
	contrasena						VARCHAR(75)								NOT NULL,
	FOREIGN KEY(idPersona)						REFERENCES Persona(idPersona)
)
GO


/* Rojo */

/****** Object:  Table Tutor ******/
CREATE TABLE Tutor(
	idTutor							INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idEstudiante					INT										NOT NULL,
	calificacionPromedio			INT										NOT NULL,
	FOREIGN KEY(idEstudiante)					REFERENCES Estudiante(idEstudiante)
)
GO


/****** Object:  Table Tutorado ******/
CREATE TABLE Tutorado(
	idTutorado						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idEstudiante					INT										NOT NULL,
	FOREIGN KEY(idEstudiante)					REFERENCES Estudiante(idEstudiante)
)
GO


/****** Object:  Table Vendedor ******/
CREATE TABLE Vendedor(
	idVendedor						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idEstudiante					INT										NOT NULL,
	calificacionPromedioProductos	INT										NOT NULL,
	calificacionPromedioServicios	INT										NOT NULL,
	FOREIGN KEY(idEstudiante)					REFERENCES Estudiante(idEstudiante)
)
GO


/****** Object:  Table Ubicacion ******/
CREATE TABLE Ubicacion(
	idUbicacion						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idCanton						INT										NOT NULL,
	distrito						VARCHAR(75)								NOT NULL,
	FOREIGN KEY(idCanton)						 REFERENCES Canton(idCanton)
)
GO


/****** Object:  Table Comprador ******/
CREATE TABLE Comprador(
	idComprador						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idEstudiante					INT										NOT NULL,
	FOREIGN KEY(idEstudiante)					REFERENCES Estudiante(idEstudiante)
)
GO


/****** Object:  Table Aplicante ******/
CREATE TABLE Aplicante(
	idAplicante						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idEstudiante					INT										NOT NULL,
	FOREIGN KEY(idEstudiante)					REFERENCES Estudiante(idEstudiante) 
)
GO


/****** Object:  Table Canje ******/
CREATE TABLE Canje(
	idCanje							INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idEstudiante					INT										NOT NULL,
	idTasaCambio					INT										NOT NULL,
	productoLibreria				VARCHAR(150)							NOT NULL,
	puntosCanjeados					INT										NOT NULL,
	fechaCanje						DATETIME2								NOT NULL,
	FOREIGN KEY(idEstudiante)					REFERENCES Estudiante(idEstudiante),
	FOREIGN KEY(idTasaCambio)					REFERENCES TasaCambio(idTasaCambio)
)
GO


/* Anaranjado */

/****** Object:  Table CursoTutor ******/
CREATE TABLE CursoTutor(
	idCursoTutor					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idTutor							INT										NOT NULL,
	idCurso							INT										NOT NULL,
	notaObtenida					INT										NOT NULL,
	temas							VARCHAR(500)							NOT NULL,
	FOREIGN KEY(idTutor)						REFERENCES Tutor(idTutor),
	FOREIGN KEY(idCurso)						REFERENCES Curso(idCurso)
)
GO


/****** Object:  Table Producto ******/
CREATE TABLE Producto(
	idProducto						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idVendedor						INT										NOT NULL,
	nombre							VARCHAR(150)							NOT NULL,
	descripcion						VARCHAR(500)							NOT NULL,
	idCategoria						INT										NOT NULL,
	precio							INT										NOT NULL,
	fechaPublicacion				DATETIME2								NOT NULL,
	FOREIGN KEY(idVendedor)						REFERENCES Vendedor(idVendedor),
	FOREIGN KEY(idCategoria)					REFERENCES Categoria(idCategoria)
)
GO


/****** Object:  Table Servicio ******/
CREATE TABLE Servicio(
	idServicio						INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idVendedor						INT										NOT NULL,
	nombre							VARCHAR(150)							NOT NULL,
	descripcion						VARCHAR(500)							NOT NULL,
	precio							INT										NOT NULL,
	fechaPublicacion				DATETIME2								NOT NULL,
	FOREIGN KEY(idVendedor)						REFERENCES Vendedor(idVendedor)
)
GO


/****** Object:  Table OferaLaboral ******/
CREATE TABLE OfertaLaboral(
	idOfertaLaboral					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idEmpleador						INT										NOT NULL,
	nombrePuesto					VARCHAR(150)							NOT NULL,
	responsabilidades				VARCHAR(500)							NOT NULL,
	requerimientos					VARCHAR(500)							NOT NULL,
	idCarrera						INT										NOT NULL,
	idUbicacion						INT										NOT NULL,
	jornadaLaboral					VARCHAR(75)								NOT NULL,
	link							VARCHAR(300)							NOT NULL,
	fechaPublicacion				DATETIME2								NOT NULL,
	FOREIGN KEY(idEmpleador)					REFERENCES Empleador(idEmpleador),
	FOREIGN KEY(idCarrera)						REFERENCES Carrera(idCarrera),
	FOREIGN KEY(idUbicacion)					REFERENCES Ubicacion(idUbicacion)
)
GO


/* Amarillo */

/****** Object:  Table PracticaTutor ******/
CREATE TABLE PracticaTutor(
	idPracticaTutor					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idCursoTutor					INT										NOT NULL,
	nombre							VARCHAR(150)							NOT NULL,
	descripcion						VARCHAR(500)							NOT NULL,
	cantidadEjercicios				INT										NOT NULL,
	dificultad						VARCHAR(75)								NOT NULL,
	precio							INT										NOT NULL,
	pdfPractica						VARCHAR(75)								NOT NULL,
	pdfSolucion						VARCHAR(75)								NOT NULL,
	FOREIGN KEY(idCursoTutor)					REFERENCES CursoTutor(idCursoTutor)
)
GO


/****** Object:  Table CursoTutorado ******/
CREATE TABLE CursoTutorado(
	idCursoTutorado					INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idTutorado						INT										NOT NULL,
	idCursoTutor					INT										NOT NULL,
	FOREIGN KEY(idTutorado)						REFERENCES Tutorado(idTutorado),
	FOREIGN KEY(idCursoTutor)					REFERENCES CursoTutor(idCursoTutor)
)
GO


/****** Object:  Table MetodoPagoProducto ******/
CREATE TABLE MetodoPagoProducto(
	idMetodoPagoProducto			INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idProducto						INT										NOT NULL,
	idMetodoPago					INT										NOT NULL,
	numeroCuenta					VARCHAR(75)								NULL,
	FOREIGN KEY(idProducto)						REFERENCES Producto(idProducto),
	FOREIGN KEY(idMetodoPago)					REFERENCES MetodoPago(idMetodoPago)
)
GO


/****** Object:  Table UbicacionProducto ******/
CREATE TABLE UbicacionProducto(
	idUbicacionProducto				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idProducto						INT										NOT NULL,
	idUbicacion						INT										NOT NULL,
	FOREIGN KEY(idProducto)						REFERENCES Producto(idProducto),
	FOREIGN KEY(idUbicacion)					REFERENCES Ubicacion(idUbicacion)
)
GO


/****** Object:  Table ImagenProducto ******/
CREATE TABLE ImagenProducto(
	idImagenProducto				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idProducto						INT										NOT NULL,
	imagen							VARCHAR(75)								NOT NULL,
	FOREIGN KEY(idProducto)						REFERENCES Producto(idProducto)
)
GO


/****** Object:  Table MetodoPagoServicio ******/
CREATE TABLE MetodoPagoServicio(
	idMetodoPagoServicio			INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idServicio						INT										NOT NULL,
	idMetodoPago					INT										NOT NULL,
	numeroCuenta					VARCHAR(75)								NULL,
	FOREIGN KEY(idServicio)						REFERENCES Servicio(idServicio),
	FOREIGN KEY(idMetodoPago)					REFERENCES MetodoPago(idMetodoPago)
)
GO


/****** Object:  Table UbicacionServicio ******/
CREATE TABLE UbicacionServicio(
	idUbicacionServicio				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idServicio						INT										NOT NULL,
	idUbicacion						INT										NOT NULL,
	FOREIGN KEY(idServicio)						REFERENCES Servicio(idServicio),
	FOREIGN KEY(idUbicacion)					REFERENCES Ubicacion(idUbicacion)
)
GO


/****** Object:  Table ImagenServicio ******/
CREATE TABLE ImagenServicio(
	idImagenServicio				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idServicio						INT										NOT NULL,
	imagen							VARCHAR(75)								NOT NULL,
	FOREIGN KEY(idServicio)						REFERENCES Servicio(idServicio)
)
GO


/****** Object:  Table CompraProducto ******/
CREATE TABLE CompraProducto(
	idCompraProducto				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idProducto						INT										NOT NULL,
	idComprador						INT										NOT NULL,
	confirmacionVendedor			BIT										NOT NULL,
	confirmacionComprador			BIT										NOT NULL,
	evaluacionCompletada			BIT										NOT NULL,
	puntosCanjeObtenidos			INT										NOT NULL,
	FOREIGN KEY(idProducto)						REFERENCES Producto(idProducto),
	FOREIGN KEY(idComprador)					REFERENCES Comprador(idComprador)
)
GO


/****** Object:  Table ContratacionServicio ******/
CREATE TABLE ContratacionServicio(
	idContratacionServicio			INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idServicio						INT										NOT NULL,
	idComprador						INT										NOT NULL,
	confirmacionVendedor			BIT										NOT NULL,
	confirmacionComprador			BIT										NOT NULL,
	evaluacionCompletada			BIT										NOT NULL,
	puntosCanjeObtenidos			INT										NOT NULL,
	FOREIGN KEY(idServicio)						REFERENCES Servicio(idServicio),
	FOREIGN KEY(idComprador)					REFERENCES Comprador(idComprador)
)
GO


/****** Object:  Table AplicanteOfertaLaboral ******/
CREATE TABLE AplicanteOfertaLaboral(
	idAplicanteOfertaLaboral		INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idOfertaLaboral					INT										NOT NULL,
	idAplicante						INT										NOT NULL,
	pdfCurriculum					VARCHAR(75)								NOT NULL,
	fechaAplicacion					DATETIME2								NOT NULL,
	FOREIGN KEY(idOfertaLaboral)				REFERENCES OfertaLaboral(idOfertaLaboral),
	FOREIGN KEY(idAplicante)					REFERENCES Aplicante(idAplicante)
)
GO


/* Verde */

/****** Object:  Table TemaPracticaTutor ******/
CREATE TABLE TemaPracticaTutor(
	idTemaPracticaTutor				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idPracticaTutor					INT										NOT NULL,
	tema							VARCHAR(150)							NOT NULL,
	FOREIGN KEY(idPracticaTutor)				REFERENCES PracticaTutor(idPracticaTutor)
)
GO


/****** Object:  Table PracticaTutorMetodoPago ******/
CREATE TABLE PracticaTutorMetodoPago(
	idPracticaTutorMetodoPago		INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idPracticaTutor					INT										NOT NULL,
	idMetodoPago					INT										NOT NULL,
	numeroCuenta					VARCHAR(75)								NULL,
	FOREIGN KEY(idPracticaTutor)				REFERENCES PracticaTutor(idPracticaTutor),
	FOREIGN KEY(idMetodoPago)					REFERENCES MetodoPago(idMetodoPago)
)
GO


/****** Object:  Table CompraPractica ******/
CREATE TABLE CompraPractica(
	idCompraPractica				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idPracticaTutor					INT										NOT NULL,
	idTutorado						INT										NOT NULL,
	confirmacionTutor				BIT										NOT NULL,
	confirmacionTutorado			BIT										NOT NULL,
	evaluacionCompletada			BIT										NOT NULL,
	puntosCanjeObtenidos			INT										NOT NULL,
	FOREIGN KEY(idPracticaTutor)				REFERENCES PracticaTutor(idPracticaTutor),
	FOREIGN KEY(idTutorado)						REFERENCES Tutorado(idTutorado)
)
GO


/****** Object:  Table PracticaTutorado ******/
CREATE TABLE PracticaTutorado(
	idPracticaTutorado				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idCursoTutorado					INT										NOT NULL,
	idPracticaTutor					INT										NOT NULL,
	FOREIGN KEY(idCursoTutorado)				REFERENCES CursoTutorado(idCursoTutorado),
	FOREIGN KEY(idPracticaTutor)				REFERENCES PracticaTutor(idPracticaTutor)
)
GO


/****** Object:  Table EvaluacionVendedorProducto ******/
CREATE TABLE EvaluacionVendedorProducto(
	idEvaluacionVendedorProducto	INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idVendedor						INT										NOT NULL,
	calificacion					INT										NOT NULL,
	comentario						VARCHAR(500)							NOT NULL,
	idCompraProducto				INT										NOT NULL,
	FOREIGN KEY(idVendedor)						REFERENCES Vendedor(idVendedor),
	FOREIGN KEY(idCompraProducto)				REFERENCES CompraProducto(idCompraProducto)
)
GO


/****** Object:  Table EvaluacionVendedorServicio ******/
CREATE TABLE EvaluacionVendedorServicio(
	idEvaluacionVendedorServicio	INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idVendedor						INT										NOT NULL,
	calificacion					INT										NOT NULL,
	comentario						VARCHAR(500)							NOT NULL,
	idContratacionServicio			INT										NOT NULL,
	FOREIGN KEY(idVendedor)						REFERENCES Vendedor(idVendedor),
	FOREIGN KEY(idContratacionServicio)			REFERENCES ContratacionServicio(idContratacionServicio)
)
GO


/* Azul */

/****** Object:  Table EvaluacionTutor ******/
CREATE TABLE EvaluacionTutor(
	idEvaluacionTutor				INT	IDENTITY (1, 1) PRIMARY KEY			NOT NULL,
	idTutor							INT										NOT NULL,
	calificacion					INT										NOT NULL,
	comentario						VARCHAR(500)							NOT NULL,
	idCompraPractica				INT										NOT NULL,
	FOREIGN KEY(idTutor)						REFERENCES Tutor(idTutor),
	FOREIGN KEY(idCompraPractica)				REFERENCES CompraPractica(idCompraPractica)
)
GO

