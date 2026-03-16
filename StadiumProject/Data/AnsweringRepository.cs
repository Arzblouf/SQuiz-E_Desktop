using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using StadiumProject.Models;

namespace StadiumProject.Data
{
    public class AnsweringRepository
    {
        private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca;";

        public List<Answering> GetAllAnswerings()
        {
            List<Answering> answerings = new List<Answering>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_question, id_answer, valid_answer, num_answer FROM answering;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var answering = new Answering
                                {
                                    id_question = reader.GetInt32("id"),
                                    id_answer = reader.GetInt32("id_question"),
                                    valid_answer = reader.GetBoolean("valid_answer"),
                                    num_answer = reader.GetInt32("num_answer")
                                };
                                answerings.Add(answering);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des réponses : " + ex.Message);
                    }
                }
            }
            return answerings;
        }

        public Answering GetAnsweringById(int id_question)
        {
            Answering answering = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_question, id_answer, valid_answer, num_answer FROM answering WHERE id_question = @id_question;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_question", id_question);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                answering = new Answering
                                {
                                    id_question = reader.GetInt32("id_question"),
                                    id_answer = reader.GetInt32("id_answer"),
                                    valid_answer = reader.GetBoolean("valid_answer"),
                                    num_answer = reader.GetInt32("num_answer")
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
            return answering;
        }

        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            List<Answer> answers = new List<Answer>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT answer.id, answer.content, answering.valid_answer, answering.num_answer FROM answer INNER JOIN answering ON answer.id=answering.id_answer INNER JOIN question ON answering.id_question=question.id WHERE question.id=@questionID;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(@"questionId", questionId);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var answer = new Answer
                                {
                                    id = reader.GetInt32("id"),
                                    content = reader.GetString("content"),
                                    valid_answer = reader.GetBoolean("valid_answer"),
                                    num_answer = reader.GetInt32("num_answer")
                                };
                                answers.Add(answer);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération des réponses de cette question." + ex.Message);
                    }
                }
            }
            return answers;
        }

        public int GetNextAnswerNumber(int id_question)
        {
            int nextNum = 1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COALESCE(MAX(num_answer), 0) + 1 FROM answering WHERE id_question = @id_question;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_question", id_question);
                    try
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération du numéro de réponse : " + ex.Message);
                    }
                }
            }
            return nextNum;
        }

        public bool HasValidAnswer(int id_question)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM answering WHERE id_question = @id_question AND valid_answer = 1;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(@"id_question", id_question);
                    try
                    {
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération d'une bonne réponse." + ex.Message);
                    }
                }
            }
            return false;
        }

        public bool LinkAnswer(int id_question, int id_answer, bool valid_answer, int num_answer, int weight = 0)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO answering (id_question, id_answer, valid_answer, num_answer, weight) VALUES (@id_question, @id_answer, @valid_answer, @num_answer, @weight);";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_question", id_question);
                    command.Parameters.AddWithValue("@id_answer", id_answer);
                    command.Parameters.AddWithValue("@valid_answer", valid_answer);
                    command.Parameters.AddWithValue("@num_answer", num_answer);
                    command.Parameters.AddWithValue("@weight", weight);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la création de la réponse : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateRightAnswer(int id_question, int id_answer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE answering SET valid_answer = true WHERE id_question = @id_question AND id_answer = @id_answer;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_question", id_question);
                    command.Parameters.AddWithValue("@id_answer", id_answer);
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

        public bool UpdateWeight(int id_question, int weight)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE answering SET weight = @weight WHERE id_question = @id_question AND valid_answer = 1;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@weight", weight);
                    command.Parameters.AddWithValue("@id_question", id_question);
                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la mise à jour des points de la réponse : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UnlinkAnswer(int id_question, int id_answer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM answering WHERE id_question = @id_question AND id_answer = @id_answer;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_question", id_question);
                    command.Parameters.AddWithValue("@id_answer", id_answer);
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

        public bool DeleteAllByQuestion(int id_question)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM answering WHERE id_question=@id_question;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(@"id_question", id_question);
                    try
                    {
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la suppression des réponses à une question." + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
