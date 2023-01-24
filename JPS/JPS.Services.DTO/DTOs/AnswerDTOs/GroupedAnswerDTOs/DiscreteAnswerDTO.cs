namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	public abstract class DiscreteAnswerDTO
	{
		public int Count { get; set; }
		public double PercentageToAlreadyAnswered { get; set; }
		public double PercentageToAll { get; set; }
	}
}
