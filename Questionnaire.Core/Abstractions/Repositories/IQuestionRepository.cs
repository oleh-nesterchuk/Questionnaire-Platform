using Questionnaire.Core.Entities;
using System.Linq;

namespace Questionnaire.Core.Abstractions.Repositories
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        IQueryable<Question> GetAll(int questionnaireId);
    }
}
