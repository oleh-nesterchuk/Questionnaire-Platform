using Questionnaire.Core.Abstractions;

namespace Questionnaire.Core.Entities
{
    public class CompletedAnswer : IEntity<int>
    {
        public int Id { get; set; }

        public int CompletedSurveyId { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
