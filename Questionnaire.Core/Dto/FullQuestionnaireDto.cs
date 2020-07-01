using System;

namespace Questionnaire.Core.Dto
{
    public class FullQuestionnaireDto
    {
        public int Id { get; set; }

        public bool IsAnonymous { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }

        public int CreatorId { get; set; }
    }
}
