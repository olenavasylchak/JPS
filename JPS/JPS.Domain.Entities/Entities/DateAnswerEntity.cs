using System;

namespace JPS.Domain.Entities.Entities
{
    public class DateAnswerEntity
    {
        public int AnswerId { get; set; }
        public DateTimeOffset Date { get; set; }
        public AnswerEntity Answer { get; set; }
    }
}
