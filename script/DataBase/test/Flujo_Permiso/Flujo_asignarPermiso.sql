USE ERP
GO

-- Se insertan entidades principales
-- Departamentos existentes
INSERT INTO RRHH.Departamento (nombre, codigo) VALUES
('Producci�n', 'PROD'),
('Recursos Humanos', 'RRHH'),
('Ventas', 'VENT');


-- Primeros puestos cargados
INSERT INTO RRHH.Puesto (nombre, nombreD_Departamento, activo) VALUES
('Gerente de Producci�n', 'Producci�n', 1),
('Operario de Planta', 'Producci�n', 1),
('Gerente de Recursos Humanos', 'Recursos Humanos', 1),
('Analista de Recursos Humanos', 'Recursos Humanos', 1),
('Gerente de Ventas', 'Ventas', 1),
('Ejecutivo de Ventas', 'Ventas', 1);

-- Lo de antes es para crear al Usuario entonces debe estar cargado obviamente

-- Se insertan las entidades necesarias para la asignaci�n de permisos
INSERT INTO RRHH.Modulo (nombreModulo, activo) VALUES
('Empleados', 1),
('Planilla', 1),
('Clientes', 1),
('Hist�rico de Puestos', 1),
('Historico de Salarios', 1),
('Facturaci�n', 1),
('Inventario', 1),
('Entradas de Inventario', 1),
('Salidas de Inventario', 1),
('Movimientos de Inventarios', 1),
('Casos', 1),
('Tareas', 1);

-- Cargar los permisos
INSERT INTO RRHH.Permisos (tipoPermiso) VALUES ('E'), ('V'), ('R');


-- Usuarios prueba
INSERT INTO RRHH.Usuario (
    cedula, nombrePuesto_Puesto, primerNombre, segundoNombre, primerApellido, segundoApellido, genero, email,
    provincia, canton, distrito, seniaExacta, fechaRegistro, fechaNacimiento, salarioActual, tipoCedula, activo, usuario, contrasenia
) 
VALUES (
    '123456789', 'Gerente de Producci�n', 'Carlos', 'Andr�s', 'G�mez', 'Ram�rez', 1, 'carlos.gomez@empresa.com',
    'San Jos�', 'Central', 'Carmen', 'Calle 123', GETDATE(), '1985-04-15', 1500000, 1, 1, 'carlosg', 'pass123'
);

INSERT INTO RRHH.Usuario (
    cedula, nombrePuesto_Puesto, primerNombre, segundoNombre, primerApellido, segundoApellido, genero, email,
    provincia, canton, distrito, seniaExacta, fechaRegistro, fechaNacimiento, salarioActual, tipoCedula, activo, usuario, contrasenia
) 
VALUES (
    '987654321', 'Analista de Recursos Humanos', 'Mar�a', 'Elena', 'S�nchez', 'Zamora', 2, 'maria.sanchez@empresa.com',
    'Alajuela', 'Central', 'San Rafael', 'Avenida 45', GETDATE(), '1990-06-30', 800000, 1, 1, 'marias', 'pass456'
);

INSERT INTO RRHH.Usuario (
    cedula, nombrePuesto_Puesto, primerNombre, segundoNombre, primerApellido, segundoApellido, genero, email,
    provincia, canton, distrito, seniaExacta, fechaRegistro, fechaNacimiento, salarioActual, tipoCedula, activo, usuario, contrasenia
) 
VALUES (
    '456789123', 'Ejecutivo de Ventas', 'Luis', 'Fernando', 'Mart�nez', 'P�rez', 1, 'luis.martinez@empresa.com',
    'Cartago', 'La Uni�n', 'Tres R�os', 'Calle los Almendros', GETDATE(), '1987-11-22', 950000, 1, 1, 'luism', 'pass789'
);

-- Roles, Se crean con un identificador para luego asignarlo a usuarios ya insertados:
INSERT INTO RRHH.Rol (nombreRol) VALUES ('Administrador'), ('Vendedor'), ('Empleado'); -- Se les da un identificador para usar este mismo y asignarlo

-- Asignamos roles a usuarios

INSERT INTO RRHH.RolUsuario (cedulaUsuario_Usuario, nombreRol) -- Pa carlos
VALUES ('123456789', 'Administrador');

INSERT INTO RRHH.RolUsuario (cedulaUsuario_Usuario, nombreRol)-- Para maria
VALUES ('987654321', 'Empleado');

INSERT INTO RRHH.RolUsuario (cedulaUsuario_Usuario, nombreRol) -- Pa luisillo
VALUES ('456789123', 'Vendedor');

-- Ahora a este rol le asignamos permisos de la forma: (rol, modulo, permiso)

-- Permisos para el rol administrador, el papu tiene todos los permisos en ese caso
INSERT INTO RRHH.PermisoModuloRol (nombreRol, nombreModulo, tipoPermiso)
VALUES 
    ('Administrador', 'Empleados', 1), 
    ('Administrador', 'Empleados', 2), 
    ('Administrador', 'Empleados', 3),
    
    ('Administrador', 'Planilla', 1), 
    ('Administrador', 'Planilla', 2), 
    ('Administrador', 'Planilla', 3),
    
    ('Administrador', 'Facturaci�n', 1),
    ('Administrador', 'Facturaci�n', 2),
    ('Administrador', 'Facturaci�n', 3),
    
    ('Administrador', 'Inventario', 1), 
    ('Administrador', 'Inventario', 2), 
    ('Administrador', 'Inventario', 3),
    
    ('Administrador', 'Casos', 1),
    ('Administrador', 'Casos', 2),
    ('Administrador', 'Casos', 3);

-- Permisos para ROL empleado
INSERT INTO RRHH.PermisoModuloRol (nombreRol, nombreModulo, tipoPermiso)
VALUES 
    ('Empleado', 'Planilla', 2), 
    ('Empleado', 'Hist�rico de Salarios', 2);

-- Permisos para el rol de vendedor
INSERT INTO RRHH.PermisoModuloRol (nombreRol, nombreModulo, tipoPermiso)
VALUES 
    ('Vendedor', 'Facturaci�n', 1),
    ('Vendedor', 'Facturaci�n', 2),
    ('Vendedor', 'Clientes', 1),
    ('Vendedor', 'Clientes', 2);

