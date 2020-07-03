using Questionnaire.Core.Abstractions.Repositories;
using Questionnaire.Core.Entities;
using System.Linq;

namespace Questionnaire.Dal.Repositories
{
    public class AnswerRepository : BaseRepository<Answer, int>, IAnswerRepository
    {
        public AnswerRepository(QuestionnaireDbContext context) : base(context) { }

        public IQueryable<Answer> GetAll(int questionId)
        {
            return _context.Answers.Where(a => a.QuestionId == questionId);
        }
    }
}
