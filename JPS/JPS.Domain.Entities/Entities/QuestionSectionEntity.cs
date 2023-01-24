using System.Collections.Generic;

namespace JPS.Domain.Entities.Entities
{
	public class QuestionSectionEntity
	{
		public int Id { get; set; }
		public int PollId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public PollEntity Poll { get; set; }
		public List<QuestionEntity> Questions { get; set; }
	}
}
