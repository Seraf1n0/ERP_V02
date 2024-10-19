namespace ERP.Pages.Objetos
{
    public class Puesto
    {
        public string departamento;
        public string nombre;
       
        public Puesto(string nombre, string departamento)
        {
            this.departamento = departamento;
            this.nombre = nombre;  
        }
    }
}
