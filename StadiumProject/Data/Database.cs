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
                ConnectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca;";
                bddName = "stadiumproject";
            }
            else
            {
                ConnectionString = "Server=104.40.137.99;Port=22260;Database=joshua_ppe;User=developer;Password=cerfal1313;";
                bddName = "joshua_ppe";
            }
        }
    }
}
