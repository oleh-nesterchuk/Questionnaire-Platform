using Questionnaire.Core.Abstractions;
using Questionnaire.Core.Enums;

namespace Questionnaire.Core.Entities
{
    public class Question : IEntity<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public bool IsRequired { get; set; }
    }
}
