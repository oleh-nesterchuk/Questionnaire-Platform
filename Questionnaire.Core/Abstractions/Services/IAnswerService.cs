using Questionnaire.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Core.Abstractions.Services
{
    public interface IAnswerService
    {
        Task<AnswerWithIdDto> GetAnswerByIdAsync(int id);

        ICollection<AnswerWithIdDto> GetAllAnswers(int questionId);

        Task<AnswerWithIdDto> AddAnswerAsync(AnswerWithoutIdDto dto);

        Task<AnswerWithIdDto> UpdateAnswerAsync(AnswerWithIdDto dto);

        Task DeleteAnswerAsync(int id);
    }
}
