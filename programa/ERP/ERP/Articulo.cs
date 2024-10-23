namespace ERP
{
    public class Articulo
    {
        public string nombre;
        public string codigo_Familia;
        public string familia;
        public int codigo;
        public double precio;
        public double peso;
        public string descripcion;
        public string marca;

        public Articulo(string nombre, string codigo_Familia, string familia, int codigo, double peso, string descripcion, string marca, double precio)
        {
            this.nombre = nombre;
            this.codigo_Familia = codigo_Familia;
            this.familia = familia;
            this.codigo = codigo;
            this.peso = peso;
            this.descripcion = descripcion;
            this.marca = marca;
            this.precio = precio;
        }
    }
}
