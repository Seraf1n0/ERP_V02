using ERP.Pages.Objetos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace ERP.Pages.RRHH
{
    public class EmpleadosModel : PageModel
    {
        public List<Empleado> empleados = new List<Empleado>();
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public void OnGet()
        {
            empleadosRegistrados();
        }

        //Hago la consulta para ver todos los empleados registrados
        public void empleadosRegistrados()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select cedula, primerNombre, primerApellido, segundoApellido, RRHH.Puesto.nombreD_Departamento, nombrePuesto_Puesto from RRHH.Usuario, RRHH.Puesto where RRHH.Puesto.nombre = RRHH.Usuario.nombrePuesto_Puesto";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                    { 
                        empleados.Add(new Empleado(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                    }
                    reader.Close();
                    
                }
            } catch (SqlException ex) { }
        }
    }

    
}
