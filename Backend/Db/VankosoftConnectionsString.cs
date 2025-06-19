using Microsoft.Data.SqlClient;

namespace Backend.Db
{
    public class VankosoftConnectionString
    {
        public static string ConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
               
            builder["Server"] = "127.0.0.1";
            builder["Initial Catalog"] = "Backgammon";
            builder["User ID"] = "SA";
            builder["Password"] = "Ophthalamia@123";
            
            builder["Connect Timeout"] = 60;
            builder["Encrypt"] = false;
            
            return builder.ConnectionString;
        }
    }
}