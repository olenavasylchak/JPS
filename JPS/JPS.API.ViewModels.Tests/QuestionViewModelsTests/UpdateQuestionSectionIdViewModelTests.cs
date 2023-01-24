using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionSectionIdViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionOrder ()
		{
			var updateQuestionSectionIdViewModel = new UpdateQuestionSectionIdViewModel
			{
				QuestionSectionId = 1
			};

			const int expected = 1;

			Assert.AreEqual(updateQuestionSectionIdViewModel.QuestionSectionId, expected);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateQuestionSectionIdForQuestionViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateQuestion_OrderIsNegativeOrZero (string displayName, int questionSectionId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var updateQuestionSectionIdViewModel = new UpdateQuestionSectionIdViewModel
			{
				QuestionSectionId = questionSectionId
			};
			var result = Validator.TryValidateObject(
				updateQuestionSectionIdViewModel,
				new ValidationContext(updateQuestionSectionIdViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdateQuestionSectionIdForQuestionViewModelData ()
		{
			yield return new object[]
			{
				"Test case 1: UpdateSectionIdForQuestionViewModel_Given_negative_sectionId_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateSectionIdForQuestionViewModel_Given_zero_sectionId_value_Should_be_failed",
				0
			};
		}
	}
}
