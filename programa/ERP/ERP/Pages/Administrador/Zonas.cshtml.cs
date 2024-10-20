using ERP.Pages.Objetos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ERP.Pages.Administrador
{
    public class ZonasModel : PageModel
    {
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public List<string> zonas = new List<string>();
        public void OnGet()
        {
            consultaZonas();
        }

        public void consultaZonas()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select descripcion From Ventas.Zona";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        zonas.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { }
        }
    }
}
