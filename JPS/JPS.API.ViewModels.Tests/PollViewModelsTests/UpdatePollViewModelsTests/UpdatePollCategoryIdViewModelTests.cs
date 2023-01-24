using JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.PollViewModelsTests.UpdatePollViewModelsTests
{
	[TestClass]
	public class UpdatePollCategoryIdViewModelTests
	{
		[TestMethod]
		public void TestCategoryId_GivenNormalValue_ShouldBePassed()
		{
			var updatePollCategoryIdViewModel = GetUpdatePollCategoryIdViewModel();

			var result = Validator.TryValidateObject(
				updatePollCategoryIdViewModel,
				new ValidationContext(updatePollCategoryIdViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdatePollCategoryIdViewModelData), DynamicDataSourceType.Method)]
		public void TestCategoryIdFails(
			string displayName,
			int categoryId)
		{

			var updatePollCategoryIdViewModel = GetUpdatePollCategoryIdViewModel(categoryId);

			var result = Validator.TryValidateObject(
				updatePollCategoryIdViewModel,
				new ValidationContext(updatePollCategoryIdViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdatePollCategoryIdViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: UpdatePollCategoryIdViewModel_GivenNegativeCategoryIdValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdatePollCategoryIdViewModel_GivenZeroCategoryIdValue_ShouldBeFailed",
				0
			};
		}

		private static UpdatePollCategoryIdViewModel GetUpdatePollCategoryIdViewModel(int categoryId = 1)
		{
			var updatePollCategoryIdViewModel = new UpdatePollCategoryIdViewModel
			{
				CategoryId = categoryId
			};

			return updatePollCategoryIdViewModel;
		}
	}
}

