using JPS.API.ViewModels.Enums;
using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests.CreateQuestionViewModelTests.TestQuestionDueToType
{
	[TestClass]
	public class CreateQuestionChoiceGridTypeTests
	{
		[TestMethod]
		public void TestCreateQuestionCheckBoxGrid_OptionsAndRowsAreNull_ShouldBeFailed()
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
		public void TestCreateQuestionCheckBoxGrid_OnlyOneOption_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
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
		public void TestCreateQuestionCheckBoxGrid_OnlyOneRow_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 2},
			};
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
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

		public void TestCreateQuestionCheckBoxGrid_RowsAreNull_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 2},
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
		public void TestCreateQuestionCheckBoxGrid_OptionsAreNull_ShouldBeFailed()
		{
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 1 },
			};
			var createViewModel = GetCreateQuestionViewModel(optionRows: optionRows);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionCheckBoxGrid_OptionOrderDuplicate_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
			};
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4 },
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
		public void TestCreateQuestionCheckBoxGrid_OptionRowOrderDuplicate_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
			};
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
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
		public void TestCreateQuestionCheckBoxGrid_SetValueForOption_ShouldBeFailed()
		{
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3, Value=1},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
			};
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4 },
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
		public void TestCreateQuestionCheckBoxGrid_GivenOtherOptionFlag_ShouldBeFailed()
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
			bool canHaveOtherOption = true;
			var createViewModel = GetCreateQuestionViewModel(canHaveOtherOption: canHaveOtherOption, options: options, optionRows: optionRows);
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
			List<CreateOptionForQuestionViewModel> options = new List<CreateOptionForQuestionViewModel>
			{
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
			};
			List<CreateOptionRowForQuestionViewModel> optionRows = new List<CreateOptionRowForQuestionViewModel>
			{
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 4},
				new CreateOptionRowForQuestionViewModel() { Text="Ttext",ImageUrl="url", Order = 3 },
			};
			var createViewModel = GetCreateQuestionViewModel(options: options, optionRows: optionRows);
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
			int questionTypeId = (int)QuestionTypes.MultipleChoiceGrid
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
