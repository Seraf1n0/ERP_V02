using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP.Pages.Objetos;
using System.Data.SqlClient;
using System.Data;

namespace ERP.Pages.Ventas
{
    public class CrearCotizacionModel : PageModel
    {
        public string cedulaCliente;
        public string nombreCliente;
        public string zonaCliente;
        public string sectorCliente;
        public DateTime fechaHoy = DateTime.Now;
        public Dictionary<int, string> probabilidades;
        public Dictionary<string, string> nombresCliente;
        public Dictionary<string, string> zonasCliente;
        public Dictionary<string, string> sectoresCliente;
        public BaseDeDatos baseDeDatos;
        public List<Articulo> articulos;
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

            //Consultas para llenar los combobox, tablas y campos de texto
            obtenerProbabilidad();
            obtenerDatosDeClientes();
            obtenerArticulos();
            nombreCliente = nombresCliente.Values.First();
            zonaCliente = zonasCliente.Values.First();
            sectorCliente = sectoresCliente.Values.First();
        }

        public void OnPost()
        {
           
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
