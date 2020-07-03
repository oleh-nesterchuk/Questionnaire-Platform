using Questionnaire.Core.Entities;
using System.Linq;

namespace Questionnaire.Core.Abstractions.Repositories
{
    public interface IAnswerRepository : IRepository<Answer, int>
    {
        IQueryable<Answer> GetAll(int questionId);
    }
}
