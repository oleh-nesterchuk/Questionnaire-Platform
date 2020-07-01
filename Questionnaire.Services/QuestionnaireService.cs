using Questionnaire.Core.Abstractions.Services;
using Questionnaire.Core.Dto;
using Questionnaire.Dal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly QuestionnaireDbContext _context;

        public QuestionnaireService(QuestionnaireDbContext context)
        {
            _context = context;
        }

        public Task<FullQuestionnaireDto> GetFullQuestionnaireByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<QuestionnaireInfoDto> GetAllQuestionnaires()
        {
            throw new System.NotImplementedException();
        }

        public Task<QuestionnaireInfoDto> AddQuestionnaireAsync(FullQuestionnaireDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<QuestionnaireInfoDto> UpdateQuestionnaireAsync(QuestionnaireInfoDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteQuestionnaireAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
