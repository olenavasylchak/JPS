using System;
using System.Collections.Generic;

namespace JPS.Domain.Entities.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public List<CategoryEntity> Categories { get; set; }
        public CategoryEntity Category { get; set; }
        public List<PollEntity> Polls { get; set; }
    }
}
