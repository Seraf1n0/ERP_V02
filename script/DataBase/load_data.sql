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
('Histórico de Salarios', 1),
('Facturación', 1),
('Inventario', 1),
('Cotizaciones',1),
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
('B002', 'Bodega Este', 'Cartago', 'Cartago', 'Oreamuno', '300 metros este del parque central', 50, 300, 1),
('B003', 'Bodega Norte', 'Heredia', 'Heredia', 'San Francisco', '200 metros norte de la plaza central', 60, 350, 1),
('B004', 'Bodega Sur', 'Puntarenas', 'Puntarenas', 'Barranca', 'Contiguo al muelle de carga', 80, 400, 1),
('B005', 'Bodega Oeste', 'Alajuela', 'Alajuela', 'San Rafael', 'Frente al estadio municipal', 70, 320, 1);

-- Familias de articulos
INSERT INTO Produccion.Familia (codigo, nombre, descripcion, activo)
VALUES
('F001', 'Bebidas', 'Refrescos y productos liquidos', 1),
('F002', 'Ropa', 'Artículos de vestimenta', 1),
('F003', 'Enlatados', 'Comida enlatada y conservas', 1),
('F004', 'Carnes', 'Carnes y procesados', 1),
('F005', 'Frutas', 'Frutas y verduras', 1);

-- Articulos en familias
INSERT INTO Produccion.Articulo (nombre, codigoF_Familia, codigo, precio, peso, descripcion, marca, activo)
VALUES
-- Artículos para la familia Bebidas
('Coca-Cola 1L', 'F001', 1001, 1.50, 1.0, 'Refresco gaseoso Coca-Cola 1 litro', 'Coca-Cola', 1),
('Pepsi 1L', 'F001', 1002, 1.40, 1.0, 'Refresco gaseoso Pepsi 1 litro', 'Pepsi', 1),
('Sprite 1L', 'F001', 1003, 1.50, 1.0, 'Refresco gaseoso Sprite 1 litro', 'Sprite', 1),
('Fanta 1L', 'F001', 1004, 1.50, 1.0, 'Refresco gaseoso Fanta 1 litro', 'Fanta', 1),
('Agua Dasani 1L', 'F001', 1005, 1.00, 1.0, 'Agua purificada Dasani 1 litro', 'Dasani', 1),


-- Artículos para la familia Ropa
('Camiseta Nike', 'F002', 2001, 20.00, 0.3, 'Camiseta deportiva marca Nike', 'Nike', 1),
('Pantalón Levis', 'F002', 2002, 45.00, 0.8, 'Pantalón de mezclilla Levis 501', 'Levis', 1),
('Sudadera Adidas', 'F002', 2003, 35.00, 0.5, 'Sudadera deportiva marca Adidas', 'Adidas', 1),
('Polo Lacoste', 'F002', 2004, 60.00, 0.4, 'Camisa polo de algodón marca Lacoste', 'Lacoste', 1),
('Zapatos deportivos Puma', 'F002', 2005, 70.00, 0.9, 'Zapatos deportivos marca Puma', 'Puma', 1),

-- Artículos para la familia Enlatados
('Atún Van Camps', 'F003', 3001, 2.50, 0.15, 'Atún enlatado en agua marca Van Camps', 'Van Camps', 1),
('Frijoles La Costeña', 'F003', 3002, 1.20, 0.4, 'Frijoles refritos marca La Costeña', 'La Costeña', 1),
('Maíz Del Monte', 'F003', 3003, 1.30, 0.35, 'Maíz dulce enlatado marca Del Monte', 'Del Monte', 1),
('Sardinas en tomate', 'F003', 3004, 1.80, 0.25, 'Sardinas en salsa de tomate marca Pacific', 'Pacific', 1),
('Duraznos en almíbar', 'F003', 3005, 2.00, 0.5, 'Duraznos en almíbar marca Herdez', 'Herdez', 1),

-- Artículos para la familia Carnes
('Carne de res 1kg', 'F004', 4001, 10.00, 1.0, 'Carne de res fresca 1 kilogramo', 'Carnes Finas', 1),
('Pechuga de pollo 1kg', 'F004', 4002, 8.00, 1.0, 'Pechuga de pollo fresca 1 kilogramo', 'Pollos del Valle', 1),
('Chuleta de cerdo 1kg', 'F004', 4003, 9.50, 1.0, 'Chuleta de cerdo fresca 1 kilogramo', 'Carnes Finas', 1),
('Costillas de cerdo 1kg', 'F004', 4004, 11.00, 1.0, 'Costillas de cerdo frescas 1 kilogramo', 'Carnes Finas', 1),
('Bistec de res 1kg', 'F004', 4005, 12.00, 1.0, 'Bistec de res fresco 1 kilogramo', 'Carnes Finas', 1),

