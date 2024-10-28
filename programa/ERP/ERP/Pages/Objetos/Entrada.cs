namespace ERP.Pages.Objetos
{
    public class Entrada
    {
        public int ID { get; set; }
        public string bodegaDestino { get; set; }
        public string cedulaResponsable { get; set; }
        public string nombreResponsable { get; set; }
        public DateTime fechaHora { get; set; }
        public int cantidadProductos { get; set; }
        public double precioTotal { get; set; }

        public Entrada(int ID, string bodegaDestino, string cedulaResponsable, string nombreResponsable, DateTime fechaHora, int cantidadProductos, double precioTotal)
        {
            this.ID = ID;
            this.bodegaDestino = bodegaDestino;
            this.cedulaResponsable = cedulaResponsable;
            this.nombreResponsable = nombreResponsable;
            this.fechaHora = fechaHora;
            this.cantidadProductos = cantidadProductos;
            this.precioTotal = precioTotal;
            this.cantidadProductos = cantidadProductos;
            this.precioTotal = precioTotal;
        }
    }
}
