using Microsoft.Data.SqlClient;

namespace OuglaWebApp.DataLogic
{
    public class GlobalConfig
    {
        public static string siteName;
        public static string ConnectionString= @"Data Source=DESKTOP-M4962FO\MSSQLSERVER03;Initial Catalog=ougla;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection con = new SqlConnection(ConnectionString);
        public GlobalConfig()
        {

        }
    }
}
