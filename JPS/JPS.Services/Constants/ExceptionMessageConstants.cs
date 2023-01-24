namespace JPS.Services.Constants
{
	public static class ExceptionMessageConstants
	{
		//Answer exception messages
		public static readonly string AnswerNotFoundMessage
			= "Answer was not found.";
		public static readonly string BadQuestionIdMessage
			= "This method doesn't support that type of questions.";
		public static string DateIsEarlierThanCurrentDateMessage
			= "Given date cannot be earlier than the current date.";
		public static string EndDateIsEarlierThanStartDateMessage
			= "The finish date cannot be earlier than the start date.";
		public static string NoPropertyFoundMessage
			= "No comparison property for IsLaterThanAttribute found.";
		public static string MultipleChoiceGridAllowsOneAnswerPerRowMessage
			= "Multiple choice grid allows one answer per row.";
		public static string DeleteRequiredQuestionAnswerMessage = "You can't delete answer on required question";
		public static string NotAllRequiredQuestionAnsweredMessage
			= "Not all required questions were answered.";
		public static string NotAllRequiredRowsAnsweredMessage
			= "All rows in required questions should be answered.";
		public static string QuestionAnsweredMoreThanOneTimeMessage
			= "You can not answer this question more than one time.";
		public static string NotEveryAnswerHaveRowInGridQuestionMessage
			= "Questions of grid type obliges you to set row id for each option.";
		public static string OptionInRequiredQuestionWasntSelectedMessage
			= "At least one option in required question should be selected.";
		public static string MoreThanOneOptionSelectedMessage
			= "You cannot select two or more options in question of that type.";
		public static string QuestionDoesntHaveRowMessage
			= "Question doesn't have provided  row.";
		public static string QuestionDoesntHaveOptionMessage
			= "Question doesn't have provided option.";
		public static string UnsupportedQuestionTypeMessage
			= "Unsupported question type.";
		public static string FileDoesNotExistMessage
			= "File with provided id doens't exist.";
		public static string QuestionCannotHaveOtherOptionMessage
			= "The question cannot have 'other' option answer.";
		public static string UserHasNotAnsweredMessage
			= "User has not answered to this poll.";
		public static string QuestionCannotHaveOptionAndTextAnswersMessage
			= "You should select either suggested option or write your own.";
		public static string TextAnswerWithoutTextMessage
			= "Please, fill in other option field.";

		//Category exception messages
		public static readonly string CategoryNotFoundMessage
			= "The category was not found.";
		public static readonly string DeleteParentCategoryMessage
			= "You can't delete the category that has a subcategory.";
		public static readonly string DeleteCategoryWithPollMessage
			= "You can't delete the category that has a poll.";
		public static readonly string UpdateCategoryExceptionMessage
			= "Category cannot be a subcategory of its subcategories.";
		public static readonly string InvalidParentIdMessage
			= "You can't set this category as a parent because it doesn't exist.";

		//Question exception messages
		public static readonly string AnsweredQuestionMessage
			= "This question has an answer. You cannot change it.";
		public static readonly string UpdateAnsweredQuestionMessage
			= "This question has an answer. You cannot update it.";
		public static readonly string InvalidQuestionMessage
			= "Such question doesn't exist.";
		public static readonly string QuestionIsNotCompatibleWithDateAnswerTypeMessage
			= "Question isn't compatible with date answer type.";
		public static readonly string QuestionIsNotCompatibleWithTimeAnswerTypeMessage
			= "Question isn't compatible with time answer type.";
		public static readonly string QuestionIsNotCompatibleWithTextAnswerTypeMessage
			= "Question isn't compatible with text answer type.";
		public static readonly string QuestionIsNotCompatibleWithParagraphAnswerTypeMessage
			 = "Question isn't compatible with paragraph answer type.";
		public static readonly string QuestionIsNotCompatibleWithChoiceOptionAnswerTypeMessage
			= "Question isn't compatible with choice option answer type.";
		public static readonly string QuestionIsNotCompatibleWithCheckBoxOptionAnswerTypeMessage
			= "Question isn't compatible with check box option answer type.";
		public static readonly string QuestionIsNotCompatibleWithChoiceGridOptionAnswerTypeMessage
			= "Question isn't compatible with choice grid option answer type.";
		public static readonly string NotAllowedMultipleAnswersMessage
			 = "That type of question allows only one answer.";
		public static readonly string OptionForQuestionNotFoundMessage
			= "This question does not have such option answer.";
		public static readonly string AnswerAlreadyExistsMessage
			= "You have already answered this question, you cannot do it again.";
		public static readonly string QuestionNotFoundMessage
			= "Question was not found.";
		public static readonly string PollContainsLessOrMoreQuestions
			 = "You should update all questions of one poll.";
		public static readonly string NotAllowedNullAndValueOrdersInOneSection
			= "In one poll all questions should be with order or all without order.";
		public static readonly string QuestionCantAllowOtherOptionMessage
			= "Question of that type cannot allow to create 'other' option.";
		public static readonly string QuestionsFromDifferentPolls
			= "You should update all questions of one poll.";

		//Poll exception messages
		public static readonly string InvalidPollDeletingAfterAnswerMessage
			= "You cannot delete this poll, because somebody has already answered it.";
		public static readonly string InvalidPollUpdatingAfterAnswerMessage
			= "You cannot update this poll, because somebody has already answered it.";
		public static readonly string InvalidOperationAfterStartMessage
			= "You cannot update this poll, because it has already started.";
		public static readonly string PollNotFoundMessage
			= "The poll was not found.";
		public static readonly string InvalidCategoryIdMessage
			= "Category with given id doesn't exist.";
		public static readonly string NotAllowedOptionsCountMessage
			= "This poll contains an option question with less than two options. " +
			  "Question text: '{0}'; Question order: {1}.";
		public static readonly string NotAllowedRowsCountMessage
			= "This poll contains a row question with less than two rows. " +
			  "Question text: '{0}'; Question order: {1}.";
		public static readonly string NotAllowedLinearScaleWithoutValuesMessage
			= "This poll contains a linear scale question without values. " +
			  "Question text: '{0}'; Question order: {1}.";
		public static readonly string AnonymousPollMessage
			= "This function is forbidden for anonymous polls.";

		public static readonly string PollsToCompareNotFoundMessage
			= "Polls were not found.";

		//Option exception messages
		public static readonly string NotScaleTypeMessage
			= "Only questions of linear types can have values.";
		public static readonly string InvalidQuestionOptionTypeMessage
			= "Questions of such type cannot have options.";
		public static readonly string InvalidValueMessage
			= "The question already contains an option with given value.";
		public static readonly string InvalidOrderMessage
			= "The question already contains an option with given order.";
		public static readonly string InvalidVideoMessage
			= "Such video doesn't exist.";
		public static readonly string InvalidImageMessage
			= "Such image doesn't exist.";
		public static readonly string InvalidQuestionTypeMessage
			= "Such question type doesn't exist.";
		public static readonly string InvalidSectionMessage
			= "Such section doesn't exist.";
		public static readonly string InvalidOptionsToUpdateOrdersMessage
			= "Can`t update order of options from different questions.";
		public static readonly string NotFoundObjectMessage
			= "Object was not found.";
		public static readonly string OptionNotFoundMessage
			= "Option was not found.";
		public static readonly string QuestionContainsLessOrMoreOptions
			 = "You should update all options of one question.";
		public static readonly string UpdateNonexistentOptionMessage
			= "The option that you want to update doesn't exist.";

		//Row exception messages
		public static readonly string CreateRowWithNonexistentQuestionMessage
			= "The row cannot be added to a question that doesn't exist.";
		public static readonly string CreateRowToWrongQuestionTypeMessage
			= "Questions of such type cannot have rows.";
		public static readonly string CreateRowWithNonexistentImageMessage
			= "Such image doesn't exist.";
		public static readonly string CreateRowWithExistedOrderMessage
			= "Row with such order already exists.";
		public static readonly string UpdateNonexistentRowMessage
			= "The row that you want to update doesn't exist.";
		public static readonly string RowNotFoundMessage
			= "Row was not found.";
		public static readonly string InvalidRowsToUpdateOrdersMessage
			= "Can`t update order of rows from different questions.";
		public static readonly string QuestionContainsLessOrMoreRows
			 = "You should update all rows of one question.";

		//QuestionSection exception messages
		public static readonly string QuestionSectionNotFoundMessage
			= "The section was not found.";
		public static readonly string ExistingOrderForSectionMessage
			= "The section with such order already exists.";
		public static readonly string NotAllowedToDeleteSectionContainsQuestionsMessage
			= "The section can`t be deleted. It contains some questions.";
		public static readonly string NotAllowedToDeleteLastSectionMessage
			= "The section can`t be deleted. It is the last section in this poll.";
		public static readonly string NotAllowedToCreateAnswerBeforeStartDateMessage
			= "You can answer this poll until it starts.";
		public static readonly string NotAllowedToCreateOrChangeAnswerAfterFinishDateMessage
			= "The poll has already finished, you can`t answer on it anymore.";
		public static readonly string InvalidSectionsToUpdateOrdersMessage
			= "Can`t update order of sections from different polls.";
		public static readonly string PollContainsLessOrMoreSections
			 = "You should update all sections of one poll.";
		public static readonly string SectionsFromDifferentPolls
			 = "You can`t update sections from different polls.";

		// General exception messages
		public static readonly string IdDuplicatedMessage = "Can't contain duplicates of id.";
		public static readonly string OrderDuplicatedMessage = "Can't contain duplicates of order.";
	}
}

