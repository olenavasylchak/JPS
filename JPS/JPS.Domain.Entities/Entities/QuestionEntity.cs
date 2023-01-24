using System.Collections.Generic;

namespace JPS.Domain.Entities.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionSectionId { get; set; }
        public bool IsRequired { get; set; }
        public bool CanHaveOtherOption { get; set; }
        public string Comment { get; set; }
        public int Order { get; set; }
        public int? PrototypeQuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public QuestionEntity PrototypeQuestion { get; set; }
        public List<QuestionEntity> QuestionClones { get; set; }
        public QuestionSectionEntity QuestionSection { get; set; }
        public QuestionTypeEntity QuestionType { get; set; }
        public List<OptionEntity> Options { get; set; }
        public List<OptionRowEntity> OptionRows { get; set; }
        public List<AnswerEntity> Answers { get; set; }
    }
}
