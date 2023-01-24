using JPS.API.ViewModels.ViewModels.PollViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.PollViewModelsTests.UpdatePollViewModelsTests
{
	[TestClass]
	public class UpdatePollIsAnonymousViewModelTests
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdatePollIsAnonymousViewModelData), DynamicDataSourceType.Method)]
		public void TestIsAnonymousPasses(
			string displayName,
			bool isAnonymous)
		{

			var updatePollCategoryIdViewModel = GetUpdatePollIsAnonymousViewModel(isAnonymous);

			var result = Validator.TryValidateObject(
				updatePollCategoryIdViewModel,
				new ValidationContext(updatePollCategoryIdViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		private static IEnumerable<object[]> GetTestUpdatePollIsAnonymousViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: UpdatePollIsAnonymousViewModel_GivenTrueIsAnonymousValue_ShouldBePassed",
				false
			};

			yield return new object[]
			{
				"Test case 2: UpdatePollIsAnonymousViewModel_GivenFalseIsAnonymousValue_ShouldBePassed",
				true
			};
		}

		private static UpdatePollIsAnonymousViewModel GetUpdatePollIsAnonymousViewModel(bool isAnonymous)
		{
			var updatePollIsAnonymousViewModel = new UpdatePollIsAnonymousViewModel
			{
				IsAnonymous = isAnonymous
			};

			return updatePollIsAnonymousViewModel;
		}
	}
}
