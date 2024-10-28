use ERP
go

create view SeleccionarGeneros as
select id as ID, descripcion as Genero from Ventas.Genero