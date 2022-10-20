using System.Data.SqlClient;

namespace Shop
{
    public class Connection
    {
        static SqlConnection sqlConnection;
        public static SqlConnection GetConnection()
        {
            if(sqlConnection == null)
            {
                sqlConnection = new SqlConnection("Data Source=SQL8003.site4now.net;Initial Catalog=;User Id=db_a8e8b3_shop_admin;Password=qwerty123;TrustServerCertificate=True");
                sqlConnection.Open();
            }
            return sqlConnection;   
        }
    }
}
