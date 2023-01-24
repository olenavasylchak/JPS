using JPS.API.ViewModels.ViewModels.CategoryViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.CategoryViewModelsTests.UpdateCategoryViewModelTests
{
    [TestClass]
    public class UpdateCategoryParentViewModelTests
    {
		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdadeParentCategoryIdForCategoryViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateCategory_ParentCategoryId(string displayName, int parentCategoryategoryId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var updateViewModel = GetUpdateCategoryViewModel(parentCategoryId: parentCategoryategoryId);
			var result = Validator.TryValidateObject(
				updateViewModel,
				new ValidationContext(updateViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestParentCategoryId()
		{
			var updateCategoryViewModel = new UpdateCategoryParentViewModel();
			updateCategoryViewModel.ParentCategoryId = 1;

			int? expected = 1;

			Assert.AreEqual(updateCategoryViewModel.ParentCategoryId, expected);
		}

		[TestMethod]
		public void TestUpdateCategory_ParentCategoryIdNull_ShouldBePassed()
		{
			var updateViewModel = GetUpdateCategoryViewModel(parentCategoryId: null);

			var result = Validator.TryValidateObject(
				updateViewModel,
				new ValidationContext(updateViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestUpdateCategory_Valid_ShouldBePassed()
		{
			var updateViewModel = GetUpdateCategoryViewModel();
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(updateViewModel, new ValidationContext(updateViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}
		private static IEnumerable<object[]> GetTestUpdadeParentCategoryIdForCategoryViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CreateCategoryViewModel_Given_negative_parentCategoryId_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateCategoryViewModel_Given_zero_parentCategoryId_value_Should_be_failed",
				0
			};
		}

		private static UpdateCategoryParentViewModel GetUpdateCategoryViewModel(
			int? parentCategoryId = 1
		)
		{
			var updateCategory = new UpdateCategoryParentViewModel
			{
				ParentCategoryId = parentCategoryId
			};

			return updateCategory;
		}
	}
}
