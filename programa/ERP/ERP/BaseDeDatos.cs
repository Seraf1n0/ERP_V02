using System.Data.SqlClient;
namespace ERP


{
    public class BaseDeDatos
    {
        private SqlConnectionStringBuilder constructor;
        public string stringConexion;

        public BaseDeDatos() {
            constructor = new();
            constructor.DataSource = "DESKTOP-1UDLPMT";
            constructor.InitialCatalog = "ERP";
            constructor.IntegratedSecurity = true;
            constructor.TrustServerCertificate = true;
            stringConexion = constructor.ConnectionString;
        }


    }
}
