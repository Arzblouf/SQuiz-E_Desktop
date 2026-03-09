using StadiumProject.Data;
using StadiumProject.Models;
using System;
using System.Collections.Generic;

namespace StadiumProject.Controllers
{
    public class AnsweringController
    {
        private readonly AnsweringRepository answeringRepository = new AnsweringRepository();

        public AnsweringController()
        {
            answeringRepository = new AnsweringRepository();
        }

        public List<Answering> GetAllAnswerings()
        {
            return answeringRepository.GetAllAnswerings();
        }

        public Answering GetAnsweringById(int id_question)
        {
            if (id_question <= 0)
            {
                return null;
            }
            return answeringRepository.GetAnsweringById(id_question);
        }

        public List<Answer> GetAnswersByQuestionId(int id_question)
        {
            if (id_question <= 0)
            {
                return null;
            }
            return answeringRepository.GetAnswersByQuestionId(id_question);
        }

        public bool CheckValidAnswer(int id_question)
        {
            if (id_question < 0)
            {
                return false;
            }
            return answeringRepository.CheckValidAnswer(id_question) > -1;
        }

        public (bool Success, string Message) LinkAnswer(int id_question, int id_answer, bool valid_answer)
        {
            if (id_question <= 0 || id_answer <= 0)
            {
                return (false, "ID de question ou de réponse invalide.");
            }
            int num_answer = answeringRepository.GetNextAnswerNumber(id_question);
            bool success = answeringRepository.LinkAnswer(id_question, id_answer, valid_answer, num_answer);
            return success ? (true, "Association question-réponse créée avec succès.") : (false, "Échec de la création de l'association question-réponse.");
        }

        public (bool Success, string Message) UpdateRightAnswer(int id_question, int id_answer)
        {
            if (id_question <= 0 || id_answer <= 0)
            {
                return (false, "ID de question ou de réponse invalide.");
            }
            bool success = answeringRepository.UpdateRightAnswer(id_question, id_answer);
            return success ? (true, "Association question-réponse mise à jour avec succès.") : (false, "Échec de la mise à jour de l'association question-réponse.");
        }

        public (bool Success, string Message) UnlinkAnswer(int id_question, int id_answer)
        {
            if (id_question <= 0 || id_answer <= 0)
            {
                return (false, "ID de question ou de réponse invalide.");
            }
            bool success = answeringRepository.UnlinkAnswer(id_question, id_answer);
            return success ? (true, "Association question-réponse supprimée avec succès.") : (false, "Échec de la suppression de l'association question-réponse.");
        }

        public (bool Success, string Message) DeleteAllByQuestion(int id_question)
        {
            if (id_question <= 0)
            {
                return (false, "ID de la question invalide.");
            }
            bool success = answeringRepository.DeleteAllByQuestion(id_question);
            return success ? (true, "Suppression des réponses à une question.") : (false, "Echec de la suppression des réponses à une question.");
        }
    }
}
