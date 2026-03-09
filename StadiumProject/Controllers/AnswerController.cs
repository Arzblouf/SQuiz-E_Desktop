using StadiumProject.Data;
using StadiumProject.Models;
using System.Collections.Generic;

namespace StadiumProject.Controllers
{
    public class AnswerController
    {
        private readonly AnswerRepository answerRepository;

        public AnswerController()
        {
            answerRepository = new AnswerRepository();
        }

        public List<Answer> GetAllAnswers()
        {
            return answerRepository.GetAllAnswers();
        }

        public Answer GetAnswerById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return answerRepository.GetAnswerById(id);
        }

        public (bool Success, string Message, int id) CreateAnswer(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return (false, "Le contenu de la réponse ne peut pas être vide.", -1);
            }

            int newID = answerRepository.CreateAnswer(content);
            return newID > 0 ? (true, "Réponse ajoutée.",  newID) : (false, "Erreur lors de la création de la réponse.", -1);
        }

        public (bool Success, string Message) UpdateAnswer(int id, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return (false, "Le contenu de la réponse ne peut pas être vide.");
            }
            bool success = answerRepository.UpdateAnswer(id, content);
            return success ? (true, "Réponse mise à jour avec succès.") : (false, "Échec de la mise à jour de la réponse.");
        }

        public (bool Success, string Message) DeleteAnswer(int id)
        {
            if (id <= 0)
            {
                return (false, "ID de réponse invalide.");
            }
            bool success = answerRepository.DeleteAnswer(id);
            return success ? (true, "Réponse supprimée avec succès.") : (false, "Échec de la suppression de la réponse.");
        }
    }
}
