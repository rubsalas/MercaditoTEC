
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
MercaditoTEC - Triggers
--------------------------------------------------------------------
*/


--USE [MercaditoTEC]
--GO


/*
 * Cuando se crea un Estudiante se deberan crear las relaciones
 * con Tutor, Tutorado, Vendedor, Tutorado y Comprador
 */
CREATE TRIGGER AfterINSERTEstudiante on Estudiante
FOR INSERT
AS DECLARE @idEstudiante INT;

SELECT @idEstudiante = ins.idEstudiante FROM INSERTED ins;

--Se inserta un Tutor
INSERT INTO Tutor (idEstudiante, calificacionPromedioTutor) values (@idEstudiante, 0);
--Se inserta un Tutorado
INSERT INTO Tutorado (idEstudiante) values (@idEstudiante);
--Se inserta un Vendedor
INSERT INTO Vendedor (idEstudiante, calificacionPromedioProductos, calificacionPromedioServicios) values (@idEstudiante, 0, 0);
--Se inserta un Tutorado
INSERT INTO Tutorado (idEstudiante) values (@idEstudiante);
--Se inserta un Comprador
INSERT INTO Comprador (idEstudiante) values (@idEstudiante);

PRINT 'Se ha creado los datos asociados al estudiante' + STR(@idEstudiante) + ' en las tablas de Tutor, Tutorado, Vendedor, Tutorado y Comprador.'

GO
