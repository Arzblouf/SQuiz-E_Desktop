using MySql.Data.MySqlClient;
using StadiumProject.Models;
using System;
using System.Collections.Generic;

namespace StadiumProject.Data
{
    internal class IssueRepository
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca;";

        public List<Issue> GetAllIssues()
        {
            List<Issue> issues = new List<Issue>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT probleme.id, probleme.description, users.username FROM probleme JOIN users ON probleme.id_user = users.id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var issue = new Issue
                                {
                                    id = reader.GetInt32("id"),
                                    description = reader.GetString("description"),
                                    username = reader.GetString("username")
                                };
                                issues.Add(issue);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des problèmes : " + ex.Message);
                    }
                }
            }
            return issues;
        }
    }
}
