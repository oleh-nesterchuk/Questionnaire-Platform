using Questionnaire.Core.Abstractions;
using Questionnaire.Core.Abstractions.Repositories;
using Questionnaire.Dal.Repositories;

namespace Questionnaire.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuestionnaireDbContext _context;

        private IAnswerRepository _answerRepository;
        private ICompletedAnswerRepository _completedAnswerRepository;
        private ICompletedQuestionnaireRepository _completedQuestionnaireRepository;
        private IQuestionnaireRepository _questionnaireRepository;
        private IQuestionRepository _questionRepository;

        public UnitOfWork(QuestionnaireDbContext context)
        {
            _context = context;
        }

        public IAnswerRepository AnswerRepository =>
            _answerRepository ??= new AnswerRepository(_context);

        public ICompletedAnswerRepository CompletedAnswerRepository =>
            _completedAnswerRepository ??= new CompletedAnswerRepository(_context);

        public ICompletedQuestionnaireRepository CompletedQuestionnaireRepository =>
            _completedQuestionnaireRepository ??= new CompletedQuestionnaireRepository(_context);

        public IQuestionnaireRepository QuestionnaireRepository =>
            _questionnaireRepository ??= new QuestionnaireRepository(_context);

        public IQuestionRepository QuestionRepository =>
            _questionRepository ??= new QuestionRepository(_context);

        #region IDisposable Implementation
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
