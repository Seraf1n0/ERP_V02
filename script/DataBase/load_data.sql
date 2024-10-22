USE ERP
GO

-- Departamentos existentes
INSERT INTO RRHH.Departamento (nombre, codigo) VALUES
('Producción', 'PROD'),
('Recursos Humanos', 'RRHH'),
('Ventas', 'VENT');


-- Primeros puestos cargados
INSERT INTO RRHH.Puesto (nombre, nombreD_Departamento, activo) VALUES
('Gerente de Producción', 'Producción', 1),
('Operario de Planta', 'Producción', 1),
('Gerente de Recursos Humanos', 'Recursos Humanos', 1),
('Analista de Recursos Humanos', 'Recursos Humanos', 1),
('Gerente de Ventas', 'Ventas', 1),
('Ejecutivo de Ventas', 'Ventas', 1);


-- Modulos base (modificable)
INSERT INTO RRHH.Modulo (nombreModulo, activo) VALUES
('Empleados', 1),
('Planilla', 1),
('Clientes', 1),
('Histórico de Puestos', 1),
('Historico de Salarios', 1),
('Facturación', 1),
('Inventario', 1),
('Entradas de Inventario', 1),
('Salidas de Inventario', 1),
('Movimientos de Inventarios', 1),
('Casos', 1),
('Tareas', 1);

-- Modificables y revisar los siguientes inserts:

-- Bodegas iniciales
INSERT INTO Produccion.Bodega (codigo, nombre, provincia, canton, distrito, seniaExacta, toneladasCapacidad, espacioCubico, activo)
VALUES
('B001', 'Bodega Central', 'San José', 'San José', 'Carmen', 'Avenida Central, frente al parque', 100, 500, 1),
('B002', 'Bodega Este', 'Cartago', 'Cartago', 'Oreamuno', '300 metros este del parque central', 50, 300, 1);

-- Familias de articulos
INSERT INTO Produccion.Familia (codigo, nombre, descripcion, activo)
VALUES
('F001', 'Bebidas', 'Refrescos y productos liquidos', 1),
('F002', 'Ropa', 'Artículos de vestimenta', 1),
('F003', 'Enlatados', 'Comida enlatada y conservas', 1),
('F004', 'Carnes', 'Carnes y procesados', 1);

-- Articulos en familias
INSERT INTO Produccion.Articulo (nombre, codigoF_Familia, codigo, precio, peso, descripcion, marca, activo)
VALUES
-- Artículos para la familia Bebidas
('Coca-Cola 1L', 'F001', 1001, 1.50, 1.0, 'Refresco gaseoso Coca-Cola 1 litro', 'Coca-Cola', 1),
('Pepsi 1L', 'F001', 1002, 1.40, 1.0, 'Refresco gaseoso Pepsi 1 litro', 'Pepsi', 1),

-- Artículos para la familia Ropa
('Camiseta Nike', 'F002', 2001, 20.00, 0.3, 'Camiseta deportiva marca Nike', 'Nike', 1),
('Pantalón Levis', 'F002', 2002, 45.00, 0.8, 'Pantalón de mezclilla Levis 501', 'Levis', 1),

-- Artículos para la familia Enlatados
('Atún Van Camps', 'F003', 3001, 2.50, 0.15, 'Atún enlatado en agua marca Van Camps', 'Van Camps', 1),
('Frijoles La Costeña', 'F003', 3002, 1.20, 0.4, 'Frijoles refritos marca La Costeña', 'La Costeña', 1),

-- Artículos para la familia Carnes
('Carne de res 1kg', 'F004', 4001, 10.00, 1.0, 'Carne de res fresca 1 kilogramo', 'Carnes Finas', 1),
('Pechuga de pollo 1kg', 'F004', 4002, 8.00, 1.0, 'Pechuga de pollo fresca 1 kilogramo', 'Pollos del Valle', 1);


-- Asignar familias a bodegas

-- Relación entre familias y bodegas
INSERT INTO Produccion.FamiliaBodega (codigoF_Familia, codigoB_Bodega)
VALUES
('F001', 'B001'),
('F002', 'B001'),
('F003', 'B002'),
('F004', 'B002');

-- Clientes 
INSERT INTO Ventas.Cliente (cedula, tipoCedula, fax, primerNombre, segundoNombre, primerApellido, segundoApellido, email, provincia, canton, distrito, seniaExacta, activo, zona, sector)
VALUES
-- Persona
('1-1234-5678', 2, '22334455', 'Juan', 'Carlos', 'Perez', 'Gomez', 'juan.perez@mail.com', 'San José', 'San José', 'Carmen', 'Avenida 1, calle 3, casa 45', 1, 1, 2),

-- Empresa
('3-101-234567', 1, '22556677', 'Industria XYZ S.A.', NULL, NULL, NULL, 'contacto@xyz.com', 'Heredia', 'Heredia', 'San Francisco', 'Zona Industrial, nave 12', 1, 2, 3),

-- Persona
('2-0987-6543', 2, '24446688', 'Maria', 'Elena', 'Lopez', 'Ramirez', 'maria.lopez@mail.com', 'Cartago', 'Cartago', 'Oreamuno', '100 metros norte del parque central', 1, 3, 1),

-- Empresa
('3-102-345678', 1, '22778899', 'Comercial ABC S.A.', NULL, NULL, NULL, 'ventas@abc.com', 'Alajuela', 'Alajuela', 'San Rafael', 'Frente a la gasolinera', 1, 1, 3),

-- Persona
('1-9876-5432', 2, '22889900', 'Carlos', NULL, 'Rodriguez', 'Salas', 'carlos.rodriguez@mail.com', 'Guanacaste', 'Liberia', 'Liberia', 'Avenida Central, casa 10', 1, 2, 1);
