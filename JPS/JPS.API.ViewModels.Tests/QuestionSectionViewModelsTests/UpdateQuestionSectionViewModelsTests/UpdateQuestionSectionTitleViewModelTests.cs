using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.QuestionSectionViewModelsTests.UpdateQuestionSectionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionSectionTitleViewModelTests
	{
		[TestMethod]
		public void TestTitle_GivenLengthMoreThan100Symbols_ShouldBeFailed()
		{
			var titleWithLengthMoreThan100 =
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat";
			var updateQuestionSectionTitleViewModel = GetUpdateQuestionSectionTitleViewModel(titleWithLengthMoreThan100);

			var result = Validator.TryValidateObject(
				updateQuestionSectionTitleViewModel,
				new ValidationContext(updateQuestionSectionTitleViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestTitle_GivenLength100Symbols_ShouldBePassed()
		{
			var titleWithLength100 =
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts ea";
			var updateQuestionSectionTitleViewModel = GetUpdateQuestionSectionTitleViewModel(titleWithLength100);

			var result = Validator.TryValidateObject(
				updateQuestionSectionTitleViewModel,
				new ValidationContext(updateQuestionSectionTitleViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestTitle_GivenNormal_ShouldBePassed()
		{
			var updateQuestionSectionTitleViewModel = GetUpdateQuestionSectionTitleViewModel();

			var result = Validator.TryValidateObject(
				updateQuestionSectionTitleViewModel,
				new ValidationContext(updateQuestionSectionTitleViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		private static UpdateQuestionSectionTitleViewModel GetUpdateQuestionSectionTitleViewModel(
			string title = "test"
		)
		{
			var updateQuestionSectionTitleViewModel = new UpdateQuestionSectionTitleViewModel
			{
				Title = title
			};

			return updateQuestionSectionTitleViewModel;
		}
	}
}
