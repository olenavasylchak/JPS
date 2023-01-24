using JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.OptionRowViewModelsTests.UpdateOptionRowViewModelTests
{
	[TestClass]
	public class UpdateOptionRowImageViewModelTest
	{
		[TestMethod]
		public void TestUpdateOptionRowImageViewModel_GivenValidValues_ShouldBePassed()
		{
			var updateRowImageViewModel = new UpdateOptionRowImageViewModel();
			updateRowImageViewModel.ImageUrl = "test.image/url";

			const string expectedImageUrl = "test.image/url";

			Assert.AreEqual(updateRowImageViewModel.ImageUrl, expectedImageUrl);
		}
	}
}
