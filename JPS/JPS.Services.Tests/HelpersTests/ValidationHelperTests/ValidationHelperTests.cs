using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;
using JPS.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JPS.Services.Tests.HelpersTests.ValidationHelperTests
{
	[TestClass]
	public class ValidationHelperTests
	{
		[TestMethod]
		public void ValidateDateHasNotPassed_GivenPassedDate_ShouldThrowNotAllowedException()
		{
			var date = new DateTimeOffset(2000, 1, 1, 0, 0, 0, new TimeSpan());

			Assert.ThrowsException<NotAllowed>(() =>
				ValidationHelper.ValidateDateHasNotPassed(date, "Error"));
		}

		[TestMethod]
		public void ValidateDateHasNotPassed_GivenNotPassedDate_ShouldBePassed()
		{
			var date = new DateTimeOffset(2050, 1, 1, 0, 0, 0, new TimeSpan());

			Exception expectedException = null;

			try
			{
				ValidationHelper.ValidateDateHasNotPassed(date, "Error");
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateDoesItemExist_GivenNull_ShouldThrowNotFoundException()
		{
			string myObjext = null;

			Assert.ThrowsException<NotFoundException>(() =>
				ValidationHelper.ValidateDoesItemExist(myObjext, "Error"));
		}

		[TestMethod]
		public void ValidateDoesItemExist_GivenNotNull_ShouldBePassed()
		{
			string myObjext = "test";

			Exception expectedException = null;

			try
			{
				ValidationHelper.ValidateDoesItemExist(myObjext, "Error");
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateContainsCollectionDuplicates_GivenDuplicates_ShouldThrowArgumentException()
		{
			var list = new List<int> { 1, 2, 4, 5, 2 };

			Assert.ThrowsException<ArgumentException>(() =>
				ValidationHelper.ValidateContainsCollectionDuplicates(list, "Error"));
		}

		[TestMethod]
		public void ValidateContainsCollectionDuplicates_GivenNotDuplicatedList_ShouldBePassed()
		{
			var list = new List<int> { 1, 2, 4, 5, 3 };
			Exception expectedException = null;

			try
			{
				ValidationHelper.ValidateContainsCollectionDuplicates(list, "Error");
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateAreListsCountsEqual_GivenNotCountEqualLists_ShouldThrowArgumentException()
		{
			var list1 = new List<int> { 1, 2, 4, 5, 2 };
			var list2 = new List<int> { 1, 2, 4, 5, 2, 3 };

			Assert.ThrowsException<ArgumentException>(() =>
				ValidationHelper.ValidateAreListsCountsEqual(list1, list2, "Error"));
		}

		[TestMethod]
		public void ValidateAreListsCountsEqual_GivenCountEqualLists_ShouldBePassed()
		{
			var list1 = new List<int> { 1, 2, 4, 5, 2 };
			var list2 = new List<int> { 1, 2, 4, 5, 2 };
			Exception expectedException = null;

			try
			{
				ValidationHelper.ValidateAreListsCountsEqual(list1, list2, "Error");
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateQuestionHasNotAnswered_GivenAnsweredQuestion_ShouldThrowArgumentException()
		{
			var question = new QuestionEntity { Answers = new List<AnswerEntity> { new AnswerEntity { Id = 1 } } };

			Assert.ThrowsException<ArgumentException>(() =>
				ValidationHelper.ValidateQuestionHasNotAnswered(question));
		}

		[TestMethod]
		public void ValidateQuestionHasNotAnswered_GivenNotAnsweredQuestion_ShouldBePassed()
		{
			var question = new QuestionEntity { Answers = new List<AnswerEntity> { } };
			Exception expectedException = null;

			try
			{
				ValidationHelper.ValidateQuestionHasNotAnswered(question);
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateFirstDateEarlierThanSecondDate_GivenSecondDateErlierThanFirst_ShouldThrowArgumentException()
		{
			var dateFirst = new DateTimeOffset(2050, 1, 1, 0, 0, 0, new TimeSpan());
			var dateSecond = new DateTimeOffset(2049, 1, 1, 0, 0, 0, new TimeSpan());

			Assert.ThrowsException<ArgumentException>(() =>
				ValidationHelper.ValidateFirstDateEarlierThanSecondDate(dateFirst, dateSecond, "Error"));
		}

		[TestMethod]
		public void ValidateFirstDateEarlierThanSecondDate_GivenFirstDateErlierThansecond_ShouldBePassed()
		{
			var dateFirst = new DateTimeOffset(2050, 1, 1, 0, 0, 0, new TimeSpan());
			var dateSecond = new DateTimeOffset(2051, 1, 1, 0, 0, 0, new TimeSpan());

			Exception expectedException = null;

			try
			{
				ValidationHelper.ValidateFirstDateEarlierThanSecondDate(dateFirst, dateSecond, "Error");
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}

		[TestMethod]
		public void ValidateDoesPollAnonymous_GivenAnonymousPoll_ShouldThrowNotAllowedException()
		{
			var poll = new PollEntity();
			poll.IsAnonymous = true;

			Assert.ThrowsException<NotAllowed>(() =>
				ValidationHelper.ValidateDoesPollAnonymous(poll, "Error"));
		}

		[TestMethod]
		public void ValidateDoesPollAnonymous_GivenNotAnonymousPoll_ShouldBePassed()
		{
			var poll = new PollEntity();
			poll.IsAnonymous = false;

			Exception expectedException = null;

			try
			{
				ValidationHelper.ValidateDoesPollAnonymous(poll, "Error");
			}
			catch (Exception exception)
			{
				expectedException = exception;
			}
			finally
			{
				Assert.IsNull(expectedException);
			}
		}
	}
}