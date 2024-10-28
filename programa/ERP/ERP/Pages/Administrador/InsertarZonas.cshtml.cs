using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ERP.Pages.Administrador
{
    public class InsertarZonasModel : PageModel
    {
        [BindProperty]
        public string zona { get; set; } = "";
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            int cuenta = 0;
            string zonaBusqueda = "'" + zona + "'";
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select COUNT(*) as cuenta from Ventas.Zona where descripcion= " + zonaBusqueda;
                    cuenta = (int)cmd.ExecuteScalar();

                    if (cuenta < 1)
                    {
                        //Insertar
                        try
                        {
                            using (SqlConnection conexion2 = new SqlConnection(baseDeDatos.stringConexion))
                            {
                                conexion2.Open();
                                SqlCommand cmd2 = conexion2.CreateCommand();
                                cmd2.CommandText = "insert into Ventas.Zona values (" + zonaBusqueda + ")";
                                cmd2.ExecuteNonQuery(); //Con esto se supone que inserto

                                //Redirigir a la otra página no hay tiempo para poner el mensaje
                                return Redirect("/Administrador/Zonas");
                            }
                        }

                        catch (Exception ex) { return Redirect("/Administrador/InsertarZonas"); }
                    }
                    return Redirect("/Administrador/InsertarZonas");

                }
            }
            catch (Exception ex) { return Redirect("/Administrador/InsertarZonas"); }
        }
    }
}
