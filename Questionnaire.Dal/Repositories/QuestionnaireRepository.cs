using Questionnaire.Core.Abstractions.Repositories;

namespace Questionnaire.Dal.Repositories
{
    public class QuestionnaireRepository : BaseRepository<Core.Entities.Questionnaire, int>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(QuestionnaireDbContext context) : base(context) { }
    }
}
