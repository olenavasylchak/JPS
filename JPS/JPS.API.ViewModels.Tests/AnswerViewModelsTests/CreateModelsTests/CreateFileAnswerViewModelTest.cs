using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.CreateModelsTests
{
	[TestClass]
	public class CreateFileAnswerViewModelTest
	{
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public void TestCreateFileAnswer_TestRequiredAttribute_ShouldBePassed()
		{
			var model = new CreateFileAnswerViewModel()
			{
				FileUrl = string.Empty
			};
			var context = new ValidationContext(model, null, null)
			{
				MemberName = "FileUrl"
			};
			var validator = new RequiredAttribute();
			validator.Validate(model.FileUrl, context);
		}

		[TestMethod]
		public void TestCreateFileAnswer_GivenValidUrl_ShouldBePassed()
		{
			var createModel = GetCreateFileAnswerViewModel();

			var validationResults = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(createModel, new ValidationContext(createModel), validationResults, true);

			Assert.IsTrue(actual, "Expected success.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of errors.");
		}

		private static CreateFileAnswerViewModel GetCreateFileAnswerViewModel(string fileUrl = "url")
		{
			var createFileAnswer = new CreateFileAnswerViewModel
			{
				FileUrl = fileUrl
			};

			return createFileAnswer;
		}
	}
}
