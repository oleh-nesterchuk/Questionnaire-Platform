using Questionnaire.Core.Abstractions;
using Questionnaire.Core.Enums;
using System.Collections.Generic;

namespace Questionnaire.Core.Entities
{
    public class Question : IEntity<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public bool IsRequired { get; set; }

        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
