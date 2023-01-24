using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests
{
	[TestClass]
	public class CreateQuestionSectionWithQuestionsViewModelTest
	{
		[TestMethod]
		public void TestCreateQuestionSection_TitleLength101_ShouldBeFailed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 101; i++)
			{
				text.Append("A");
			}

			var length = text.Length;
			var createViewModel = GetCreateQuestionSectionViewModel(title: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestionSection_TitleLength100_ShouldBePassed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 100; i++)
			{
				text.Append("A");
			}

			var length = text.Length;
			var createViewModel = GetCreateQuestionSectionViewModel(title: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestDescription()
		{
			var updateQuestionSectionDescriptionViewModel = new CreateQuestionSectionWithQuestionsViewModel();
			updateQuestionSectionDescriptionViewModel.Description = "test description";

			const string expectedDescription = "test description";

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.Description, expectedDescription);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOrderForSectionViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateSection_OrderIsNegativeOrZero(string displayName, int order)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateQuestionSectionViewModel(order: order);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestQuestionSection_ValidOrder_ShouldBePassed()
		{
			var updateQuestionSectionDescriptionViewModel = new CreateQuestionSectionWithQuestionsViewModel();
			updateQuestionSectionDescriptionViewModel.Order = 5;

			const int orderExpected = 5;

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.Order, orderExpected);
		}

		[TestMethod]
		public void TestQuestionSections_QuestionRequired_ShouldBeFailed()
		{
			var createViewModel = new CreateQuestionSectionWithQuestionsViewModel
			{
				Title = "test",
				Description = "aaa",
				Order = 1
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestQuestionSections_QuestionAny_ShouldBeFailed()
		{
			var createViewModel = new CreateQuestionSectionWithQuestionsViewModel
			{
				Title = "test",
				Description = "aaa",
				Order = 1,
				Questions = new List<CreateQuestionsViewModel>{ }
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestQuestionSections_QuestionOrderDuplicate_ShouldBeFailed()
		{
			var createViewModel = new CreateQuestionSectionWithQuestionsViewModel
			{
				Title = "test",
				Description = "aaa",
				Order = 1,
				Questions = new List<CreateQuestionsViewModel> {
					new CreateQuestionsViewModel() { Text= "lol", CanHaveOtherOption=false, QuestionTypeId=1, Order = 4},
					new CreateQuestionsViewModel() { Text= "lol", CanHaveOtherOption=false, QuestionTypeId=8, Order = 4}}
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestQuestionSection_Valid_ShouldBePassed()
		{
			var createViewModel = GetCreateQuestionSectionViewModel();
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}

		private static IEnumerable<object[]> GetTestCreateOrderForSectionViewModelData()
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

		private static CreateQuestionSectionWithQuestionsViewModel GetCreateQuestionSectionViewModel(
			string title = "testTitle",
			string description = "testDesc",
			int order = 1
			)
		{
			List<CreateQuestionsViewModel> questions = new List<CreateQuestionsViewModel>
			{
				new CreateQuestionsViewModel() { Text= "lol", CanHaveOtherOption=false, QuestionTypeId=1, Order = 4},
				new CreateQuestionsViewModel() { Text= "lol", CanHaveOtherOption=false, QuestionTypeId=8, Order = 3}
			};

			var createModel = new CreateQuestionSectionWithQuestionsViewModel
			{
				Title = title,
				Description = description,
				Order = order,
				Questions = questions
			};

			return createModel;
		}
	}
}
