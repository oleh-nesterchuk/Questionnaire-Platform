﻿using System;
using System.Collections.Generic;

namespace Questionnaire.Core.Dto
{
    public class FullQuestionnaireDto
    {
        public int Id { get; set; }

        public bool IsAnonymous { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }

        public int CreatorId { get; set; }

        public ICollection<QuestionWithIdDto> Questions { get; set; }
    }
}
