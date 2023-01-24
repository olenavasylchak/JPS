using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.QuestionSectionViewModelsTests.UpdateQuestionSectionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionSectionDescriptionViewModelTests
	{
		[TestMethod]
		public void TestDescription_GivenNormalValue_ShouldBePassed()
		{
			var updateQuestionSectionDescriptionViewModel = new UpdateQuestionSectionDescriptionViewModel();
			updateQuestionSectionDescriptionViewModel.Description = "test description";

			const string expectedDescription = "test description";

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.Description, expectedDescription);
		}
	}
}
