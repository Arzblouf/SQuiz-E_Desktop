using MySql.Data.MySqlClient;
using StadiumProject.Models;
using System;
using System.Collections.Generic;

namespace StadiumProject.Data
{
    public class QuestionRepository
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca";

        public List<Question> GetAllQuestions()
        {
            var questions = new List<Question>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT question.id, question.caption, question_type.label FROM question INNER JOIN question_type ON question.id_type = question_type.id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                questions.Add(new Question
                                {
                                    id = reader.GetInt32("id"),
                                    caption = reader.GetString("caption"),
                                    label = reader.GetString("label")
                                });
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des questions : " + ex.Message);
                    }
                }
            }
            return questions;
        }

        public List<Include> GetSurveyQuestions(int surveyId)
        {
            var surveyQuestions = new List<Include>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT include.id_survey, include.id_question, include.num_question, question.caption, question_type.label
                                 FROM include
                                 INNER JOIN question ON include.id_question = question.id
                                 INNER JOIN question_type ON question.id_type = question_type.id
                                 WHERE include.id_survey = @SurveyId
                                 ORDER BY include.num_question;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SurveyId", surveyId);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                surveyQuestions.Add(new Include
                                {
                                    id_survey = reader.GetInt32("id_survey"),
                                    id_question = reader.GetInt32("id_question"),
                                    num_question = reader.GetInt32("num_question"),
                                    caption = reader.GetString("caption"),
                                    label = reader.GetString("label")
                                });
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des questions du sondage : " + ex.Message);
                    }
                }
                return surveyQuestions;
            }
        }

        public bool AddQuestionToSurvey(int surveyId, int questionId, int numQuestion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO include (id_survey, id_question, num_question) VALUES (@SurveyId, @QuestionId, @NumQuestion);";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SurveyId", surveyId);
                    command.Parameters.AddWithValue("@QuestionId", questionId);
                    command.Parameters.AddWithValue("@NumQuestion", numQuestion);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de l'ajout de la question au sondage : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool RemoveQuestionFromSurvey(int surveyId, int questionId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM include WHERE id_survey = @SurveyId AND id_question = @QuestionId;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SurveyId", surveyId);
                    command.Parameters.AddWithValue("@QuestionId", questionId);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la suppression de la question du sondage : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public int GetNextQuestionNumber(int surveyId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COALESCE(MAX(num_question), 0) + 1 FROM include WHERE id_survey = @SurveyId;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SurveyId", surveyId);
                    try
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération du numéro de question suivant : " + ex.Message);
                        return 1;
                    }
                }
            }
        }

        public Question GetQuestionById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT question.id, question.caption, question.id_type, question_type.label FROM question JOIN question_type ON question.id_type=question_type.id WHERE question.id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Question
                                {
                                    id = reader.GetInt32("id"),
                                    caption = reader.GetString("caption"),
                                    id_type = reader.GetInt32("id_type"),
                                    label = reader.GetString("label")
                                };
                            }
                            else
                            {
                                Console.WriteLine("Aucune question trouvée.");
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération de la question : " + ex.Message);
                    }
                }
            }
            return null;
        }

        public bool CreateQuestion(string caption, int id_type)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO question (caption, id_type) VALUES (@Caption, @Id_Type);";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Caption", caption);
                    command.Parameters.AddWithValue("@Id_Type", id_type);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la création de la question : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateQuestion(int id, string caption, int id_type)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE question SET caption = @Caption, id_type = @Id_Type WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Caption", caption);
                    command.Parameters.AddWithValue("@Id_Type", id_type);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la mise à jour de la question : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool DeleteQuestion(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM question WHERE id = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la suppression de la question : " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
