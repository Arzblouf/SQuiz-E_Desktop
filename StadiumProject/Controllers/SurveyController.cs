using StadiumProject.Models;
using StadiumProject.Data;
using System.Collections.Generic;

namespace StadiumProject.Controllers
{
    public class SurveyController
    {
        private readonly SurveyRepository surveyRepository;

        public SurveyController()
        {
            surveyRepository = new SurveyRepository();
        }

        public List<Survey> GetAllSurveys()
        {
            return surveyRepository.GetAllSurveys();
        }

        public Survey GetSurveyById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return surveyRepository.GetSurveyById(id);
        }

        public (bool Success, string Message) CreateSurvey(string title, int id_theme, bool publish)
        {
            if (string.IsNullOrEmpty(title) || id_theme <= 0)
            {
                return (false, "Veuillez remplir toutes les informations correctement.");
            }
            bool success = surveyRepository.CreateSurvey(title, id_theme, publish);
            return success ? (true, "Sondage soumis avec succès.") : (false, "Échec de la soumission du sondage.");
        }

        public (bool Success, string Message) UpdateSurvey(int id, string title, int id_theme, bool publish)
        {
            if (id <= 0 || string.IsNullOrEmpty(title) || id_theme <= 0)
            {
                return (false, "Veuillez remplir toutes les informations correctement.");
            }
            bool success = surveyRepository.UpdateSurvey(id, title, id_theme, publish);
            return success ? (true, "Sondage mis à jour avec succès.") : (false, "Échec de la mise à jour du sondage.");
        }

        public (bool Success, string Message) UpdateNbQuestions(int id)
        {
            if (id <= 0)
            {
                return (false, "ID de sondage ou nombre de questions invalide.");
            }
            bool success = surveyRepository.UpdateNbQuestions(id);
            return success ? (true, "Nombre de questions mis à jour avec succès.") : (false, "Échec de la mise à jour du nombre de questions.");
        }

        public (bool Success, string Message) DeleteSurvey(int id)
        {
            if (id <= 0)
            {
                return (false, "ID de sondage invalide.");
            }
            bool success = surveyRepository.DeleteSurvey(id);
            return success ? (true, "Sondage supprimé avec succès.") : (false, "Échec de la suppression du sondage.");
        }
    }
}
