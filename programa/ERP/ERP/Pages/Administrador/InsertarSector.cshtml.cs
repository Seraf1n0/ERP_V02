using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ERP.Pages.Administrador
{
    public class InsertarSectorModel : PageModel
    {
        [BindProperty]
        public string sector { get; set; } = "";
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        //Se ejecuta cuando presiono el botón
        public IActionResult OnPost()
        {
            int cuenta = 0;
            string sectorBusqueda = "'" + sector + "'";
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select COUNT(*) as cuenta from Ventas.Sector where descripcion= " + sectorBusqueda;
                    cuenta = (int)cmd.ExecuteScalar();

                    if (cuenta < 1) {
                        //Insertar
                        try
                        {
                            using (SqlConnection conexion2 = new SqlConnection(baseDeDatos.stringConexion))
                            {
                                conexion2.Open();
                                SqlCommand cmd2 = conexion2.CreateCommand();
                                cmd2.CommandText = "insert into Ventas.Sector values (" + sectorBusqueda + ")";
                                cmd2.ExecuteNonQuery(); //Con esto se supone que inserto

                                //Redirigir a la otra página no hay tiempo para poner el mensaje
                                return Redirect("/Administrador/Sector");
                            }
                        }

                        catch (Exception ex) { return Redirect("/Administrador/InsertarSector"); }
                    }
                    return Redirect("/Administrador/InsertarSector");

                }
            }
            catch (Exception ex) { return Redirect("/Administrador/InsertarSector"); }
        }

        
    }
}
