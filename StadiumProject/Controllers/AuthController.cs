using System;
using StadiumProject.Models;
using StadiumProject.Data;

namespace StadiumProject.Controllers
{
    public class AuthController
    {
        private readonly UserRepository userRepository;

        public AuthController()
        {
            userRepository = new UserRepository();
        }

        public (bool Success, string Message) Register(string email, string username, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                return (false, "Veuillez remplir toutes les informations.");
            }

            if (password != confirmPassword)
            {
                return (false, "Les mots de passe ne sont pas identiques.");
            }

            if (password.Length < 8)
            {
                return (false, "Le mot de passe doit comporter au moins 8 caractères.");
            }

            bool success = userRepository.RegisterUser(email, username, password);
            return success ? (true, "Inscription confirmé") : (false, "Inscription impossible. L'email ou le pseudonyme sont déjà utilisés.");
        }

        public (bool Success, string Message, User User) Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return (false, "Veuillez remplir toutes les informations.", null);
            }
            User user = userRepository.LoginUser(email, password);
            return (user != null) ? (true, $"Bienvenue {user.username} !", user) : (false, "Email ou mot de passe incorrect.", null);
        }
    }
}
