using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.CreateModelsTests
{
	[TestClass]
	public class CreateOptionAnswerViewModelTest
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOptionAnswerViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateOptionAnswer_TestOptionId(string displayName, int optionId)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createOptionAnswerViewModel = GetCreateOptionAnswerViewModel(optionId: optionId);

			var result = Validator.TryValidateObject(
				createOptionAnswerViewModel,
				new ValidationContext(createOptionAnswerViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateOptionAnswerViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionAnswerViewModel_GivenNegativeOptionId_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionAnswerViewModel_GivenZeroOptionId_ShouldBeFailed",
				0
			};
		}

		private static CreateOptionAnswerViewModel GetCreateOptionAnswerViewModel(int optionId = 1)
		{
			var createOptionAnswerModel = new CreateOptionAnswerViewModel
			{
				OptionId = optionId
			};

			return createOptionAnswerModel;
		}
	}
}
