namespace Questionnaire.Core.Dto
{
    public class AnswerWithIdDto
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public bool CanUserWrite { get; set; }

        public int QuestionId { get; set; }
    }
}
