use ERP
go

create view DatosArticulo as 
select a.nombre as NombreArticulo, a.codigoF_Familia as CodigoFamila, f.nombre as NombreFamilia, a.codigo as CodigoProducto,
a.precio as Precio, a.peso as Peso, a.descripcion as Descripcion, a.marca as Marca
from Produccion.Articulo a
join Produccion.Familia f on a.codigoF_Familia = f.codigo
where a.activo = 1
group by a.nombre, a.codigoF_Familia, f.nombre, a.codigo, a.precio, a.peso, a.descripcion, a.marca