-- Artículos para la familia Frutas
('Manzana Roja', 'F005', 5001, 1.20, 0.2, 'Manzana roja fresca', 'Del Huerto', 1),
('Banana', 'F005', 5002, 0.50, 0.2, 'Banana madura', 'Del Huerto', 1),
('Naranja', 'F005', 5003, 0.60, 0.25, 'Naranja jugosa', 'Del Huerto', 1),
('Uvas', 'F005', 5004, 2.00, 0.5, 'Racimo de uvas frescas', 'Del Huerto', 1),
('Sandía', 'F005', 5005, 3.50, 1.5, 'Sandía fresca 1 kilogramo', 'Del Huerto', 1);

-- Relación entre familias y bodegas
INSERT INTO Produccion.FamiliaBodega (codigoF_Familia, codigoB_Bodega)
VALUES
('F001', 'B001'),
('F002', 'B001'),
('F003', 'B002'),
('F004', 'B002'),
('F005', 'B005');

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
('1-9876-5432', 2, '22889900', 'Carlos', NULL, 'Rodriguez', 'Salas', 'carlos.rodriguez@mail.com', 'Guanacaste', 'Liberia', 'Liberia', 'Avenida Central, casa 10', 1, 2, 1),

-- Persona
('1-5678-1234', 2, '22446655', 'Luis', 'Alberto', 'Vargas', 'Jimenez', 'luis.vargas@mail.com', 'Puntarenas', 'Puntarenas', 'Barranca', 'Detrás del centro comercial', 1, 3, 2),

-- Empresa
('3-103-456789', 1, '22667788', 'Servicios Rápidos S.A.', NULL, NULL, NULL, 'contacto@serviciosrapidos.com', 'San José', 'Desamparados', 'San Rafael Abajo', 'Calle 8, edificio 4', 1, 1, 3),

-- Persona
('1-8765-4321', 2, '22558877', 'Ana', 'Lucía', 'Gómez', 'Herrera', 'ana.gomez@mail.com', 'Alajuela', 'San Carlos', 'Quesada', '100 metros este del parque', 1, 2, 1),

-- Empresa
('3-104-567890', 1, '22991122', 'Productos del Norte S.A.', NULL, NULL, NULL, 'contacto@productosnorte.com', 'Heredia', 'Santo Domingo', 'Santo Tomás', 'Frente a la fábrica de muebles', 1, 2, 3),

-- Persona
('2-3456-7890', 2, '22331144', 'Sofia', 'Isabel', 'Castro', 'Morales', 'sofia.castro@mail.com', 'Limón', 'Limón', 'Matina', 'Avenida 4, casa 8', 1, 3, 1);

-- Números de telefonos por clientes
INSERT INTO Ventas.TelefonosCliente (numeroTelefono, duenio_Cliente)
VALUES
-- Teléfonos para los clientes ya ingresados
('88881111', '1-1234-5678'),
('88882222', '3-101-234567'),
('88883333', '2-0987-6543'),
('88884444', '3-102-345678'),
('88885555', '1-9876-5432'),
('88886666', '1-5678-1234'),
('88887777', '3-103-456789'),
('88888888', '1-8765-4321'),
('88889999', '3-104-567890'),
('88880000', '2-3456-7890');

-- Usuarios prueba
INSERT INTO RRHH.Usuario (
    cedula, nombrePuesto_Puesto, primerNombre, segundoNombre, primerApellido, segundoApellido, genero, email,
    provincia, canton, distrito, seniaExacta, fechaRegistro, fechaNacimiento, salarioActual, activo, usuario, contrasenia
) 
VALUES (
    '123456789', 'Gerente de Producción', 'Carlos', 'Andrés', 'Gómez', 'Ramírez', 1, 'carlos.gomez@empresa.com',
    'San José', 'Central', 'Carmen', 'Calle 123', GETDATE(), '1985-04-15', 1500000, 1, 'carlosg', 'pass123'
);

INSERT INTO RRHH.Usuario (
    cedula, nombrePuesto_Puesto, primerNombre, segundoNombre, primerApellido, segundoApellido, genero, email,
    provincia, canton, distrito, seniaExacta, fechaRegistro, fechaNacimiento, salarioActual, activo, usuario, contrasenia
) 
VALUES (
    '987654321', 'Analista de Recursos Humanos', 'María', 'Elena', 'Sánchez', 'Zamora', 2, 'maria.sanchez@empresa.com',
    'Alajuela', 'Central', 'San Rafael', 'Avenida 45', GETDATE(), '1990-06-30', 800000, 1, 'marias', 'pass456'
);

INSERT INTO RRHH.Usuario (
    cedula, nombrePuesto_Puesto, primerNombre, segundoNombre, primerApellido, segundoApellido, genero, email,
    provincia, canton, distrito, seniaExacta, fechaRegistro, fechaNacimiento, salarioActual, activo, usuario, contrasenia
) 
VALUES (
    '456789123', 'Ejecutivo de Ventas', 'Luis', 'Fernando', 'Martínez', 'Pérez', 1, 'luis.martinez@empresa.com',
    'Cartago', 'La Unión', 'Tres Ríos', 'Calle los Almendros', GETDATE(), '1987-11-22', 950000, 1, 'luism', 'pass789'
);

