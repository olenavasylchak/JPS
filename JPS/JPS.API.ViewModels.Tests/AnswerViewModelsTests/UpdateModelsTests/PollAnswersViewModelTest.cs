using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.UpdateAllAnswersInPollViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.UpdateModelsTests
{
	[TestClass]
	public class PollAnswersViewModelTest
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestPollAnswersViewModelData), DynamicDataSourceType.Method)]
		public void TestPollAnswers_QuestionId(string displayName, int questionId)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetPollAnswersViewModel(questionId: questionId);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestPollAnswersViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: PollAnswersViewModel_GivenNegativeQuestionId_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: PollAnswersViewModel_GivenZeroQuestionId_ShouldBeFailed",
				0
			};
		}

		private static PollAnswersViewModel GetPollAnswersViewModel(int questionId = 1)
		{
			var createPollAnswersModel = new PollAnswersViewModel
			{
				QuestionId = questionId
			};

			return createPollAnswersModel;
		}
	}
}
