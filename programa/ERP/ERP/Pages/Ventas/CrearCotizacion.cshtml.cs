using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP.Pages.Objetos;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace ERP.Pages.Ventas
{
    public class CrearCotizacionModel : PageModel
    {
        [BindProperty]
        public string cedulaCliente { get; set; }
        [BindProperty]
        public string nombreCliente { get; set; }
        [BindProperty]
        public string zonaCliente { get; set; }
        [BindProperty]
        public string sectorCliente { get; set; }
        [BindProperty]
        public string descripcion { get; set; }
        public DateTime fechaHoy = DateTime.Now;
        public Dictionary<int, string> probabilidades;
        public Dictionary<string, string> nombresCliente;
        public Dictionary<string, string> zonasCliente;
        public Dictionary<string, string> sectoresCliente;
        public BaseDeDatos baseDeDatos;
        public List<Articulo> articulos;
        public Dictionary<string, string> articulosSeleccionados;
        public void OnGet()
        {
            //Atributos de la clase
            fechaHoy = DateTime.Today;
            probabilidades = new Dictionary<int, string>();
            nombresCliente = new Dictionary<string, string>();
            zonasCliente = new Dictionary<string, string>();
            sectoresCliente = new Dictionary<string, string>();
            baseDeDatos = new BaseDeDatos();
            cedulaCliente = "";
            articulos = new List<Articulo>();
            descripcion = "";
            articulosSeleccionados = new Dictionary<string, string>();

            //Consultas para llenar los combobox, tablas y campos de texto
            obtenerProbabilidad();
            obtenerDatosDeClientes();
            obtenerArticulos();
            nombreCliente = nombresCliente.Values.First();
            zonaCliente = zonasCliente.Values.First();
            sectorCliente = sectoresCliente.Values.First();
        }

        public void OnPost(string listaArticulos)
        {
            if (!string.IsNullOrEmpty(listaArticulos))
            {
                // Deserializar el string JSON en un diccionario
                articulosSeleccionados = JsonSerializer.Deserialize<Dictionary<string, string>>(listaArticulos);

                // Ahora puedes trabajar con el diccionario, por ejemplo, guardarlo en la base de datos
                foreach (var articulo in articulosSeleccionados)
                {
                    string codigo = articulo.Key;
                    string cantidad = articulo.Value;

                    // Aquí puedes hacer lo que necesites, como imprimir los resultados en la consola
                    Console.WriteLine($"Código: {codigo}, Cantidad: {cantidad}");
                }
            }
        }

        private void obtenerProbabilidad()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select * from ObtenerProbabilidad";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        probabilidades.Add(reader.GetInt32(0), reader.GetInt32(1).ToString()); 
                    }
                    reader.Close();
                }
            }catch (Exception ex) { }
        }
        private void obtenerDatosDeClientes()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select * from DatosClienteParaCotizacion";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        nombresCliente.Add(reader.GetString(0), (reader.GetString(1)));
                        zonasCliente.Add(reader.GetString(0), (reader.GetString(2)));
                        sectoresCliente.Add(reader.GetString(0), (reader.GetString(3)));
                    }
                    reader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex) { }

        }

        private void obtenerArticulos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select * from DatosArticulo";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        string codigoFamilia = reader.GetString(1);
                        string familia = reader.GetString(2);
                        int codigo = reader.GetInt32(3);
                        double precio = reader.GetDouble(4);
                        double peso = reader.GetDouble(5);
                        string descripcion = reader.GetString(6);
                        string marca = reader.GetString(7);
                        articulos.Add(new Articulo(nombre, codigoFamilia, familia, codigo, peso, descripcion, marca, precio));
                    }
                    reader.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex) { }
        }


    }
}
