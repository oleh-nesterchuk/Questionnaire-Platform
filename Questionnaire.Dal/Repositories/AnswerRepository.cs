using Questionnaire.Core.Abstractions.Repositories;
using Questionnaire.Core.Entities;

namespace Questionnaire.Dal.Repositories
{
    public class AnswerRepository : BaseRepository<Answer, int>, IAnswerRepository
    {
        public AnswerRepository(QuestionnaireDbContext context) : base(context) { }
    }
}
