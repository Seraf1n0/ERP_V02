using ERP.Pages.Objetos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ERP.Pages.Ventas
{
    public class CotizacionesModel : PageModel
    {
        public List<Cotizacion> cotizaciones = new List<Cotizacion>();
        public BaseDeDatos baseDeDatos = new BaseDeDatos();

        public void OnGet()
        {
            BuscarCotizaciones();
        }

        public void BuscarCotizaciones()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = @"
                        SELECT ID, cedulaCotizador_Cliente, cedulaEmpleado_Usuario, montoTotal, fechaCierreProyectada, fechaHora, probabilidad, descripcion, zona, sector, fechaCierre 
                        FROM Ventas.Cotizacion";

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cotizaciones.Add(new Cotizacion( // Usando el objeto Cotizacion.cs tomamos los datos dentro de la consulta (cada columna tiene asignado un espacio en el reader)
                            reader.GetInt32(0),  // ID
                            reader.GetString(1),  // cedulaCotizador_Cliente
                            reader.GetString(2),  // cedulaEmpleado_Usuario
                            reader.GetInt32(3),   // montoTotal
                            reader.GetDateTime(4), // fechaCierreProyectada
                            reader.GetDateTime(5), // fechaHora
                            reader.GetInt32(6),   // probabilidad
                            reader.GetString(7),  // descripcion
                            reader.GetString(8),  // zona
                            reader.GetString(9),  // sector
                            reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)  // fechaCierre
                        ));
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                // Manejo de excepción
            }
        }
    }
}