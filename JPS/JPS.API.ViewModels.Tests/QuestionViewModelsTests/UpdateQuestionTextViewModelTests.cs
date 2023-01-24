using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionTextViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionText()
		{
			var updateQuestionTextViewModel = new UpdateQuestionTextViewModel
			{
				Text = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(updateQuestionTextViewModel.Text, expected);
		}

		[TestMethod]
		public void TestUpdateQuestionText_TextIsRequired_ShouldBeFailed()
		{

			var updateQuestionTextViewModel = new UpdateQuestionTextViewModel
			{
				Text = null
			};

			var result = Validator.TryValidateObject(
				updateQuestionTextViewModel,
				new ValidationContext(updateQuestionTextViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}
	}
}
