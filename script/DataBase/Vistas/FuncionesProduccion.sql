-- Funciones necesarias para producción

CREATE FUNCTION Produccion.ArticulosDisponiblesEnBodegas (@codigoBodegaOrigen VARCHAR(10), @codigoBodegaDestino VARCHAR(10)) RETURNS TABLE
AS
RETURN
(
    SELECT A.nombre, A.codigoF_Familia AS codigo_Familia, F.nombre AS nombre_Familia,A.codigo, CAST(A.peso AS FLOAT) AS peso, A.descripcion,  A.marca, CAST(A.precio AS FLOAT) AS precio
    FROM Produccion.Articulo AS A
    JOIN Produccion.FamiliaBodega AS FB1 ON A.codigoF_Familia = FB1.codigoF_Familia
    JOIN Produccion.FamiliaBodega AS FB2 ON A.codigoF_Familia = FB2.codigoF_Familia
    JOIN Produccion.Familia AS F ON A.codigoF_Familia = F.codigo
    WHERE FB1.codigoB_Bodega = 'B001' AND FB2.codigoB_Bodega = 'B002' AND A.activo = 1 AND F.activo = 1
);
GO

CREATE FUNCTION Produccion.ArticulosDisponiblesEnBodega(@codigoBodega VARCHAR(10)) RETURNS TABLE
AS
RETURN
(
    SELECT A.nombre AS nombre, A.codigoF_Familia AS codigo_Familia, F.nombre AS familia, A.codigo AS codigo, A.peso AS peso, A.descripcion AS descripcion, A.marca AS marca, A.precio AS precio
    FROM Produccion.Articulo AS A
    INNER JOIN Produccion.Familia AS F ON A.codigoF_Familia = F.codigo
    INNER JOIN Produccion.FamiliaBodega AS FB ON F.codigo = FB.codigoF_Familia
    WHERE FB.codigoB_Bodega = @codigoBodega AND A.activo = 1 AND F.activo = 1
);
GO