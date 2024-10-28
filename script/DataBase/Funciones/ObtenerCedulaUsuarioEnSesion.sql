use ERP
go

--Retona la cédula si el usuario y contraseña son correctos
--Retorna null si son incorrectos
create function dbo.ObtenerCedulaUsuarioEnSesion(@user varchar(50), @pass varchar(50))
	returns varchar(20)
as
begin
	declare @retorno varchar(20)
	select @retorno = u.cedula from RRHH.Usuario as u  
	where u.usuario = @user and u.contrasenia = @pass;

	if(@retorno is null)
		set @retorno = 'null'
	return @retorno;
end;