using JPS.API.ViewModels.ViewModels.CategoryViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.CategoryViewModelsTests.UpdateCategoryViewModelTests
{
    [TestClass]
    public class UpdateCategoryTitleViewModelTests
    {
		[TestMethod]
		public void TestUpdateCategory_TitleRequired_ShouldBeFailed()
		{
			var updateViewModel = GetUpdateCategoryViewModel(title: null);

			var result = Validator.TryValidateObject(
				updateViewModel,
				new ValidationContext(updateViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestUpdateCategory_TitleLength101_ShouldBeFailed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 101; i++)
			{
				text.Append("A");
			}

			var updateViewModel = GetUpdateCategoryViewModel(title: text.ToString());

			var result = Validator.TryValidateObject(
				updateViewModel,
				new ValidationContext(updateViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestUpdateCategory_TitleLength100_ShouldBePassed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 100; i++)
			{
				text.Append("A");
			}

			var updateViewModel = GetUpdateCategoryViewModel(title: text.ToString());

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

		private static UpdateCategoryTitleViewModel GetUpdateCategoryViewModel(
			string title = "test"
		)
		{
			var updateCategory = new UpdateCategoryTitleViewModel
			{
				Title = title
			};

			return updateCategory;
		}
	}
}
