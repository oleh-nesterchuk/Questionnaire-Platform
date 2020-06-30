using Questionnaire.Core.Abstractions;

namespace Questionnaire.Core.Entities
{
    public class Answer : IEntity<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public bool CanUserWrite { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
