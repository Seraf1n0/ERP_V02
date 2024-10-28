using ERP.Pages.Objetos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ERP.Pages.Produccion
{
    public class RegistrarMovimientoModel : PageModel
    {
        public List<Articulo> articulosDisponibles { get; set; }
        public List<Bodega> bodegasDisponibles { get; set; }
        public List<Empleado> responsablesDisponibles { get; set; }
        public BaseDeDatos baseDeDatos = new BaseDeDatos();
        public bool mostrarModal { get; set; }

        public string BodegaOrigenSeleccionada { get; set; }
        public string BodegaDestinoSeleccionada { get; set; }
        public string ResponsableSeleccionado {  get; set; }
        public void OnGet()
        {
            responsablesDisponibles = obtenerEmpleadosProduccion();
            bodegasDisponibles = obtenerBodegasDisponibles();
            mostrarModal = false;
        }

        public List<Articulo> obtenerArticulosDisponibles(string codigoBodegaOrigen, string codigoBodegaDestino)
        {
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDeDatos.stringConexion))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT nombre, codigoF_Familia, nombre_Familia, codigo, CAST(peso AS FLOAT), descripcion, marca, CAST(precio AS FLOAT) AS precio FROM Produccion.ArticulosDisponiblesEnBodegas(@codigoBodegaOrigen, @codigoBodegaDestino)";
                    cmd.Parameters.AddWithValue("@codigoBodegaOrigen", codigoBodegaOrigen);
                    cmd.Parameters.AddWithValue("@codigoBodegaDestino", codigoBodegaDestino);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            articulos.Add(new Articulo(
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3),
                                reader.GetDouble(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetDouble(7)
                            ));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al cargar articulos: "+ex.ToString());
            }
            return articulos;
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
                Console.WriteLine( "Error al intentar obtener las bodegas"+ex.Message);
            }
            return bodegas;
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
                Console.WriteLine("Error al cargar los empleados" +  ex.Message);
            }
            return empleados;
        }



        public void OnPostMostrarModal()
        {

            responsablesDisponibles = obtenerEmpleadosProduccion();
            bodegasDisponibles = obtenerBodegasDisponibles();
            mostrarModal = true;

            articulosDisponibles = new List<Articulo>();

            if (!string.IsNullOrEmpty(BodegaOrigenSeleccionada) && !string.IsNullOrEmpty(BodegaDestinoSeleccionada))
            {
                articulosDisponibles = obtenerArticulosDisponibles(BodegaOrigenSeleccionada, BodegaDestinoSeleccionada) ?? new List<Articulo>();
            }
        }

        public void OnPostCerrarModal()
        {
            bodegasDisponibles = obtenerBodegasDisponibles();
            responsablesDisponibles = obtenerEmpleadosProduccion();
            mostrarModal = false;
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