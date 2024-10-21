INSERT INTO RRHH.Usuario (
    cedula,
    nombrePuesto_Puesto,
    primerNombre,
    segundoNombre,
    primerApellido,
    segundoApellido,
    genero,
    email,
    provincia,
    canton,
    distrito,
    seniaExacta,
    fechaRegistro,
    fechaNacimiento,
    salarioActual,
    tipoCedula,
    activo,
	usuario,
	contrasenia
) 
VALUES (
    '102340567',               -- cédula
    'Vendedor ambulante',     -- nombrePuesto_Puesto
    'Carlos',                  -- primerNombre
    'Andrés',                  -- segundoNombre
    'González',                -- primerApellido
    'Rodríguez',               -- segundoApellido
    1,                         -- género (1 = Masculino, según lo definido en tu tabla Ventas.Genero)
    'carlos.gonzalez@mail.com', -- email
    'San José',                -- provincia
    'Montes de Oca',           -- cantón
    'San Pedro',               -- distrito
    '200 metros norte del parque central', -- seniaExacta
    '2024-10-21',              -- fechaRegistro (la fecha de hoy)
    '1985-05-10',              -- fechaNacimiento
    3500.50,                   -- salarioActual
    2,                         -- tipoCedula (1 = Nacional, según lo definido en tu tabla Ventas.TipoCedula)
    1,                          -- activo (1 = Activo, 0 = Inactivo)
	'pepito', 'perez'
);

insert into RRHH.Puesto values('Vendedor ambulante', 'Producción', 1)
--Primero creo el rol
insert into RRHH.Rol values ('Aquí pongo aleatorio', 1)
-- Inserto los nombres de los módulos
insert into RRHH.Modulo values ('Empleados', 1),
('Planilla', 1),
('Clientes', 1),
('Salidas de Inventari', 1)


