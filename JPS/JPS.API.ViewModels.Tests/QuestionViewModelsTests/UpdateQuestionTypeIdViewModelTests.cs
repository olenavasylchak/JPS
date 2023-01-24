using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionTypeIdViewModelTests
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateQuestionTypeIdForQuestionViewModelShouldBePassedData), DynamicDataSourceType.Method)]
		public void TestUpdateQuestion_QuestionTypeId_ShouldBePassed(string displayName, int questionTypeId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = new UpdateQuestionTypeIdViewModel
			{
				QuestionTypeId = questionTypeId
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestSetQuestionOrder()
		{
			var updateQuestionTypeIdViewModel = new UpdateQuestionTypeIdViewModel
			{
				QuestionTypeId = 1
			};

			const int expected = 1;

			Assert.AreEqual(updateQuestionTypeIdViewModel.QuestionTypeId, expected);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateQuestionTypeIdForQuestionViewModelShouldBeFailedData), DynamicDataSourceType.Method)]
		public void TestUpdateQuestion_QuestionTypeId_ShouldBeFailed(string displayName, int questionTypeId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = new UpdateQuestionTypeIdViewModel
			{
				QuestionTypeId = questionTypeId
			};
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdateQuestionTypeIdForQuestionViewModelShouldBePassedData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateQuestionTypeIdForQuestionViewModel_Given_positive_questionTypeID_value_Should_be_failed",
				1
			};

			yield return new object[]
			{
				"Test case 2: UpdateQuestionTypeIdForQuestionViewModel_Given_less_than_12_questionTypeID_value_Should_be_failed",
				11
			};
		}

		private static IEnumerable<object[]> GetTestUpdateQuestionTypeIdForQuestionViewModelShouldBeFailedData()
		{
			yield return new object[]
			{
				"Test case 1: CreateQuestionTypeIdForQuestionViewModel_Given_negative_questionTypeID_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 1: UpdateQuestionTypeIdForQuestionViewModel_Given_zero_questionTypeID_value_Should_be_failed",
				0
			};

			yield return new object[]
			{
				"Test case 2: UpdateQuestionTypeIdForQuestionViewModel_Given_above_11_questionTypeID_value_Should_be_failed",
				12
			};
		}
	}
}
