namespace ERP.Pages.Objetos
{
    public class Empleado
    {
        public string cedula;
        public string nombre;
        public string apellido1;
        public string apellido2;
        public string departamento;
        public string puesto;

        public Empleado(string cedula, string nombre, string apellido1, string apellido2, string departamento, string puesto) 
        { 
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.departamento = departamento;
            this.puesto = puesto;
        }
    }
}
