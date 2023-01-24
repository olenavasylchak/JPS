using System.Collections.Generic;

namespace JPS.Domain.Entities.Entities
{
    public class QuestionTypeEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<QuestionEntity> Questions { get; set; }
    }
}
