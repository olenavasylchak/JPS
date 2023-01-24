using System.Collections.Generic;

namespace JPS.Domain.Entities.Entities
{
	public class OptionRowEntity
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public QuestionEntity Question { get; set; }
        public List<OptionAnswerEntity> OptionAnswers { get; set; }
	}
}
