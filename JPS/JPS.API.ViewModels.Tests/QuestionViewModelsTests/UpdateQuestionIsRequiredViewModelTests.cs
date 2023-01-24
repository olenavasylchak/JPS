using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionIsRequiredViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionIsRequired()
		{
			var updateQuestionIsRequiredViewModel = new UpdateQuestionIsRequiredViewModel
			{
				IsRequired = true
			};

			const bool expected = true;

			Assert.AreEqual(updateQuestionIsRequiredViewModel.IsRequired, expected);
		}
	}
}
