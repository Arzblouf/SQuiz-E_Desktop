using System;
using MySql.Data.MySqlClient;

namespace StadiumProject
{
    public class DBConnection
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumProject;User=root;Password=groscaca;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
