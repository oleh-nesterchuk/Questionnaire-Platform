using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.Abstractions.Repositories;
using Questionnaire.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Dal.Repositories
{
    public class QuestionRepository : BaseRepository<Question, int>, IQuestionRepository
    {
        public QuestionRepository(QuestionnaireDbContext context) : base(context) { }

        public override async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public IQueryable<Question> GetAll(int questionnaireId)
        {
            return _context.Questions
                .Include(q => q.Answers)
                .Where(q => q.QuestionnaireId == questionnaireId);
        }
    }
}
