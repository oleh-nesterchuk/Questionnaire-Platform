using Questionnaire.Core.Abstractions.Repositories;
using System;

namespace Questionnaire.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IAnswerRepository AnswerRepository { get; }
        ICompletedAnswerRepository CompletedAnswerRepository { get; }
        ICompletedQuestionnaireRepository CompletedQuestionnaireRepository { get; }
        IQuestionnaireRepository QuestionnaireRepository { get; }
        IQuestionRepository QuestionRepository { get; }
    }
}
