using JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.PollViewModelsTests.UpdatePollViewModelsTests
{
	[TestClass]
	public class UpdatePollTitleViewModelTests
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdatePollTitleViewModelData), DynamicDataSourceType.Method)]
		public void TestCategoryIdFails(
			string displayName,
			string title)
		{
			var updatePollTitleViewModel = GetUpdatePollTitleViewModel(title);

			var result = Validator.TryValidateObject(
				updatePollTitleViewModel,
				new ValidationContext(updatePollTitleViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdatePollTitleViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: UpdatePollTitleViewModel_GivenTitleLengthMoreThan100Value_ShouldBeFailed",
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat"
		};

			yield return new object[]
			{
				"Test case 1: UpdatePollTitleViewModel_GivenNullTitleValue_ShouldBeFailed",
				null
			};
		}

		[TestMethod]
		public void TestTitle_GivenMaximumAllowableLength_ShouldBePassed()
		{
			var titleWithLength100 =
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts ea";
			var updatePollTitleViewModel = GetUpdatePollTitleViewModel(titleWithLength100);

			var result = Validator.TryValidateObject(
				updatePollTitleViewModel,
				new ValidationContext(updatePollTitleViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestTitle_GivenNormalLength_ShouldBePassed()
		{
			var updatePollTitleViewModel = GetUpdatePollTitleViewModel();

			var result = Validator.TryValidateObject(
				updatePollTitleViewModel,
				new ValidationContext(updatePollTitleViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		private static UpdatePollTitleViewModel GetUpdatePollTitleViewModel(string title = "test")
		{
			var updatePollTitleViewModel = new UpdatePollTitleViewModel
			{
				Title = title
			};

			return updatePollTitleViewModel;
		}
	}
}

