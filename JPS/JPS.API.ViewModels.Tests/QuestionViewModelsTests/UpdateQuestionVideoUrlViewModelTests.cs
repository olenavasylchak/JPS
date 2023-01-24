using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionVideoUrlViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionVideoUrl()
		{
			var updateQuestionVideoUrlViewModel = new UpdateQuestionVideoUrlViewModel
			{
				VideoUrl = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(updateQuestionVideoUrlViewModel.VideoUrl, expected);
		}

		[TestMethod]
		public void TestSetNullQuestionVideoUrl()
		{
			var updateQuestionVideoUrlViewModel = new UpdateQuestionVideoUrlViewModel
			{
				VideoUrl = null
			};

			const string expected = null;

			Assert.AreEqual(updateQuestionVideoUrlViewModel.VideoUrl, expected);
		}
	}
}
