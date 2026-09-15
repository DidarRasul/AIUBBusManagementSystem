using Microsoft.Data.SqlClient;

namespace AIUBBusManagementSystem.Utils
{
    internal class DbConnection
    {
        private static readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=AIUBBusManagementSystem;
              Integrated Security=True;
              TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}