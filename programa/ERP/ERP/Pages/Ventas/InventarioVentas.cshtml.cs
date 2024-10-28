using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ERP.Pages.Ventas
{
    public class InventarioVentascshtmlModel : PageModel
    {
        public List<string> nombre = new List<string>();
        public List<string> bodega = new List<string>();
        public List<string> familia = new List<string>();
        public List<string> stock = new List<string>();
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public void OnGet()
        {
            obtenerDatosInventario();
        }

        public void obtenerDatosInventario()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select * from DatosInventario";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        nombre.Add(reader.GetString(0));
                        bodega.Add(reader.GetString(1));
                        familia.Add(reader.GetString(2));
                        stock.Add(reader.GetInt32(3).ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { }
        }
    }
}
