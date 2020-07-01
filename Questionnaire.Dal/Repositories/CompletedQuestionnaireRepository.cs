using Questionnaire.Core.Abstractions.Repositories;
using Questionnaire.Core.Entities;

namespace Questionnaire.Dal.Repositories
{
    public class CompletedQuestionnaireRepository : 
        BaseRepository<CompletedQuestionnaire, int>, ICompletedQuestionnaireRepository
    {
        public CompletedQuestionnaireRepository(QuestionnaireDbContext context) : base(context) { }
    }
}
