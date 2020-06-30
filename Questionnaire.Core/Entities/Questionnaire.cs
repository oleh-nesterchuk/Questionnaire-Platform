using Questionnaire.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace Questionnaire.Core.Entities
{
    public class Questionnaire : IEntity<int>
    {
        public int Id { get; set; }

        public bool IsAnonymous { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }

        public int CreatorId { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
