using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ERP.Pages
{
    public class IndexModel : PageModel
    {
        private string rutaArchivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "c", "c.txt");
        [BindProperty]
        public string Usuario { get; set; } = "";

        [BindProperty]
        public string Contrasenia { get; set; } = "";

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public bool errorInicioSesion = false;
        public BaseDeDatos baseDeDatos = new BaseDeDatos();

        public IActionResult OnPost()
        {   
            if(Usuario == "a" || Usuario == "A"){
                return RedirectToPage("Administrador/PaginaPrincipal");
            }
            if (Usuario == "r" || Usuario == "R")
            {
                HttpContext.Session.SetString("Usuario", "Holaaaa"); //Si se está guardando
                return RedirectToPage("RRHH/Empleados");
            }

            string resultado;
            //Tengo que obtener el usuario de la base de datos. Primero cifro ambos textos para compararlos
            string usuarioCifrado = cifrar(Usuario);
            string contraseniaCifrada = cifrar(Contrasenia);
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    using (SqlCommand command = new SqlCommand("SELECT dbo.ObtenerCedulaUsuarioEnSesion(@usuario, @contrasenia)", conexion))
                    {
                        command.Parameters.AddWithValue("@usuario", usuarioCifrado);
                        command.Parameters.AddWithValue("@contrasenia", contraseniaCifrada);
                        var result = command.ExecuteScalar();
                        if (result.ToString() != "null")
                        {
                            HttpContext.Session.SetString("Usuario", result.ToString()); //Aquí va la cédula del empleado
                            return RedirectToPage("RRHH/Empleados");
                        }
                        errorInicioSesion = true;
                        return Page();
                    }
                }
            }
            catch (Exception ex) { }


            // Guardar el usuario en la sesión
            HttpContext.Session.SetString("Usuario", Usuario);
            if (Usuario == "V" | Usuario == "v")
            {
                return RedirectToPage("Ventas/PaginaPrincipalVentas");
            }
            else if (Usuario == "R" | Usuario == "r")
            {
                return RedirectToPage("RRHH/Empleados");
            }
            else if (Usuario == "A" | Usuario == "a"){

                return RedirectToPage("Administrador/PaginaPrincipal");
            }

            else
            {
                return RedirectToPage("Produccion/PaginaPrincipalProduccion");
            }
            // Redirigir a la página principal (por ejemplo, un dashboard)
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
