-- Vistas para produccion

USE ERP
GO

-- Vista para los empleados del departamento de produccion
CREATE VIEW Produccion.EmpleadosProduccion AS
SELECT 
    U.cedula, 
    U.primerNombre, 
    U.segundoNombre, 
    U.primerApellido, 
    U.segundoApellido
FROM 
    RRHH.Usuario AS U
JOIN 
    RRHH.Puesto AS P ON U.nombrePuesto_Puesto = P.nombre
WHERE 
    P.nombreD_Departamento = 'Producción' AND 
    U.activo = 1;