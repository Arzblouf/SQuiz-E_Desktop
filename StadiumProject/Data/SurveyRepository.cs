using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using StadiumProject.Models;

namespace StadiumProject.Data
{
    public class SurveyRepository
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca;";

        public List<Survey> GetAllSurveys()
        {
            var surveys = new List<Survey>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT survey.id, survey.title, theme.name, survey.nb_questions, survey.publish FROM survey INNER JOIN theme ON survey.id_theme=theme.id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                surveys.Add(new Survey
                                {
                                    id = reader.GetInt32("id"),
                                    title = reader.GetString("title"),
                                    name = reader.GetString("name"),
                                    nb_questions = reader.GetInt32("nb_questions"),
                                    publish = reader.GetBoolean("publish")
                                });
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des sondages : " + ex.Message);
                    }
                }
            }
            return surveys;
        }

        public Survey GetSurveyById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, title, id_theme, publish FROM survey WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Survey
                                {
                                    id = reader.GetInt32("id"),
                                    title = reader.GetString("title"),
                                    id_theme = reader.GetInt32("id_theme"),
                                    publish = reader.GetBoolean("publish")
                                };
                            }
                            else
                            {
                                Console.WriteLine("Sondage non trouvé.");
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de l'accès au sondage : " + ex.Message);
                    }
                }
            }
            return null;
        }

        public bool CreateSurvey(string title, int id_theme, bool publish, int nb_questions = 0)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO survey (title, id_theme, nb_questions, publish) VALUES (@Title, @IdTheme, @NbQuestions, @Publish);";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@IdTheme", id_theme);
                    command.Parameters.AddWithValue("@NbQuestions", nb_questions);
                    command.Parameters.AddWithValue("@Publish", publish);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la soumission du sondage : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateSurvey(int id, string title, int id_theme, bool publish)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE survey SET title = @Title, id_theme = @IdTheme, publish = @Publish WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@IdTheme", id_theme);
                    command.Parameters.AddWithValue("@Publish", publish);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la modification du sondage : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateNbQuestions(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE survey SET nb_questions = nb_questions + 1 WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la mise à jour du nombre de questions du sondage : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool DeleteSurvey(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM survey WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la suppression du sondage : " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
