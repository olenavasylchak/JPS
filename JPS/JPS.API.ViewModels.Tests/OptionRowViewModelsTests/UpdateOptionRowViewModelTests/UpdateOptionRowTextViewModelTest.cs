using JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.OptionRowViewModelsTests.UpdateOptionRowViewModelTests
{
	[TestClass]
	public class UpdateOptionRowTextViewModelTest
	{
		[TestMethod]
		public void TestText_GivenNormal_ShouldBePassed()
		{
			var updateOptionRowTextViewModel = GetUpdateOptionRowTextViewModel();

			var result = Validator.TryValidateObject(
				updateOptionRowTextViewModel,
				new ValidationContext(updateOptionRowTextViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestText_GivenLengthMoreThan100Symbols_ShouldBeFailed()
		{
			var textWithLengthMoreThan100 =
				"pass me completely pass me completely pass me completely pass me completely pass me completely pass me completely";
			var updateOptionRowTextViewModel = GetUpdateOptionRowTextViewModel(textWithLengthMoreThan100);

			var result = Validator.TryValidateObject(
				updateOptionRowTextViewModel,
				new ValidationContext(updateOptionRowTextViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestText_GivenLength100Symbols_ShouldBePassed()
		{
			var textWithLength100 =
				"pass me completely pass me completely pass me completely pass me completely pass me completely pass ";
			var updateOptionRowTextViewModel = GetUpdateOptionRowTextViewModel(textWithLength100);

			var result = Validator.TryValidateObject(
				updateOptionRowTextViewModel,
				new ValidationContext(updateOptionRowTextViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		private static UpdateOptionRowTextViewModel GetUpdateOptionRowTextViewModel(
			string text = "test"
       )
		{
			var updateRowTextViewModel = new UpdateOptionRowTextViewModel
			{
				Text = text
			};

			return updateRowTextViewModel;
		}
	}
}
