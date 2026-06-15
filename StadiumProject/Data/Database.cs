using System;

namespace StadiumProject.Data
{
    internal class Database
    {
        public string bddUtilisee = "local";
        public static string ConnectionString = "";
        public string bddName = "";

        public Database()
        {
            if (bddUtilisee == "local")
            {
                ConnectionString = "Server=;Database=;User=;Password=;";
                bddName = "stadiumproject";
            }
            else
            {
                ConnectionString = "Server=;Port=;Database=;User=;Password=;";
                bddName = "joshua_ppe";
            }
        }
    }
}
