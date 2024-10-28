USE ERP
GO

create view ObtenerProbabilidad as
select p.ID as Identificador, p.descripcion as Valor from Ventas.Probabilidad p