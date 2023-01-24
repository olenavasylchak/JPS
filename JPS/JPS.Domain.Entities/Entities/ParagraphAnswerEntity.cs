namespace JPS.Domain.Entities.Entities
{
	public class ParagraphAnswerEntity
	{
		public int AnswerId { get; set; }
		public string Text { get; set; }
		public AnswerEntity Answer { get; set; }
	}
}
