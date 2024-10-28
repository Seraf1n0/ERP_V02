--Procedimiento para insertar usuarios
use ERP
go


create procedure InsertarUsuario
	@cedula varchar(20),
	@nombrePuesto varchar(150),
	@primerNombre varchar(20),
	@segundoNombre varchar(20) = NULL, --Para que pueda ser null
	@primerApellido varchar(20),
	@segundoApellido varchar(20),
	@genero varchar(10),
	@email varchar(50),
	@provincia varchar(20),
	@canton varchar(20),
	@distrito varchar(20),
	@seniaExacta varchar(100),
	@fechaNacimiento date,
	@salario float,
	@usuario varchar(15),
	@contrasenia varchar(15),
	@error varchar(50) output
as
begin try
	--Primero un select para el id del género
	declare @generoInt int;
	select @generoInt = ID from Ventas.Genero where descripcion = @genero;
	

	insert into RRHH.Usuario (cedula, 
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
	activo,
	usuario,
	contrasenia)
	values
	(@cedula,
	@nombrePuesto,
	@primerNombre,
	@segundoNombre,
	@primerApellido,
	@segundoApellido,
	@generoInt,
	@email,
	@provincia,
	@canton,
	@distrito,
	@seniaExacta,
	cast(GETDATE() as date),
	@fechaNacimiento,
	@salario,
	1,
	@usuario,
	@contrasenia)
	set @error = 'Insertado'
end try
begin catch
	set @error = 'Error'
end catch

