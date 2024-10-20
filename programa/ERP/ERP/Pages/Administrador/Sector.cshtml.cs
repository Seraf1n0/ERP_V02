using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ERP.Pages.Administrador
{
    public class SectorModel : PageModel
    {
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public List<string> sectores = new List<string>();
        public void OnGet()
        {
            consultaDetalles();
        }

        public void consultaDetalles()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select descripcion From Ventas.Sector";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sectores.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { }
        }
    }
}
