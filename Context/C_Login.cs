using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Project_SpareLog.App.Core;
using Project_SpareLog.Core.Model;
using Project_SpareLog.Core.Interface;

namespace Project_SpareLog.Context
{
    public class C_Login : ILoginService
    {
        private readonly DatabaseWrapper db = new DatabaseWrapper();

        public bool Login(string password)
        {
            try
            {
                string query = "SELECT * FROM users WHERE password = @password";
                NpgsqlParameter[] parameters = {
                    new NpgsqlParameter("@password", password)
                };

                DataTable dt = db.queryExecutor(query, parameters);
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error untuk login: {ex.Message}");
                return false;
            }
        }
    }
}
