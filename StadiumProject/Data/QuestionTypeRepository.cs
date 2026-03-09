using MySql.Data.MySqlClient;
using StadiumProject.Models;
using System;
using System.Collections.Generic;

namespace StadiumProject.Data
{
    public class QuestionTypeRepository
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca;";

        public List<QuestionType> GetAllQuestionTypes()
        {
            List<QuestionType> questionTypes = new List<QuestionType>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, label FROM question_type;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                questionTypes.Add(new QuestionType
                                {
                                    id = reader.GetInt32("id"),
                                    label = reader.GetString("label")
                                });
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des types de questions : " + ex.Message);
                    }
                }
                return questionTypes;
            }
        }

        public QuestionType GetTypeByQuestionId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT question_type.id, question_type.label FROM question_type INNER JOIN question ON question_type.id=question.id_type WHERE question.id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new QuestionType
                                {
                                    id = reader.GetInt32("id"),
                                    label = reader.GetString("label")
                                };
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération du type de question : " + ex.Message);
                    }
                }
            }
            return null;
        }
    }
}
