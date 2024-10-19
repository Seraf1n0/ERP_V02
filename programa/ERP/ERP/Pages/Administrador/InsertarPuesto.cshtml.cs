using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ERP.Pages.Administrador
{
    public class InsertarPuestoModel : PageModel
    {
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public List<string> departamentos = new List<string>();
        [BindProperty]
        public string puesto { get; set; } = "";
        [BindProperty]
        public string departamentoSeleccionado { get; set; } = "";
        public void OnGet()
        {
            consultarDepartamentos();
        }

        public void consultarDepartamentos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select nombre from RRHH.Departamento";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        departamentos.Add(reader.GetString(0));
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex) { }
        }

        public IActionResult OnPost()
        {
            int cuenta = 0;
            string puestoBuscar = "'" + puesto + "'";
            string departamentoBuscar = "'" + departamentoSeleccionado + "'";
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select COUNT(*) as cuenta from RRHH.Puesto where nombre= " + puestoBuscar + " and nombreD_Departamento = " + departamentoBuscar;
                    cuenta = (int)cmd.ExecuteScalar();
                    if (cuenta < 1)
                    {
                        //Inserto
                        using (SqlConnection conexion2 = new SqlConnection(baseDeDatos.stringConexion))
                        {
                            conexion2.Open();
                            SqlCommand cmd2 = conexion2.CreateCommand();
                            cmd2.CommandText = "insert into RRHH.Puesto values (" + puestoBuscar + ", " + departamentoBuscar + ")";
                            cmd2.ExecuteNonQuery(); //Con esto se supone que inserto

                            //Redirigir a la otra página no hay tiempo para poner el mensaje
                            return Redirect("/Administrador/PaginaPrincipal");
                        }
                    }
                    return Redirect("/Administrador/InsertarPuesto");
                }
            }
            catch (Exception ex) { return Redirect("/Administrador/InsertarPuesto"); }
        }
    }
}
