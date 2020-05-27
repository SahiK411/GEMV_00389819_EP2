using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SourceCode
{
    public static class DBConnect
    {
        private static string host = "ec2-34-195-169-25.compute-1.amazonaws.com",
            database = "d203a0fernvfsl",
            userID = "rlwhxwgjtnqyib",
            password = "fd96baf17a4070bd346c7d6b80610f99a772e92a1c11c7288228ae5fdb5ddc02";

        private static string sConnection =
            $"Server={host};Port=5432;User Id={userID};Password={password};Database={database};" + 
            "sslmode=Require;Trust Server Certificate=true";

        public static DataTable ExecuteQuery(string query)
        {

            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            DataSet ds = new DataSet();

            connection.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);

            connection.Close();

            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);

            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
