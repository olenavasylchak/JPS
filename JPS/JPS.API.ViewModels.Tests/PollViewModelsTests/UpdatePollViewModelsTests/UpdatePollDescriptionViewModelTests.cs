using JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.PollViewModelsTests.UpdatePollViewModelsTests
{
	[TestClass]
	public class UpdatePollDescriptionViewModelTests
	{
		[TestMethod]
		public void TestDescription_GivenNormalString_ShouldBePassed()
		{
			var updatePollDescriptionViewModel = new UpdatePollDescriptionViewModel();
			updatePollDescriptionViewModel.Description = "test description";

			const string expectedDescription = "test description";

			Assert.AreEqual(updatePollDescriptionViewModel.Description, expectedDescription);
		}
	}
}

