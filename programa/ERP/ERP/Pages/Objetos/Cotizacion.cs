namespace ERP.Pages.Objetos
{
    public class Cotizacion
    {
        public int ID { get; set; } = 0;
        public string CedulaCliente { get; set; } = string.Empty;
        public string CedulaEmpleado { get; set; } = string.Empty;
        public float MontoTotal { get; set; } = 0.0f;
        public DateTime FechaCierreProyectada { get; set; } = DateTime.MinValue;
        public DateTime? FechaCierre { get; set; } = null;
        public DateTime FechaHora { get; set; } = DateTime.MinValue;
        public int Probabilidad { get; set; } = 0;
        public string Descripcion { get; set; } = string.Empty;
        public string Zona { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;

        public Cotizacion(int id, string cedulaCliente, string cedulaEmpleado, float montoTotal, DateTime fechaCierreProyectada, DateTime fechaHora, int probabilidad, string descripcion, string zona, string sector, DateTime? fechaCierre = null)
        {
            ID = id;
            CedulaCliente = cedulaCliente;
            CedulaEmpleado = cedulaEmpleado;
            MontoTotal = montoTotal;
            FechaCierreProyectada = fechaCierreProyectada;
            FechaHora = fechaHora;
            Probabilidad = probabilidad;
            Descripcion = descripcion;
            Zona = zona;
            Sector = sector;
            FechaCierre = fechaCierre;
        }
    }
}