using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.CreateModelsTests
{
	[TestClass]
	public class CreateGridOptionAnswerViewModelTest
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateGridOptionAnswerViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateGridOptionAnswer_TestOptionId(string displayName, int optionId)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateGridOptionAnswerViewModel(optionId: optionId);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateGridOptionAnswerViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateGridOptionAnswer_TestOptionRowId(string displayName, int optionRowId)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateGridOptionAnswerViewModel(optionRowId: optionRowId);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateGridOptionAnswerViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionAnswerViewModel_GivenNegativeId_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionAnswerViewModel_GivenZeroId_ShouldBeFailed",
				0
			};
		}

		private static CreateGridOptionAnswerViewModel GetCreateGridOptionAnswerViewModel(int optionId = 1, int? optionRowId = 1)
		{
			var createOptionAnswerModel = new CreateGridOptionAnswerViewModel
			{
				OptionId = optionId,
				OptionRowId = optionRowId
			};

			return createOptionAnswerModel;
		}
	}
}
