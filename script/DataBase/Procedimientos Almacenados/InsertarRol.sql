use ERP
GO

create procedure InsertarRol
	@nombre varchar(20),
	@error varchar(50) output
as
begin try
	insert into RRHH.Rol (nombreRol, activo) values (@nombre, 1)
	set @error = 'Insertado'
end try
begin catch
	set @error = 'Error'
end catch

