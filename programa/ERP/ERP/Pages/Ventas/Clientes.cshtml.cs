using ERP.Pages.Objetos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ERP.Pages.Ventas
{
    public class ClientesModel : PageModel
    {
        public List<Cliente> clientes = new List<Cliente>();
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public void OnGet()
        {
            buscarClientes();
        }

        //Este método va a hacer la consulta para sacar todos los clientes de la base
        public void buscarClientes()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select cedula, primerNombre from Ventas.Cliente where tipoCedula = 'Jurídica'";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente(reader.GetString(0), reader.GetString(1)));
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex) { }

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "select cedula, primerNombre, primerApellido, segundoApellido from Ventas.Cliente where tipoCedula = 'Cédula Física'";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex) { }
        }
    }
}