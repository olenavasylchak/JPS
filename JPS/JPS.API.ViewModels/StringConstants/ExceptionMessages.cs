
namespace JPS.API.ViewModels.StringConstants
{
	public static class ExceptionMessages
	{
		public static readonly string IdLowerThanOneMessage = "Your Id is lover than 1!";
		public static readonly string BadIdTypeMessage = "Wrong Id type!";
		public static string DateIsEarlierThanCurrentDateMessage = "Given date cannot be earlier than the сurrent date";
		public static string EndDateIsEarlierThanStartDateMessage = "The finish date cannot be earlier than the start date";
		public static string NoPropertyFoundMessage = "No comparison property for IsLaterThanAttribute found";
		public static string MultipleChoiceGridAllowsOneAnswerPerRowMessage = "Multiple choice grid allows one " +
			"answer per row!";
		public static string OneOptionSelectedTwiceMessage = "You cannot select one option twice";
		public static string OneQuestionAnsweredTwiceMessage = "You cannot answer for the same question twice";

		public static string PollHasNoSectionMessage = "You cannot create poll without any section";
		public static string PollHasNoQuestionMessage = "You cannot create poll without any question";
		public static string SectionsHaveOrderDuplicatesMessage = "You cannot add sections with same order";
		public static string QuestionsHaveOrderDuplicatesMessage = "You cannot add questions with same order";
		public static string QuestionTypeWithNoOptionsMessage = "You cannot add options to question of such type";
		public static string QuestionTypeWithNoRowsMessage = "You cannot add rows to question of such type";
		public static string NotEnoughOptionsMessage = "You must enter at least 2 options";
		public static string NotEnoughRowsMessage = "You must enter at least 2 rows";
		public static string OptionsHaveOrderDuplicatesMessage = "You cannot add options with same order";
		public static string RowsHaveOrderDuplicatesMessage = "You cannot add rows with same order";
		public static string QuestionTypeWithNoValuesMessage = "Option of such question type cannot have value";
		public static string OptionsHaveValueDuplicatesMessage = "You cannot add options with same value";
		public static string InvalidQuestionTypeMessage = "There is no such type of question";
		public static readonly string QuestionCantAllowOtherOptionMessage
			= "Question of that type cannot allow to create 'other' option.";
		public static readonly string SamePollIdsToCompareMessage
			= "You cannot compare poll with the same poll. Enter different poll Ids";
		public static string NotGivenRowsOrOptionsMessage = "You must enter at least 2 options and 1 row to the question of that type";
		public static string OptionDoesntHaveValueMessage = "Every option that belongs to question of linear type should have value";
		public static string OptionHaveValueMessage = "Every option that belongs to question of that type cannot have value";
		public static string InvalidGuidTypeInputMessage = "The input must be of Guid type";
	}
}
