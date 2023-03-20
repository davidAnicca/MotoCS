using System;
using System.Collections.Specialized;
using System.Data.SqlClient;

using System.Data.SQLite;

namespace Motocliclisti.Repo
{
    public class JdbcUtils
    {
        private readonly string connectionString;

        public JdbcUtils(string props)
        {
            connectionString = props;
        }

        private SQLiteConnection instance = null;

        private SQLiteConnection GetNewConnection()
        {
            Console.WriteLine(connectionString);
            SQLiteConnection con = new SQLiteConnection(connectionString);

            try
            {
                con.Open();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("Error getting connection " + e);
            }

            return con;
        }

        public SQLiteConnection GetConnection()
        {
            try
            {
                if (instance == null || instance.State == System.Data.ConnectionState.Closed)
                {
                    instance = GetNewConnection();
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("Error DB " + e);
            }

            return instance;
        }
    }
}