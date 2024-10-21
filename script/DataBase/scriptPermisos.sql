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
    '102340567',               -- c�dula
    'Vendedor ambulante',     -- nombrePuesto_Puesto
    'Carlos',                  -- primerNombre
    'Andr�s',                  -- segundoNombre
    'Gonz�lez',                -- primerApellido
    'Rodr�guez',               -- segundoApellido
    1,                         -- g�nero (1 = Masculino, seg�n lo definido en tu tabla Ventas.Genero)
    'carlos.gonzalez@mail.com', -- email
    'San Jos�',                -- provincia
    'Montes de Oca',           -- cant�n
    'San Pedro',               -- distrito
    '200 metros norte del parque central', -- seniaExacta
    '2024-10-21',              -- fechaRegistro (la fecha de hoy)
    '1985-05-10',              -- fechaNacimiento
    3500.50,                   -- salarioActual
    2,                         -- tipoCedula (1 = Nacional, seg�n lo definido en tu tabla Ventas.TipoCedula)
    1,                          -- activo (1 = Activo, 0 = Inactivo)
	'pepito', 'perez'
);

insert into RRHH.Puesto values('Vendedor ambulante', 'Producci�n', 1)
--Primero creo el rol
insert into RRHH.Rol values ('Aqu� pongo aleatorio', 1)
-- Inserto los nombres de los m�dulos
insert into RRHH.Modulo values ('Empleados', 1),
('Planilla', 1),
('Clientes', 1),
('Salidas de Inventari', 1)


