use ERP
go

create procedure InsertarPermisoModuloRol
	@nombreRol varchar(20),
	@nombreModulo varchar(20),
	@tipoPermiso int,
	@error varchar(50) output
as
begin try
	insert into RRHH.PermisoModuloRol (nombreRol, nombreModulo, tipoPermiso) values (@nombreRol, @nombreModulo, @tipoPermiso)
	set @error = 'Insertado'
end try
begin catch
	set @error = 'Error'
end catch

