using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Helpers
{
	/// <summary>
	/// Helper class that contains validation methods.
	/// </summary>
	public static class ValidationHelper
	{
		/// <summary>
		/// Validates object presence in the database.
		/// </summary>
		/// <param name="item">Object to validate.</param>
		/// <param name="errorMessage">Message if object doesn't exist in the database.</param>
		public static void ValidateDoesItemExist<T>(T item, string errorMessage) where T : class
		{
			if (item is null)
			{
				throw new NotFoundException(errorMessage);
			}
		}

		/// <summary>
		/// Validates date that has not passed.
		/// </summary>
		/// <param name="date">Date to validate.</param>
		/// <param name="errorMessage">Message if the date has passed.</param>
		public static void ValidateDateHasNotPassed(DateTimeOffset? date, string errorMessage)
		{
			if (date is null)
			{
				return;
			}
			if (DateTimeOffset.Now > date)
			{
				throw new NotAllowed(errorMessage);
			}
		}

		/// <summary>
		/// Validates collection of elements has duplicates.
		/// </summary>
		/// <param name="elements">Collection of nullable ints to validate.</param>
		/// <param name="errorMessage">Message if collection contains duplicates.</param>
		public static void ValidateContainsCollectionDuplicates<T>(IEnumerable<T> elements, string errorMessage)
		{
			var hasCollectionDuplicates = elements.GroupBy(number => number)
				.Any(group => group.Count() > 1 && !(group.Key is null));

			if (hasCollectionDuplicates)
			{
				throw new ArgumentException(errorMessage);
			}
		}

		/// <summary>
		/// Validates collections of elements are equal by count.
		/// </summary>
		/// <param name="firstList">Collection to validate.</param>
		/// <param name="secondList">Collection to validate.</param>
		/// <param name="errorMessage">Message if collections not equal.</param>
		public static void ValidateAreListsCountsEqual<T, S>(IEnumerable<T> firstList,
			IEnumerable<S> secondList, string errorMessage)
		{
			var areListsCountEqual = firstList.Count() == secondList.Count();

			if (!areListsCountEqual)
			{
				throw new ArgumentException(errorMessage);
			}
		}

		/// <summary>
		/// Validates question has not answered.
		/// </summary>
		/// <param name="question">Question to validate.</param>
		public static void ValidateQuestionHasNotAnswered(QuestionEntity question)
		{
			var questionHasAnswers = question.Answers.Any();

			if (questionHasAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.AnsweredQuestionMessage);
			}
		}

		/// <summary>
		/// Validates whether first date is earlier than second date.
		/// </summary>
		/// <param name="first">First date to validate.</param>
		/// <param name="second">Second date to validate.</param>
		/// <param name="errorMessage">Message if first date is later than second.</param>
		public static void ValidateFirstDateEarlierThanSecondDate(DateTimeOffset? first,
			DateTimeOffset? second, string errorMessage)
		{
			if (first != null && second != null && first > second)
			{
				throw new ArgumentException(errorMessage);
			}
		}

		/// <summary>
		/// Validates whether poll is anonymous.
		/// </summary>
		/// <param name="poll">Poll to validate.</param>
		/// <param name="errorMessage">Message if poll is anonymous.</param>
		public static void ValidateDoesPollAnonymous(PollEntity poll, string errorMessage)
		{
			if (poll.IsAnonymous)
			{
				throw new NotAllowed(errorMessage);
			}
		}

		/// <summary>
		/// Validates whether question has not answer.
		/// </summary>
		/// <param name="questionEntity">Question to check.</param>
		public static void ValidateQuestionHasNotAnswer(QuestionEntity questionEntity)
		{
			var questionHasAnswer = questionEntity.Answers.Any();

			if (questionHasAnswer)
			{
				throw new ArgumentException(ExceptionMessageConstants.AnsweredQuestionMessage);
			}
		}
	}
}
