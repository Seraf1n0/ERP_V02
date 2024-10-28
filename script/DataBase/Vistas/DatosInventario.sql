Use ERP
go

create view DatosInventario as
select a.nombre as NombreArticulo, b.nombre as Bodega, f.nombre as Familia, i.cantidad as Cantidad from Produccion.Inventario i
join Produccion.Articulo a on  i.nombreA_Articulo = a.nombre
join Produccion.Bodega b on i.codigoB_Bodega = b.codigo
join Produccion.Familia f on a.codigoF_Familia = f.codigo
group by a.nombre, i.cantidad,  b.nombre, f.nombre