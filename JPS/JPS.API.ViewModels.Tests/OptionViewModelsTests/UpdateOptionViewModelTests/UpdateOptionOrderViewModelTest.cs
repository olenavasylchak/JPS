using JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.OptionViewModelsTests.UpdateOptionViewModelTests
{
	[TestClass]
	public class UpdateOptionOrderViewModelTest
	{
		[TestMethod]
		public void TestOrder_GivenValidValues_ShouldBePassed()
		{
			var updateOptionOrderViewModel = GetUpdateOptionOrderViewModel();

			var result = Validator.TryValidateObject(
				updateOptionOrderViewModel,
				new ValidationContext(updateOptionOrderViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateOptionOrderViewModelIdData), DynamicDataSourceType.Method)]
		public void TestIdFails(
			string displayName,
			int id
		)
		{
			var updateOptionOrderViewModel = GetUpdateOptionOrderViewModel(id: id);

			var result = Validator.TryValidateObject(
				updateOptionOrderViewModel,
				new ValidationContext(updateOptionOrderViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateOptionOrderViewModelOrderData), DynamicDataSourceType.Method)]
		public void TestOrderFails(
			string displayName,
			int order
		)
		{
			var updateOptionOrderViewModel = GetUpdateOptionOrderViewModel(order: order);

			var result = Validator.TryValidateObject(
				updateOptionOrderViewModel,
				new ValidationContext(updateOptionOrderViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdateOptionOrderViewModelOrderData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateOptionViewModel_GivenNegativeOrderValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateOptionViewModel_GivenZeroOrderValue_ShouldBeFailed",
				0
			};
		}

		private static IEnumerable<object[]> GetTestUpdateOptionOrderViewModelIdData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateOptionViewModel_GivenNegativeIdValue_ShouldBeFailed",
				-1,
			};

			yield return new object[]
			{
				"Test case 2: UpdateOptionViewModel_GivenZeroIdValue_ShouldBeFailed",
				0,
			};
		}

		private static UpdateOptionOrderViewModel GetUpdateOptionOrderViewModel(
			int id = 1,
			int order = 1
			)
		{
			var updateOptionOrderModel = new UpdateOptionOrderViewModel
			{
				Id = id,
				Order = order
			};

			return updateOptionOrderModel;
		}
	}
}
