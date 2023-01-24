using JPS.API.ViewModels.Enums;
using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests.CreateQuestionViewModelTests.TestQuestionDueToType
{
	[TestClass]
	public class CreateQuestionTimeTypeTests
	{
		[TestMethod]
        public void TestCreateQuestionTime_GivenLisnOfOptions_ShouldBePassed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
			};
			var createViewModel = GetCreateQuestionViewModelWithOptionsAndRows(options: options);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionTime_GivenLisnOfOptionRows_ShouldBePassed()
		{
			List<CreateOptionRowForQuestionViewModel> rows = new List<CreateOptionRowForQuestionViewModel>
			{
			};
			var createViewModel = GetCreateQuestionViewModelWithOptionsAndRows(optionRows: rows);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionTime_OptionsAreGiven_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
			};
			var createViewModel = GetCreateQuestionViewModelWithOptionsAndRows(options: options);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionTime_OptionRowsAreGiven_ShouldBePassed()
		{
			List<CreateOptionRowForQuestionViewModel> rows = new List<CreateOptionRowForQuestionViewModel>
			{
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
			};
			var createViewModel = GetCreateQuestionViewModelWithOptionsAndRows(optionRows: rows);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestion_Valid_ShouldBePassed()
		{
			var createViewModel = GetCreateQuestionViewModel();
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}

		private static CreateQuestionsViewModel GetCreateQuestionViewModel(
		string text = "cheburek",
		bool isRequired = true,
		bool canHaveOtherOption = false,
		string comment = "comment",
		string imageUrl = "url",
		string videoUrl = "uek",
		int order = 1,
		int questionTypeId = (int)QuestionTypes.Time
)
		{
			var createModel = new CreateQuestionsViewModel
			{
				Text = text,
				IsRequired = isRequired,
				CanHaveOtherOption = canHaveOtherOption,
				Comment = comment,
				ImageUrl = imageUrl,
				Order = order,
				QuestionTypeId = questionTypeId,
				VideoUrl = videoUrl
			};

			return createModel;
		}

		[TestMethod]
		public void TestCreateQuestionTime_GivenOtherOptionFlag_ShouldBeFailed()
		{
			bool canHaveOtherOption = true;
			var createViewModel = GetCreateQuestionViewModel(canHaveOtherOption: canHaveOtherOption);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static CreateQuestionsViewModel GetCreateQuestionViewModelWithOptionsAndRows(
			IEnumerable<CreateOptionRowForQuestionViewModel> optionRows = null,
			IEnumerable<CreateOptionForQuestionViewModel> options = null,
				string text = "cheburek",
				bool isRequired = true,
				bool canHaveOtherOption = false,
				string comment = "comment",
				string imageUrl = "url",
				string videoUrl = "uek",
				int order = 1,
				int questionTypeId = (int)QuestionTypes.Time
		)
		{
			var createModel = new CreateQuestionsViewModel
			{
				Text = text,
				IsRequired = isRequired,
				CanHaveOtherOption = canHaveOtherOption,
				Comment = comment,
				ImageUrl = imageUrl,
				Order = order,
				QuestionTypeId = questionTypeId,
				VideoUrl = videoUrl,
				Options = options,
				OptionRows = optionRows
			};

			return createModel;
		}
	}
}
