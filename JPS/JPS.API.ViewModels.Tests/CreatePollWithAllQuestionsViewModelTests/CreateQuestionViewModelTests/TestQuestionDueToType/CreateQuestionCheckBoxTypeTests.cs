using JPS.API.ViewModels.Enums;
using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests.CreateQuestionViewModelTests.TestQuestionDueToType
{
	[TestClass]
	public class CreateQuestionCheckBoxTypeTests
	{
		[TestMethod]
		public void TestCreateQuestionCheckBox_OptionsAreNull_ShouldBeFailed()
        {
            var createViewModel = GetCreateQuestionViewModel();
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

            Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionCheckBox_OptionsWithValue_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 ,Value=3},
			};
			var createViewModel = GetCreateQuestionViewModel(options: options);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionCheckBox_ListOfRowsNull_ShouldBePassed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
			};
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
			};
			var createViewModel = GetCreateQuestionViewModel(options: options, optionRows: optionRows);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCreateQuestionCheckBox_WithRows_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
			};
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
			};
			var createViewModel = GetCreateQuestionViewModel(options: options, optionRows: optionRows);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionCheckBox_OnlyOneOption_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
			};
			var createViewModel = GetCreateQuestionViewModel(options: options);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionCheckBox_OptionsWithSameOrder_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext2",ImageUrl="url2", Order = 4},
			};
			var createViewModel = GetCreateQuestionViewModel(options: options);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionCheckBox_GivenOtherOptionFlag_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
			};
			bool canHaveOtherOption = true;
			var createViewModel = GetCreateQuestionViewModel(canHaveOtherOption: canHaveOtherOption, options: options);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCreateQuestion_Valid_ShouldBePassed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
			};
			var createViewModel = GetCreateQuestionViewModel(options: options);
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}

		private static CreateQuestionsViewModel GetCreateQuestionViewModel(
			IEnumerable<CreateOptionRowForQuestionViewModel> optionRows = null,
			IEnumerable<CreateOptionForQuestionViewModel> options = null,
				string text = "cheburek",
				bool isRequired = true,
				bool canHaveOtherOption = false,
				string comment = "comment",
				string imageUrl = "url",
				string videoUrl = "uek",
				int order = 1,
				int questionTypeId = (int)QuestionTypes.CheckBoxes
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
