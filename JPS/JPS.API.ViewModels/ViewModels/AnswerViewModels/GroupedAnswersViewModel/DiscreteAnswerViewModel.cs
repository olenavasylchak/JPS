namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel
{
	public abstract class DiscreteAnswerViewModel
	{
		public int Count { get; set; }
		public double PercentageToAlreadyAnswered { get; set; }
		public double PercentageToAll { get; set; }
	}
}
