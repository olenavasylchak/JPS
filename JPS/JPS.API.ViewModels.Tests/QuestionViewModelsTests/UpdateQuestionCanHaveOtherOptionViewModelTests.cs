using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionCanHaveOtherOptionViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionCanHaveOtherOption()
		{
			var updateQuestionCanHaveOtherOptionViewModel = new UpdateQuestionCanHaveOtherOptionViewModel
			{
				CanHaveOtherOption = true
			};

			const bool expected = true;

			Assert.AreEqual(updateQuestionCanHaveOtherOptionViewModel.CanHaveOtherOption, expected);
		}
	}
}
