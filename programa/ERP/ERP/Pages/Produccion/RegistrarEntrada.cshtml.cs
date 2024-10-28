using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;
using static ERP.Pages.Produccion.RegistrarMovimientoModel;

namespace ERP.Pages.Produccion
{
    public class RegistrarEntradaModel : PageModel
    {
        public List<Articulo> articulosDisponibles {  get; set; }
        public List<Bodega> bodegasDisponibles { get; set; }
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public List<Empleado> empleadosDosponibles {  get; set; }
        public bool mostrarModal {  get; set; }
        public string BodegaDestinoSeleccionada { get; set; }

        public void OnGet()
        {
            empleadosDosponibles = obtenerEmpleadosProduccion();
            bodegasDisponibles = obtenerBodegasDisponibles();
        }

        public List<Articulo> obtenerArticulosDisponibles(string bodegaDestino)
        {
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Produccion.ArticulosDisponiblesEnBodega(@BodegaDestino)";
                    cmd.Parameters.AddWithValue("@BodegaDestino", bodegaDestino);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        articulos.Add(new Articulo(
                            reader.GetString(0),   // nombre
                            reader.GetString(1),   // codigo_Familia
                            reader.GetString(2),   // familia
                            reader.GetInt32(3),    // codigo
                            reader.GetDouble(4),   // peso
                            reader.GetString(5),   // descripcion
                            reader.GetString(6),   // marca
                            reader.GetDouble(7)    // precio
                        ));
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al intentar obtener los artículos disponibles: " + ex.Message);
            }
            return articulos;
        }

        public List<Empleado> obtenerEmpleadosProduccion()
        {
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT cedula, primerNombre, segundoNombre, primerApellido, segundoApellido FROM Produccion.EmpleadosProduccion";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        empleados.Add(new Empleado(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.IsDBNull(2) ? string.Empty : reader.GetString(2), // segundoNombre puede ser null
                            reader.GetString(3),
                            reader.GetString(4)
                        ));
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al cargar los empleados" + ex.Message);
            }
            return empleados;
        }

        public List<Bodega> obtenerBodegasDisponibles()
        {
            List<Bodega> bodegas = new List<Bodega>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT codigo, nombre FROM Produccion.Bodega WHERE activo = 1";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bodegas.Add(new Bodega(reader.GetString(0), reader.GetString(1)));
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al intentar obtener las bodegas" + ex.Message);
            }
            return bodegas;
        }

        public void OnPostMostrarModal()
        {
            mostrarModal = true;
            articulosDisponibles = new List<Articulo>();
            empleadosDosponibles = obtenerEmpleadosProduccion();
            bodegasDisponibles = obtenerBodegasDisponibles();

            if (!string.IsNullOrEmpty(BodegaDestinoSeleccionada))
            {
                articulosDisponibles = obtenerArticulosDisponibles(BodegaDestinoSeleccionada) ?? new List<Articulo>();
            }
        }

        public void OnPostCerrarModal()
        {
            mostrarModal = false;
            empleadosDosponibles = obtenerEmpleadosProduccion();
            bodegasDisponibles = obtenerBodegasDisponibles();
        }

        public class Bodega
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }

            public Bodega(string codigo, string nombre)
            {
                Codigo = codigo;
                Nombre = nombre;
            }
        }

        public class Empleado
        {
            public string Cedula { get; set; }
            public string NombreCompleto { get; set; }

            public Empleado(string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
            {
                Cedula = cedula;
                NombreCompleto = $"{primerNombre} {segundoNombre} {primerApellido} {segundoApellido}".Trim();
            }
        }
    }
}
