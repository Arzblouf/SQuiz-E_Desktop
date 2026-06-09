using System;
using MySql.Data.MySqlClient;
using StadiumProject.Models;

namespace StadiumProject.Data
{
    public class UserRepository
    {
        //private readonly string connectionString = "Server=localhost;Database=stadiumproject;User=root;Password=groscaca;";

        public bool RegisterUser(string email, string username, string password)
        {
            int workfactor = 15;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, workfactor);

            using (MySqlConnection connection = new MySqlConnection(Database.ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (email, username, passwordHash) VALUES (@Email, @Username, @PasswordHash);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de l'enregistrement : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public User LoginUser(string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Database.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users WHERE email = @Email;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader.GetString("passwordHash");
                                if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                                {
                                    return new User
                                    {
                                        id = reader.GetInt32("id"),
                                        email = reader.GetString("email"),
                                        username = reader.GetString("username"),
                                        passwordHash = storedHash
                                    };
                                }
                            }
                        }

                        return null;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la connexion : " + ex.Message);
                        return null;
                    }
                }
            }
        }

        public int GetUserIdByEmail(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "SELECT id FROM Users WHERE email = @Email;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    try
                    {
                        var result = command.ExecuteScalar();
                        if (result != null && Convert.ToInt32(result) > 0)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            Console.WriteLine("Aucun utilisateur trouvé avec cet email.");
                            return -1;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur lors de la récupération de l'ID utilisateur : " + ex.Message);
                        return -1;
                    }
                }
            }
        }
    }
}
