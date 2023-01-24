using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.CreateModelsTests
{
	[TestClass]
	public class CreateTextAnswerViewModelTest
	{
		[TestMethod]
		public void TestCreateTextAnswerViewModel_GivenValidTextLength_ShouldBePassed()
		{
			var stringBuilder = new StringBuilder(string.Empty);
			for (var i = 0; i < 250; i++)
			{
				stringBuilder.Append("*");
			}

			var model = new CreateTextAnswerViewModel
			{
				Text = stringBuilder.ToString()
			};

			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);
			Assert.IsTrue(actual, "Expects validation to pass");
		}

		[TestMethod]
		public void TestCreateTextAnswerViewModel_GivenOver250TextLength_ShouldBeFailed()
		{
			var stringBuilder = new StringBuilder(string.Empty);
			for (var i = 0; i < 251; i++)
			{
				stringBuilder.Append("*");
			}

			var model = new CreateTextAnswerViewModel
			{
				Text = stringBuilder.ToString()
			};

			var context = new ValidationContext(model);
			var results = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);
			Assert.IsFalse(actual, "Expects validation to fail");
		}

		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public void TestCreateTextAnswerViewModel_RequiredAttribute_ShouldBePassed()
		{
			var model = new CreateTextAnswerViewModel()
			{
				Text = string.Empty
			};
			var context = new ValidationContext(model, null, null)
			{
				MemberName = "Text"
			};
			var validator = new RequiredAttribute();
			validator.Validate(model.Text, context);
		}

		[TestMethod]
		public void TestCreateTextAnswer_GivenValidTextAnswer_ShouldBePassed()
		{
			var createModel = GetCreateTextAnswerViewModel();

			var validationResults = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(createModel, new ValidationContext(createModel), validationResults, true);

			Assert.IsTrue(actual, "Expected success.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of errors.");
		}

		private static CreateTextAnswerViewModel GetCreateTextAnswerViewModel(string text = "text")
		{
			var createTextAnswer = new CreateTextAnswerViewModel
			{
				Text = text
			};

			return createTextAnswer;
		}
	}
}
