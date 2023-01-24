namespace JPS.Domain.Entities.Entities
{
    public class OptionAnswerEntity
    {
        public int Id { get; set; }
        public int OptionId { get; set; }
        public int AnswerId { get; set; }
        public int? OptionRowId { get; set; }
        public OptionEntity Option { get; set; }
        public OptionRowEntity OptionRow { get; set; }
        public AnswerEntity Answer { get; set; }
    }
}
