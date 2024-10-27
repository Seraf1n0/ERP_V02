using ERP.wwwroot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ERP.Pages.Administrador
{
    public class RegistrarEmpleadoModel : PageModel
    {
        public DateTime fechaHoy = DateTime.Now;

        public Direccion direccion = new Direccion();
        public BaseDeDatos baseDeDatos = new BaseDeDatos();

        //Listas para los puestos
        public List<string> puestosRRHH = new List<string>();
        public List<string> puestosVentas = new List<string>();
        public List<string> puestosProduccion = new List<string>();
        public Dictionary<int, string> generos = new Dictionary<int, string>();
        public string ErrorMensaje { get; set; }
        public void OnGet()

        {
            baseDeDatos = new BaseDeDatos();
            fechaHoy = DateTime.Now;
            direccion = new Direccion();
            consultaPuestos();
            consultaGeneros();
        }

        //Esta función se ejecuta cuando se presiona el botón de Registrar Empleado
        public void OnPost()
        {   //Ya recibo bien los valores desde el front-end
            //Primero tengo que verificar que la cédula no se repita. Esto lo hace la base

            //Datos para insertar el usuario
            string primerNombre = Request.Form["primerNombre"];
            string segundoNombre = Request.Form["segundoNombre"];
            string primerApellido = Request.Form["primerApellido"];
            string segundoApellido = Request.Form["segundoApellido"];
            string genero = Request.Form["generos"]; 
            string fecha = Request.Form["fecha"];
            string cedula = Request.Form["cedula"];
            string correoElectronico = Request.Form["correo"];
            string provincia = Request.Form["provincias"];
            string canton = Request.Form["cantones"];
            string distrito = Request.Form["distritos"];
            string seniasExactas = Request.Form["seniasExactas"];
            string departamento = Request.Form["departamentos"];
            string puesto = Request.Form["puestos"];
            string salario = Request.Form["salario"];

            float salarioF = float.Parse(salario);
            //Insertando el usuario
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertarUsuario", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; //Para indicar que es procedimiento almacenado
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        cmd.Parameters.AddWithValue("@nombrePuesto", puesto);
                        cmd.Parameters.AddWithValue("@primerNombre", primerNombre);
                        cmd.Parameters.AddWithValue("@segundoNombre", string.IsNullOrEmpty(segundoNombre) ? (object)DBNull.Value : segundoNombre);
                        cmd.Parameters.AddWithValue("@primerApellido", primerNombre);
                        cmd.Parameters.AddWithValue("@segundoApellido", segundoApellido);
                        cmd.Parameters.AddWithValue("@genero", genero);
                        cmd.Parameters.AddWithValue("@email", correoElectronico);
                        cmd.Parameters.AddWithValue("@provincia", provincia);
                        cmd.Parameters.AddWithValue("@canton", canton);
                        cmd.Parameters.AddWithValue("@distrito", distrito);
                        cmd.Parameters.AddWithValue("@seniaExacta", seniasExactas);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", fecha);
                        cmd.Parameters.AddWithValue("@salario", salarioF);
                        cmd.Parameters.AddWithValue("@usuario", cedula);
                        cmd.Parameters.AddWithValue("@contrasenia", cedula);
                        //Para recibir el error
                        SqlParameter parametroError = new SqlParameter("@error", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(parametroError);

                        //Ejecuto el procedimiento
                        cmd.ExecuteNonQuery();

                        //Aquí tengo el parámetro de error
                        string mensajeError = parametroError.Value.ToString();
                        Console.WriteLine(mensajeError);
                    }
                }
            }
            catch (Exception ex) { }

            string valorRecibido = Request.Form["permisosEdicion"]; // Este es el valor enviado desde el frontend
            string valorRecibidoB = Request.Form["permisosVisualizacion"]; // Este es el valor enviado desde el frontend
            string valorRecibidoC = Request.Form["permisosReportes"]; // Este es el valor enviado desde el frontend
            string a = "";
        }

        public void consultaPuestos()
        {
            //Voy a buscar por cada departamento los puestos 
            //Primero RRHH
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select nombre from RRHH.Puesto where nombreD_Departamento = 'RRHH'";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        puestosRRHH.Add(reader.GetString(0));
                    }
                    conexion.Close();
                }

            }
            catch (SqlException ex) { }

            //Ahora Ventas
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select nombre from RRHH.Puesto where nombreD_Departamento = 'Ventas'";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        puestosVentas.Add(reader.GetString(0));
                    }
                    conexion.Close();
                }

            }
            catch (SqlException ex) { }

            //Producción
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select nombre from RRHH.Puesto where nombreD_Departamento = 'Produccion'";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        puestosProduccion.Add(reader.GetString(0));
                    }
                    conexion.Close();
                }
            }
            catch (SqlException ex) { }
        }

        public void consultaGeneros()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select * from SeleccionarGeneros";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        generos.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { }
        }
    }
}
