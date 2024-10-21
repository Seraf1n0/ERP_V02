/*
Inserts en las tablas catalogo no modificables.

Funcionalidad: Cada tabla posee una PK que la identifica (en su mayoría ID Integers), lo cual permite hacer agrupamientos rapidos
			   Por cada tabla puede consultarse de forma generar para llenar ComboBoxes necesarios, Pero no pueden modificarse, unicamente Consultas, Deletes E Inserts.
*/

USE ERP
GO

INSERT INTO Ventas.Prioridad (descripcion) VALUES
('Alta'),
('Media'),
('Baja');

INSERT INTO Ventas.TipoCaso (descripcion) VALUES
('Soporte'),
('Consulta'),
('Reclamo');

INSERT INTO Ventas.EstadoFactura (descripcion) VALUES
('Pendiente'),
('Pagada'),
('Anulada'),
('Cancelada');

INSERT INTO Ventas.EstadoCaso (descripcion) VALUES
('Abierto'),
('Cerrado'),
('En proceso');

INSERT INTO Ventas.EstadoCotizacion (descripcion) VALUES
('Aprobada'),
('Rechazada'),
('En revisión');

INSERT INTO Ventas.Etapa (descripcion) VALUES
('Inicio'),
('Desarrollo'),
('Finalización');

INSERT INTO Ventas.Zona (descripcion) VALUES
('Región Central'),
('Región Chorotega'),
('Región Pacífico Central'),
('Región Brunca'),
('Región Huetar Atlántica'),
('Región Huetar Norte');

INSERT INTO Ventas.Sector (descripcion) VALUES
('Industrial'),
('Comercial'),
('Residencial');

INSERT INTO Ventas.Probabilidad (descripcion) VALUES
(10),
(25),
(50),
(75),
(90);

INSERT INTO Ventas.TipoCedula (tipo) VALUES
('Jurídica'),
('Personal');

INSERT INTO Ventas.Genero (descripcion) VALUES
('Femenino'),
('Masculino'),
('Otro');

INSERT INTO RRHH.Departamento (nombre, codigo) VALUES
('Producción', 'PROD'),
('Recursos Humanos', 'RRHH'),
('Ventas', 'VENT');

INSERT INTO Ventas.TipoCotizacion (descripcion) VALUES
('Estado'),
('Rápida'),
('Privada');
