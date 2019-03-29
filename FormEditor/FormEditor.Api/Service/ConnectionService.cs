namespace FormEditor.Api
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;

    public static class ConnectionService
    {
        public static void AuditDbConnect(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreateAuditInfoTable.sql");
                string query = @System.IO.File.ReadAllText(path, Encoding.GetEncoding(1251));
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Connection = connection;
            }
        }
    }
}