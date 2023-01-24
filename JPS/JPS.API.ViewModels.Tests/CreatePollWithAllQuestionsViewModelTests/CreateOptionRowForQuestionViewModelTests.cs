using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests
{
	[TestClass]
	public class CreateOptionRowForQuestionViewModelTest
	{
		[TestMethod]
		public void TestOptionRow_OrderRequired_ShouldBeFailed()
		{
			var createOptionRowModel = new CreateOptionRowForQuestionViewModel
			{
				Text = "Test",
				ImageUrl = "Test",

			};

			var result = Validator.TryValidateObject(
				createOptionRowModel,
				new ValidationContext(createOptionRowModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOrderForRowViewModelData), DynamicDataSourceType.Method)]
		public void TestOptionRow_OrderIsNegativeOrZero(string displayName, int order)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateOptionRowViewModel(order: order);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestOptionRow_TextLength101_ShouldBeFailed()
		{
			var text = new StringBuilder(string.Empty);
			for (int i = 0; i < 101; i++)
			{
				text.Append("A");
			}
			var createViewModel = GetCreateOptionRowViewModel(text: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestOptionRow_TextLength100_ShouldBeFailed()
		{
			var text = new StringBuilder(string.Empty);
			for (int i = 0; i < 100; i++)
			{
				text.Append("A");
			}
			var createViewModel = GetCreateOptionRowViewModel(text: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCreateOptionRow_Valid_ShouldBePassed()
		{
			var createViewModel = GetCreateOptionRowViewModel();
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}



		private static IEnumerable<object[]> GetTestCreateOrderForRowViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionForQuestionViewModel_Given_negative_order_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionForQuestionViewModel_Given_zero_order_value_Should_be_failed",
				0
			};
		}

		private static CreateOptionRowForQuestionViewModel GetCreateOptionRowViewModel(
			string text = "sometext",
			string imageUrl = "someUrl",
			int order = 1
			)
		{
			var createOptionRowModel = new CreateOptionRowForQuestionViewModel
			{
				Text = text,
				ImageUrl = imageUrl,
				Order = order
			};

			return createOptionRowModel;
		}
	}
}
