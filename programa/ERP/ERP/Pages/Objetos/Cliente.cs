namespace ERP.Pages.Objetos
{
    
    public class Cliente
    {
        public bool tipo; //True para persona y false para empresa
        public string cedula;
        public string tipoCedula;
        public string nombre;
        public string primerApellido;
        public string segundoApellido;

        public Cliente(string cedula, string nombre, string primerApellido, string segundoApellido)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            tipo = true;
            tipoCedula = "Personal";
        }

        public Cliente(string cedula, string nombre)
        {
            this.cedula= cedula;
            this.nombre= nombre;
            this.primerApellido = "";
            this.segundoApellido = "";
            this.tipo = false;
            this.tipoCedula = "Jurídica";
        }
    }
}
