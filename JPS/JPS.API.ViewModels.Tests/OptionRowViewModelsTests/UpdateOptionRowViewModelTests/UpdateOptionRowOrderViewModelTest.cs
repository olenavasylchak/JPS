using JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.OptionRowViewModelsTests.UpdateOptionRowViewModelTests
{
	[TestClass]
	public class UpdateOptionRowOrderViewModelTest
	{
		[TestMethod]
		public void TestUpdateOptionRowOrderViewModel_GivenValidValues_ShouldBePassed()
		{
			var updateRowOrderViewModel = GetUpdateOptionRowOrderViewModel();

			var result = Validator.TryValidateObject(
				updateRowOrderViewModel,
				new ValidationContext(updateRowOrderViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateOptionRowOrderViewModelIdData), DynamicDataSourceType.Method)]
		public void TestIdFails(
			string displayName,
			int id
		)
		{
			var updateOptionRowOrderViewModel = GetUpdateOptionRowOrderViewModel(id: id);

			var result = Validator.TryValidateObject(
				updateOptionRowOrderViewModel,
				new ValidationContext(updateOptionRowOrderViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateOptionRowOrderViewModelOrderData), DynamicDataSourceType.Method)]
		public void TestOrderFails(
			string displayName,
			int order
		)
		{
			var updateOptionRowOrderViewModel = GetUpdateOptionRowOrderViewModel(order: order);

			var result = Validator.TryValidateObject(
				updateOptionRowOrderViewModel,
				new ValidationContext(updateOptionRowOrderViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdateOptionRowOrderViewModelOrderData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateOptionRowViewModel_GivenNegativeOrderValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateOptionRowViewModel_GivenZeroOrderValue_ShouldBeFailed",
				0
			};
		}

		private static IEnumerable<object[]> GetTestUpdateOptionRowOrderViewModelIdData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateOptionRowViewModel_GivenNegativeIdValue_ShouldBeFailed",
				-1,
			};

			yield return new object[]
			{
				"Test case 2: UpdateOptionRowViewModel_GivenZeroIdValue_ShouldBeFailed",
				0,
			};
		}

		private static UpdateOptionRowOrderViewModel GetUpdateOptionRowOrderViewModel(
			int id = 1,
			int order = 1
			)
		{
			var UpdateOptionRowOrderModel = new UpdateOptionRowOrderViewModel
			{
				Id = id,
				Order = order
			};

			return UpdateOptionRowOrderModel;
		}
	}
}
