using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.Abstractions.Repositories;
using System.Threading.Tasks;

namespace Questionnaire.Dal.Repositories
{
    public class QuestionnaireRepository : BaseRepository<Core.Entities.Questionnaire, int>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(QuestionnaireDbContext context) : base(context) { }

        public override async Task<Core.Entities.Questionnaire> GetByIdAsync(int id)
        {
            return await _context.Questionnaires
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
