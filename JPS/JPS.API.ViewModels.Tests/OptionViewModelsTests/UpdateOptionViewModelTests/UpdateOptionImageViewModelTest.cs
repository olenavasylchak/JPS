using JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.OptionViewModelsTests.UpdateOptionViewModelTests
{
	[TestClass]
	public class UpdateOptionImageViewModelTest
	{
		[TestMethod]
		public void TestUpdateOptionImageViewModel_GivenValidValues_ShouldBePassed()
		{
			var updateOptionImageViewModel = new UpdateOptionImageViewModel();
			updateOptionImageViewModel.ImageUrl = "test.image/url";

			const string expectedImageUrl = "test.image/url";

			Assert.AreEqual(updateOptionImageViewModel.ImageUrl, expectedImageUrl);
		}
	}
}
