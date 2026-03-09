using System;
using System.Collections.Generic;
using StadiumProject.Models;
using StadiumProject.Data;
using System.Linq;

namespace StadiumProject.Controllers
{
    public class QuestionController
    {
        private readonly QuestionRepository questionRepository;

        public QuestionController()
        {
            questionRepository = new QuestionRepository();
        }

        public List<Question> GetAllQuestions()
        {
            return questionRepository.GetAllQuestions();
        }

        public List<Include> GetSurveyQuestions(int surveyId)
        {
            return questionRepository.GetSurveyQuestions(surveyId);
        }

        public List<Question> getAvailableQuestions(int surveyId)
        {
            List<Question> allQuestions = questionRepository.GetAllQuestions();
            List<Include> surveyQuestions = questionRepository.GetSurveyQuestions(surveyId);

            var existingIds = surveyQuestions.Select(q => q.id_question).ToHashSet();
            return allQuestions.Where(q => !existingIds.Contains(q.id)).ToList();
        }

        public Question GetQuestionById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return questionRepository.GetQuestionById(id);
        }

        public (bool Success, string Message) AddQuestionToSurvey(int surveyId, int questionId)
        {
            if (surveyId <= 0 || questionId <= 0)
            {
                return (false, "ID de sondage ou de question invalide.");
            }
            int nextNumber = questionRepository.GetNextQuestionNumber(surveyId);
            bool success = questionRepository.AddQuestionToSurvey(surveyId, questionId, nextNumber);
            return success ? (true, "Question ajoutée au sondage avec succès.") : (false, "Échec de l'ajout de la question au sondage.");
        }

        public (bool Success, string Message) RemoveQuestionFromSurvey(int surveyId, int questionId)
        {
            if (surveyId <= 0 || questionId <= 0)
            {
                return (false, "ID de sondage ou de question invalide.");
            }
            bool success = questionRepository.RemoveQuestionFromSurvey(surveyId, questionId);
            return success ? (true, "Question retirée du sondage avec succès.") : (false, "Échec du retrait de la question du sondage.");
        }

        public (bool Success, string Message) CreateQuestion(string caption, int id_type)
        {
            if (string.IsNullOrEmpty(caption))
            {
                return (false, "Veuillez remplir toutes les informations correctement.");
            }
            bool success = questionRepository.CreateQuestion(caption, id_type);
            return success ? (true, "Question créée avec succès.") : (false, "Échec de la création de la question.");
        }

        public (bool Success, string Message) UpdateQuestion(int id, string caption, int id_type)
        {
            if (id <= 0 || string.IsNullOrEmpty(caption))
            {
                return (false, "ID de question invalide ou légende vide.");
            }
            bool success = questionRepository.UpdateQuestion(id, caption, id_type);
            return success ? (true, "Question mise à jour avec succès.") : (false, "Échec de la mise à jour de la question.");
        }

        public (bool Success, string Message) DeleteQuestion(int id)
        {
            if (id <= 0)
            {
                return (false, "ID de question invalide.");
            }
            bool success = questionRepository.DeleteQuestion(id);
            return success ? (true, "Question supprimée avec succès.") : (false, "Échec de la suppression de la question.");
        }
    }
}
