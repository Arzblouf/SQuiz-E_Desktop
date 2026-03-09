using StadiumProject.Data;
using StadiumProject.Models;
using System.Collections.Generic;

namespace StadiumProject.Controllers
{
    public class QuestionTypeController
    {
        private readonly QuestionTypeRepository questionTypeRepository;

        public QuestionTypeController()
        {
            questionTypeRepository = new QuestionTypeRepository();
        }

        public List<QuestionType> GetAllQuestionTypes()
        {
            return questionTypeRepository.GetAllQuestionTypes();
        }

        public QuestionType GetTypeByQuestionId(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return questionTypeRepository.GetTypeByQuestionId(id);
        }
    }
}
