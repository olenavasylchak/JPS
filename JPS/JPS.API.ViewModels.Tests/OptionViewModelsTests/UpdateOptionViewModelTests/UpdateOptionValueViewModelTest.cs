using JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.OptionViewModelsTests.UpdateOptionViewModelTests
{
	[TestClass]
	public class UpdateOptionValueViewModelTest
	{
		[TestMethod]
		public void TestValue_GivenValidValue_ShouldBePassed()
		{
			var updateOptionValueViewModel = GetUpdateOptionValueViewModel();

			var result = Validator.TryValidateObject(
				updateOptionValueViewModel,
				new ValidationContext(updateOptionValueViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestValue_GivenPositiveValue_ShouldBePassed()
		{
			var updateOptionValueViewModel = GetUpdateOptionValueViewModel();
			updateOptionValueViewModel.Value = 5;

			var result = Validator.TryValidateObject(
				updateOptionValueViewModel,
				new ValidationContext(updateOptionValueViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestValue_GivenNegativeValue_ShouldBePassed()
		{
			var updateOptionValueViewModel = GetUpdateOptionValueViewModel();
			updateOptionValueViewModel.Value = -100;

			var result = Validator.TryValidateObject(
				updateOptionValueViewModel,
				new ValidationContext(updateOptionValueViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestValue_GivenNull_ShouldBePassed()
		{
			var updateOptionValueViewModel = GetUpdateOptionValueViewModel();
			updateOptionValueViewModel.Value = null;

			var result = Validator.TryValidateObject(
				updateOptionValueViewModel,
				new ValidationContext(updateOptionValueViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		private static UpdateOptionValueViewModel GetUpdateOptionValueViewModel(
			decimal value = 1
			)
		{
			var updateOptionValueModel = new UpdateOptionValueViewModel
			{
				Value = value
			};

			return updateOptionValueModel;
		}
	}
}
