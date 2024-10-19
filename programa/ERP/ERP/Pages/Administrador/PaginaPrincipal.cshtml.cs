using ERP.Pages.Objetos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ERP.Pages.Administrador
{
    public class PaginaPrincipalModel : PageModel
    {
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public List<Puesto> puestos = new List<Puesto>();
        public void OnGet()
        {
            buscarPuestos();
        }

        public void buscarPuestos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select * from RRHH.Puesto";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        puestos.Add(new Puesto(reader.GetString(0), reader.GetString(1)));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { }
        }
    }
}
