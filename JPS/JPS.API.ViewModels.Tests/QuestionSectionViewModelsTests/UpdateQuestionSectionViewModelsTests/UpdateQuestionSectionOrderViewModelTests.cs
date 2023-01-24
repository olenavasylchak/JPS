using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.QuestionSectionViewModelsTests.UpdateQuestionSectionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionSectionOrderViewModelTests
	{
		[TestMethod]
		public void TestUpdateQuestionSectionOrderViewModel_GivenValidValues_ShouldBePassed()
		{
			var updateQuestionSectionOrderViewModel = GetUpdateQuestionSectionOrderViewModel();

			var result = Validator.TryValidateObject(
				updateQuestionSectionOrderViewModel,
				new ValidationContext(updateQuestionSectionOrderViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateQuestionSectionOrderViewModelIdData), DynamicDataSourceType.Method)]
		public void TestIdFails(
			string displayName,
			int id
		)
		{
			var updateQuestionSectionOrderViewModel = GetUpdateQuestionSectionOrderViewModel(id: id);

			var result = Validator.TryValidateObject(
				updateQuestionSectionOrderViewModel,
				new ValidationContext(updateQuestionSectionOrderViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateQuestionSectionOrderViewModelOrderData), DynamicDataSourceType.Method)]
		public void TestOrderFails(
			string displayName,
			int order
		)
		{
			var updateQuestionSectionOrderViewModel = GetUpdateQuestionSectionOrderViewModel(order: order);

			var result = Validator.TryValidateObject(
				updateQuestionSectionOrderViewModel,
				new ValidationContext(updateQuestionSectionOrderViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdateQuestionSectionOrderViewModelOrderData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateQuestionSectionViewModel_GivenNegativeOrderValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateQuestionSectionViewModel_GivenZeroOrderValue_ShouldBeFailed",
				0
			};
		}

		private static IEnumerable<object[]> GetTestUpdateQuestionSectionOrderViewModelIdData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateQuestionSectionViewModel_GivenNegativeIdValue_ShouldBeFailed",
				-1,
			};

			yield return new object[]
			{
				"Test case 2: UpdateQuestionSectionViewModel_GivenZeroIdValue_ShouldBeFailed",
				0,
			};
		}

		private static UpdateQuestionSectionOrderViewModel GetUpdateQuestionSectionOrderViewModel(
			int id = 1,
			int order = 1
		)
		{
			var updateQuestionSectionOrderViewModel = new UpdateQuestionSectionOrderViewModel
			{
				Id = id,
				Order = order
			};

			return updateQuestionSectionOrderViewModel;
		}
	}
}
