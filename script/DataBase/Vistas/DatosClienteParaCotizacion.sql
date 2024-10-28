use ERP 
go

create view DatosClienteParaCotizacion as
select c.cedula as Cedula,
--Para concatenar el nombre en caso de que haya nulos
(c.primerNombre + case when c.segundoNombre is not null then ' ' + c.segundoNombre else ' ' end +
case when c.primerApellido is not null then ' ' + c.primerApellido else ' ' end +
case when c.segundoApellido is not null then ' ' + c.segundoApellido else ' ' end) as Nombre,
z.descripcion as Zona,
s.descripcion as Sector
from Ventas.Cliente c
join Ventas.Zona z on c.zona = z.ID
join Ventas.Sector s on c.sector = s.ID
group by c.cedula, c.primerNombre, c.segundoNombre,  c.primerApellido, c.segundoApellido, z.descripcion, s.descripcion