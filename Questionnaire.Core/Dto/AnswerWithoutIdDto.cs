namespace Questionnaire.Core.Dto
{
    public class AnswerWithoutIdDto
    {
        public string Text { get; set; }
        public bool CanUserWrite { get; set; }

        public int QuestionId { get; set; }
    }
}
