using JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.OptionViewModelsTests.UpdateOptionViewModelTests
{
	[TestClass]
	public class UpdateOptionTextViewModelTest
	{
		[TestMethod]
		public void TestText_GivenNormal_ShouldBePassed()
		{
			var updateOptionTextViewModel = GetUpdateOptionTextViewModel();

			var result = Validator.TryValidateObject(
				updateOptionTextViewModel,
				new ValidationContext(updateOptionTextViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestText_GivenLengthMoreThan100Symbols_ShouldBeFailed()
		{
			var textWithLengthMoreThan100 =
				"pass me completely pass me completely pass me completely pass me completely pass me completely pass me completely";
			var updateOptionTextViewModel = GetUpdateOptionTextViewModel(textWithLengthMoreThan100);

			var result = Validator.TryValidateObject(
				updateOptionTextViewModel,
				new ValidationContext(updateOptionTextViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestText_GivenLength100Symbols_ShouldBePassed()
		{
			var textWithLength100 =
				"pass me completely pass me completely pass me completely pass me completely pass me completely pass ";
			var updateOptionTextViewModel = GetUpdateOptionTextViewModel(textWithLength100);

			var result = Validator.TryValidateObject(
				updateOptionTextViewModel,
				new ValidationContext(updateOptionTextViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		private static UpdateOptionTextViewModel GetUpdateOptionTextViewModel(
			string text = "test"
	   )
		{
			var updateOptionTextViewModel = new UpdateOptionTextViewModel
			{
				Text = text
			};

			return updateOptionTextViewModel;
		}
	}
}
