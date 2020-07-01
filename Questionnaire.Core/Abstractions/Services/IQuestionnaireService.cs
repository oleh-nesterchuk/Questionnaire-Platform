using Questionnaire.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Core.Abstractions.Services
{
    public interface IQuestionnaireService
    {
        Task<FullQuestionnaireDto> GetFullQuestionnaireByIdAsync(int id);
        
        ICollection<QuestionnaireInfoDto> GetAllQuestionnaires();
        
        Task<QuestionnaireInfoDto> AddQuestionnaireAsync(FullQuestionnaireDto dto);

        Task<QuestionnaireInfoDto> UpdateQuestionnaireAsync(QuestionnaireInfoDto dto);

        Task DeleteQuestionnaireAsync(int id);
    }
}
