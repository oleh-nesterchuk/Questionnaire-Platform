using Questionnaire.Core.Enums;
using System.Collections.Generic;

namespace Questionnaire.Core.Dto
{
    public class QuestionWithoutIdDto
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public bool IsRequired { get; set; }

        public int QuestionnaireId { get; set; }

        public ICollection<AnswerWithIdDto> Answers { get; set; }
    }
}
