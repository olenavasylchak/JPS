using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.CreateModelsTests
{
	[TestClass]
	public class CreateParagraphAnswerViewModelTest
	{
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public void TestCreateTextAnswer_RequiredAttribute_ShouldBePassed()
		{
			var model = new CreateParagraphAnswerViewModel()
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
		public void TestCreateParagraphAnswer_GivenValidAnswer_ShouldBePassed()
		{
			var createModel = GetCreateParagraphAnswerViewModel();

			var validationResults = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(createModel, new ValidationContext(createModel), validationResults, true);

			Assert.IsTrue(actual, "Expected success.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of errors.");
		}

		private static CreateParagraphAnswerViewModel GetCreateParagraphAnswerViewModel(string text = "text")
		{
			var createParagraphAnswer = new CreateParagraphAnswerViewModel
			{
				Text = text
			};

			return createParagraphAnswer;
		}
	}
}
