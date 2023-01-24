using System;
using System.Collections.Generic;

namespace JPS.Domain.Entities.Entities
{
    public class PollEntity
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? StartsAt { get; set; }
        public DateTimeOffset? FinishesAt { get; set; }
        public string StartPollJobId { get; set; }
        public string EndPollJobId { get; set; }
        public string InProgressPollJobId { get; set; }
        public CategoryEntity Category { get; set; }
        public List<QuestionSectionEntity> QuestionSections { get; set; }
        public PollStyleEntity PollStyle { get; set; }
    }
}
