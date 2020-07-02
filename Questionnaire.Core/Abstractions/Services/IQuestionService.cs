using Questionnaire.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Core.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<QuestionWithIdDto> GetFullQuestionByIdAsync(int id);

        ICollection<QuestionWithIdDto> GetAllQuestions(int questionnaireId);

        Task<QuestionWithIdDto> AddQuestionAsync(QuestionWithoutIdDto dto);

        Task<QuestionWithIdDto> UpdateQuestionAsync(QuestionWithIdDto dto);

        Task DeleteQuestionAsync(int id);
    }
}
