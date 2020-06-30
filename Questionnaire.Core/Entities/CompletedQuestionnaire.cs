using Questionnaire.Core.Abstractions;
using System;

namespace Questionnaire.Core.Entities
{
    public class CompletedQuestionnaire : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime CompletionTime { get; set; }

        public int ParticipantId { get; set; }

        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
