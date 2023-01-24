using System.Collections.Generic;

namespace JPS.Domain.Entities.Entities
{
    public class AnswerEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public QuestionEntity Question { get; set; }
        public FileAnswerEntity FileAnswer { get; set; }
        public List<OptionAnswerEntity> OptionAnswers { get; set; }
        public TextAnswerEntity TextAnswer { get; set; }
        public DateAnswerEntity DateAnswer { get; set; }
        public TimeAnswerEntity TimeAnswer { get; set; }
        public ParagraphAnswerEntity ParagraphAnswer { get; set; }
    }
}
