/*
Inserts en las tablas catalogo no modificables.

Funcionalidad: Cada tabla posee una PK que la identifica (en su mayor�a ID Integers), lo cual permite hacer agrupamientos rapidos
			   Por cada tabla puede consultarse de forma generar para llenar ComboBoxes necesarios, Pero no pueden modificarse, unicamente Consultas, Deletes E Inserts.
*/

USE ERP
GO

INSERT INTO Ventas.TipoCedula (tipo)
VALUES
('F�sica'),
('Jur�dica');

INSERT INTO RRHH.Departamento (nombre, codigo)
VALUES 
('Recursos Humanos', 'D1'),
('Produccion', 'D2'),
('Ventas', 'D3');

INSERT INTO Ventas.Genero (descripcion)
VALUES 
('Masculino'),
('Femenino'),
('Otro');

INSERT INTO Ventas.Estado (descripcion)
VALUES
('Aceptada'),
('Rechazada'),
('En proceso'),
('Anulada');

INSERT INTO Ventas.Etapa (descripcion)
VALUES
('Pendiente'),
('En proceso'),
('Realizada')

INSERT INTO Ventas.Sector (descripcion)
VALUES
('Agropecuario'),
('Construcci�n'),
('Agricultura'),
('Comercio');

INSERT INTO Ventas.Zona (descripcion)
VALUES
('Regi�n Central'),
('Regi�n Chorotega'),
('Regi�n Pac�fico Central'),
('Regi�n Brunca'),
('Regi�n Huetar Atl�ntica'),
('Regi�n Huetar Norte');

INSERT INTO Ventas.Probabilidad (descripcion)
VALUES
(0),
(25),
(50),
(75),
(100);