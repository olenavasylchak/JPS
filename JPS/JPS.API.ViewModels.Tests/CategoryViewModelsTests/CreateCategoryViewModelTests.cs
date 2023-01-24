using JPS.API.ViewModels.ViewModels.CategoryViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.CategoryViewModelsTests
{
    [TestClass]
    public class CreateCategoryViewModelTests
    {
		[TestMethod]
		public void TestCreateCategory_TitleRequired_ShouldBeFailed()
		{
			var createViewModel = GetCreateCategoryViewModel(title: null);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateCategory_TitleLength101_ShouldBeFailed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 101; i++)
			{
				text.Append("A");
			}

			var createViewModel = GetCreateCategoryViewModel(title: text.ToString());

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateCategory_TitleLength100_ShouldBePassed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 100; i++)
			{
				text.Append("A");
			}

			var createViewModel = GetCreateCategoryViewModel(title: text.ToString());

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCreateCategory_ParentCategoryIdNull_ShouldBePassed()
		{
			var createViewModel = GetCreateCategoryViewModel(parentCategoryId: null);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestParentCategoryId()
		{
			var createCategoryViewModel = new CreateCategoryViewModel();
			createCategoryViewModel.ParentCategoryId = 1;

			int? expected = 1;

			Assert.AreEqual(createCategoryViewModel.ParentCategoryId, expected);
		}

        [DataTestMethod]
		[DynamicData(nameof(GetTestCreateParentCategoryIdForCategoryViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateCategory_ParentCategoryId(string displayName, int parentCategoryategoryId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateCategoryViewModel(parentCategoryId: parentCategoryategoryId);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

			[TestMethod]
		public void TestCreateCategory_Valid_ShouldBePassed()
		{
			var createViewModel = GetCreateCategoryViewModel();
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}

		private static IEnumerable<object[]> GetTestCreateParentCategoryIdForCategoryViewModelData()
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
		private static CreateCategoryViewModel GetCreateCategoryViewModel(
			string title = "test",
			int? parentCategoryId = 1
		)
		{
			var createCategory = new CreateCategoryViewModel
			{
				Title = title,
				ParentCategoryId = parentCategoryId
			};

			return createCategory;
		}
	}
}
