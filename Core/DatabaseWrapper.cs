using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Project_SpareLog.App.Core
{
    public class DatabaseWrapper
    {
        private static readonly string DB_HOST = "localhost";
        private static readonly string DB_DATABASE = "DBProject";
        private static readonly string DB_USERNAME = "postgres";
        private static readonly string DB_PASSWORD = "@Raditya14";
        private static readonly string DB_PORT = "5432";

        public DataTable queryExecutor(string query, NpgsqlParameter[] parameters = null)
        {
            using (var connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}"))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //public void CommandExecutor(string query, NpgsqlParameter[] parameters = null)
        //{
        //    using (var connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}"))
        //    {
        //        connection.Open();
        //        using (var command = new NpgsqlCommand(query, connection))
        //        {
        //            if (parameters != null)
        //            {
        //                command.Parameters.AddRange(parameters);
        //            }
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        public int ExecuteNonQuery(string query, NpgsqlParameter[] parameters = null)
        {
            using (var connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}"))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }

    }
}
