using ERP.wwwroot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
namespace ERP.Pages.Administrador
{
    public class RegistrarEmpleadoModel : PageModel
    {
        public DateTime fechaHoy = DateTime.Now;
        private string rutaArchivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "c", "c.txt");
        public Direccion direccion = new Direccion();
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public bool errorCedula = true;
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
            string permisosEdicion = Request.Form["permisosEdicion"];
            string permisosVisualizacion = Request.Form["permisosVisualizacion"];
            string permisosReportes = Request.Form["permisosReportes"];
            //Para almacenar los permisos
            string[] listaEdicion = permisosEdicion.Split(";");
            string[] listaVisualizacion = permisosVisualizacion.Split(";");
            string[] listaReportes = permisosReportes.Split(";");

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
                        cmd.Parameters.AddWithValue("@usuario", cifrar(cedula));
                        cmd.Parameters.AddWithValue("@contrasenia", cifrar(cedula));
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
                        conexion.Close();
                        if(mensajeError != "Error")
                        {
                            errorCedula = true;

                            //Primero tendría que insertar el nombre del rol
                            using (SqlConnection conexionNombreRol = new SqlConnection(baseDeDatos.stringConexion)) 
                            {
                                conexionNombreRol.Open();
                                using (SqlCommand cmdNombreRol = new SqlCommand("InsertarRol", conexionNombreRol))
                                {
                                    cmdNombreRol.CommandType = CommandType.StoredProcedure;
                                    cmdNombreRol.Parameters.AddWithValue("@nombre", cedula);
                                    SqlParameter errorNombre= new SqlParameter("@error", SqlDbType.VarChar, 50)
                                    {
                                        Direction = ParameterDirection.Output
                                    };
                                    cmdNombreRol.Parameters.Add(errorNombre);
                                    cmdNombreRol.ExecuteNonQuery();
                                }
                                conexionNombreRol.Close();

                            }

                            //Aquí tendría que insertar los permisos
                            using (SqlConnection connection = new SqlConnection(baseDeDatos.stringConexion))
                            {
                                connection.Open();
                                //Tengo que hacerlo para edición, visualización y reportes
                                foreach(string textoEdicion in listaEdicion)
                                {
                                    using (SqlCommand command = new SqlCommand("InsertarPermisoModuloRol", connection))
                                    {
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.AddWithValue("@nombreRol", cedula);
                                        command.Parameters.AddWithValue("@nombreModulo", textoEdicion);
                                        command.Parameters.AddWithValue("@tipoPermiso", 1);
                                        SqlParameter errorEdicion = new SqlParameter("@error", SqlDbType.VarChar, 50)
                                        {
                                            Direction = ParameterDirection.Output
                                        };
                                        command.Parameters.Add(errorEdicion);
                                        // Ejecutar el procedimiento almacenado
                                        command.ExecuteNonQuery();
                                    }
                                }

                                //visualización 
                                foreach (string textoVisualizacion in listaVisualizacion)
                                {
                                    using (SqlCommand command = new SqlCommand("InsertarPermisoModuloRol", connection))
                                    {
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.AddWithValue("@nombreRol", cedula);
                                        command.Parameters.AddWithValue("@nombreModulo", textoVisualizacion);
                                        command.Parameters.AddWithValue("@tipoPermiso", 2);
                                        SqlParameter errorVisualizacion = new SqlParameter("@error", SqlDbType.VarChar, 50)
                                        {
                                            Direction = ParameterDirection.Output
                                        };
                                        command.Parameters.Add(errorVisualizacion);
                                        // Ejecutar el procedimiento almacenado
                                        command.ExecuteNonQuery();
                                    }
                                }

                                //reportes 
                                foreach (string textoReportes in listaReportes)
                                {
                                    using (SqlCommand command = new SqlCommand("InsertarPermisoModuloRol", connection))
                                    {
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.AddWithValue("@nombreRol", cedula);
                                        command.Parameters.AddWithValue("@nombreModulo", textoReportes);
                                        command.Parameters.AddWithValue("@tipoPermiso", 3);
                                        SqlParameter errorReportes = new SqlParameter("@error", SqlDbType.VarChar, 50)
                                        {
                                            Direction = ParameterDirection.Output
                                        };
                                        command.Parameters.Add(errorReportes);
                                        // Ejecutar el procedimiento almacenado
                                        command.ExecuteNonQuery();
                                        
                                        
                                    }
                                }
                                connection.Close();
                            }


                        }
                        
                    }
                }
            }
            catch (Exception ex) {  }
            //Ahora tendría que insertar los permisos


    
            
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
                    cmd.CommandText = "select nombre from RRHH.Puesto where nombreD_Departamento = 'Recursos Humanos'";
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
                    cmd.CommandText = "select nombre from RRHH.Puesto where nombreD_Departamento = 'Producción'";
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

        public string cifrar(string texto)
        {
            string clave = "";
            string linea;
            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    while ((linea = sr.ReadLine()) != null)
                    {
                        clave = linea;
                    }

                }

                
            }
            catch (Exception ex) { return ""; }


  
            //Ahora tendrìa que cifrar el texto
            byte[] iv;
            byte[] encrypted;

            // Generar un nuevo vector de inicialización
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(clave); // Convertir la clave a bytes
                aes.Mode = CipherMode.ECB; // Modo sin IV
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, null); // Sin IV
                byte[] plainBytes = Encoding.UTF8.GetBytes(texto);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }


        }
    }
}
