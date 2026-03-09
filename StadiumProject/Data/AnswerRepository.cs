using MySql.Data.MySqlClient;
using StadiumProject.Models;
using System;
using System.Collections.Generic;

namespace StadiumProject.Data
{
    public class AnswerRepository
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca;";

        public List<Answer> GetAllAnswers()
        {
            var answers = new List<Answer>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, content FROM answer;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                answers.Add(new Answer
                                {
                                    id = reader.GetInt32("id"),
                                    content = reader.GetString("content")
                                });
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des réponses : " + ex.Message);
                    }
                }
            }
            return answers;
        }

        public Answer GetAnswerById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, content FROM answer WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Answer
                                {
                                    id = reader.GetInt32("id"),
                                    content = reader.GetString("content")
                                };
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération de la réponse : " + ex.Message);
                    }
                }
            }
            return null;
        }

        public int CreateAnswer(string content)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO answer (content) VALUES (@Content);" +
                    "SELECT LAST_INSERT_ID();";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Content", content);
                    try
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la création de la réponse : " + ex.Message);
                        return -1;
                    }
                }
            }
        }

        public bool UpdateAnswer(int id, string content)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE answer SET content = @Content WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Content", content);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la mise à jour de la réponse : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool DeleteAnswer(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM answer WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la suppression de la réponse : " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
