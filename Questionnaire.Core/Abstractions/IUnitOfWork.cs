using Questionnaire.Core.Abstractions.Repositories;
using System;
using System.Threading.Tasks;

namespace Questionnaire.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IAnswerRepository AnswerRepository { get; }
        ICompletedAnswerRepository CompletedAnswerRepository { get; }
        ICompletedQuestionnaireRepository CompletedQuestionnaireRepository { get; }
        IQuestionnaireRepository QuestionnaireRepository { get; }
        IQuestionRepository QuestionRepository { get; }

        Task SaveChangesAsync();
    }
}
