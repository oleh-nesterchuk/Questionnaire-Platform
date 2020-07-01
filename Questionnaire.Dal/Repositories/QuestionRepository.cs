using Questionnaire.Core.Abstractions.Repositories;
using Questionnaire.Core.Entities;

namespace Questionnaire.Dal.Repositories
{
    public class QuestionRepository : BaseRepository<Question, int>, IQuestionRepository
    {
        public QuestionRepository(QuestionnaireDbContext context) : base(context) { }
    }
}
