using System;

namespace JPS.Domain.Entities.Entities
{
    public class TimeAnswerEntity
    {
        public int AnswerId { get; set; }
        public TimeSpan Time { get; set; }
        public AnswerEntity Answer { get; set; }
    }
}
