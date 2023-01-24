using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests
{
	[TestClass]
	public class CreateOptionForQuestionViewModelTests
	{
		[TestMethod]
		public void TestCreateOption_OrderRequired_ShouldBeFailed()
		{
			var createOptionModel = new CreateOptionForQuestionViewModel
			{
				Value = null,
				Text = "Test",
				ImageUrl = "Test",

			};

			var result = Validator.TryValidateObject(
				createOptionModel,
				new ValidationContext(createOptionModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOrderForOptionViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateOption_OrderIsNegativeOrZero(string displayName, int order)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateOptionViewModel(order: order);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateOption_TextLength101_ShouldBeFailed()
		{
			var text = new StringBuilder(string.Empty);
			for (int i = 0; i < 101; i++)
			{
				text.Append("A");
			}
			var createViewModel = GetCreateOptionViewModel(text: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}


		[TestMethod]
		public void TestCreateOption_TextLength100_ShouldBePassed()
		{
			var text = new StringBuilder(string.Empty);
			for (int i = 0; i < 100; i++)
			{
				text.Append("A");
			}
			var createViewModel = GetCreateOptionViewModel(text: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestOption_Valid_ShouldBePassed()
		{
			var createViewModel = GetCreateOptionViewModel();
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}



		private static IEnumerable<object[]> GetTestCreateOrderForOptionViewModelData()
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

		private static CreateOptionForQuestionViewModel GetCreateOptionViewModel(
			decimal? value = null,
			string text = "sometext",
			string imageUrl = "someUrl",
			int order = 1
			)
		{
			var createOptionModel = new CreateOptionForQuestionViewModel
			{
				Value = value,
				Text = text,
				ImageUrl = imageUrl,
				Order = order
			};

			return createOptionModel;
		}
	}
}
