using Questionnaire.Core.Abstractions.Repositories;
using Questionnaire.Core.Entities;

namespace Questionnaire.Dal.Repositories
{
    public class CompletedAnswerRepository : BaseRepository<CompletedAnswer, int>, ICompletedAnswerRepository
    {
        public CompletedAnswerRepository(QuestionnaireDbContext context) : base(context) { }
    }
}
