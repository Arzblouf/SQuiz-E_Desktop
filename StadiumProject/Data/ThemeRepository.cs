using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using StadiumProject.Models;

namespace StadiumProject.Data
{
    public class ThemeRepository
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca";

        public List<Theme> GetAllThemes()
        {
            List<Theme> themes = new List<Theme>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, name FROM theme";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                themes.Add(new Theme
                                {
                                    id = reader.GetInt32("id"),
                                    name = reader.GetString("name")
                                });
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des thèmes : " + ex.Message);
                    }
                }
            }
            return themes;
        }
    }
}
