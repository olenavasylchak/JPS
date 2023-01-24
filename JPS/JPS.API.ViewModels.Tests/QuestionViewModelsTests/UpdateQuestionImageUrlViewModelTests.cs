using System;
using System.Collections.Generic;
using System.Text;
using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionImageUrlViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionImageUrl()
		{
			var updateQuestionSectionDescriptionViewModel = new UpdateQuestionImageUrlViewModel
			{
				ImageUrl = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.ImageUrl, expected);
		}

		[TestMethod]
		public void TestSetNullQuestionImageUrl()
		{
			var updateQuestionSectionDescriptionViewModel = new UpdateQuestionImageUrlViewModel
			{
				ImageUrl = null
			};

			const string expected = null;

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.ImageUrl, expected);
		}
	}
}
