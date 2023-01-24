using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests
{
	[TestClass]
	public class CreatePollWithQuestionSectionViewModelTest
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateCategoryForPollViewModelData), DynamicDataSourceType.Method)]
		public void TestCreatePoll_CategoryId(string displayName, int categoryId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreatePollViewModel(categoryId: categoryId);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePoll_CategoryIdNull_ShouldBePassed()
		{
			var createViewModel = GetCreatePollViewModel(categoryId: null);
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}

		[TestMethod]
		public void TestCreatePoll_TitleRequired_ShouldBeFailed()
		{
			var createViewModel = GetCreatePollViewModel(title: null);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePoll_TitleLength101_ShouldBeFailed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 101; i++)
			{
				text.Append("A");
			}

			var length = text.Length;
			var createViewModel = GetCreatePollViewModel(title: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePoll_TitleLength100_ShouldBePassed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 100; i++)
			{
				text.Append("A");
			}

			var length = text.Length;
			var createViewModel = GetCreatePollViewModel(title: Convert.ToString(text));

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
			var updateQuestionSectionDescriptionViewModel = new CreatePollWithQuestionSectionsViewModel();
			updateQuestionSectionDescriptionViewModel.Description = "test description";

			const string expectedDescription = "test description";

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.Description, expectedDescription);
		}

		[TestMethod]
		public void TestIsAnonymous()
		{
			var updateQuestionSectionDescriptionViewModel = new CreatePollWithQuestionSectionsViewModel();
			updateQuestionSectionDescriptionViewModel.IsAnonymous = true;

			const bool expected = true;

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.IsAnonymous, expected);
		}

		[TestMethod]
		public void TestCreatePoll_StartsAtBeforeNow_ShouldBeFailed()
		{
			var createViewModel = new CreatePollWithQuestionSectionsViewModel
			{
				CategoryId = 1,
				Title = "test",
				Description = "aaa",
				IsAnonymous = false,
				StartsAt = new DateTimeOffset(new DateTime(2019, 07, 12, 06, 32, 00)),
				FinishesAt = new DateTimeOffset(new DateTime(2022, 07, 12, 06, 32, 00)),
				QuestionSections = new List<CreateQuestionSectionWithQuestionsViewModel>
				{
				new CreateQuestionSectionWithQuestionsViewModel() { Title = "I", Description = "hate" , Order = 4},
				new CreateQuestionSectionWithQuestionsViewModel() {  Title = "I",  Description = "hate" , Order = 3 }
				}
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePoll_FinishesAtBeforeStartsAt_ShouldBeFailed()
		{
			var createViewModel = new CreatePollWithQuestionSectionsViewModel
			{
				CategoryId = 1,
				Title = "test",
				Description = "aaa",
				IsAnonymous = false,
				StartsAt = new DateTimeOffset(new DateTime(2021, 07, 12, 06, 32, 00)),
				FinishesAt = new DateTimeOffset(new DateTime(2020, 07, 12, 06, 32, 00)),
				QuestionSections = new List<CreateQuestionSectionWithQuestionsViewModel>
				{
				new CreateQuestionSectionWithQuestionsViewModel() { Title = "I", Description = "hate" , Order = 4},
				new CreateQuestionSectionWithQuestionsViewModel() {  Title = "I",  Description = "hate" , Order = 3 }
				}
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePoll_QuestionSectionsRequired_ShouldBeFailed()
		{
			var createViewModel = new CreatePollWithQuestionSectionsViewModel
			{
				CategoryId = 1,
				Title = "test",
				Description = "aaa",
				IsAnonymous = false,
				StartsAt = new DateTimeOffset(new DateTime(2021, 07, 12, 06, 32, 00)),
				FinishesAt = new DateTimeOffset(new DateTime(2022, 07, 12, 06, 32, 00)),
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePool_QuestionSectionsAny_ShouldBeFailed()
		{
			var createViewModel = new CreatePollWithQuestionSectionsViewModel
			{
				CategoryId = 1,
				Title = "test",
				Description = "aaa",
				IsAnonymous = false,
				StartsAt = new DateTimeOffset(new DateTime(2021, 07, 12, 06, 32, 00)),
				FinishesAt = new DateTimeOffset(new DateTime(2022, 07, 12, 06, 32, 00)),
				QuestionSections = new List<CreateQuestionSectionWithQuestionsViewModel>
				{
				}
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePoll_QuestionSectionsOrderDuplicate_ShouldBeFailed()
		{
			var createViewModel = new CreatePollWithQuestionSectionsViewModel
			{
				CategoryId = 1,
				Title = "test",
				Description = "aaa",
				IsAnonymous = false,
				StartsAt = new DateTimeOffset(new DateTime(2021, 07, 12, 06, 32, 00)),
				FinishesAt = new DateTimeOffset(new DateTime(2022, 07, 12, 06, 32, 00)),
				QuestionSections = new List<CreateQuestionSectionWithQuestionsViewModel>
				{
				new CreateQuestionSectionWithQuestionsViewModel() { Title = "I", Description = "hate" , Order = 4},
				new CreateQuestionSectionWithQuestionsViewModel() {  Title = "I",  Description = "hate" , Order = 4 }
				}
			};

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreatePoll_Valid_ShouldBePassed()
		{
			var createViewModel = GetCreatePollViewModel();
			// Act
			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			// Assert
			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}



		private static IEnumerable<object[]> GetTestCreateCategoryForPollViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionForQuestionViewModel_Given_negative_categoryId_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionForQuestionViewModel_Given_zero_categoryId_value_Should_be_failed",
				0
			};
		}

		private static CreatePollWithQuestionSectionsViewModel GetCreatePollViewModel(
			int? categoryId = 1,
			string title = "testTitle",
			string description = "testDesc",
			bool isAnonymous = false
			)
		{
			DateTimeOffset? startsAt = new DateTimeOffset(new DateTime(2021, 07, 12, 06, 32, 00));
			DateTimeOffset? finishesAt = new DateTimeOffset(new DateTime(2022, 07, 12, 06, 32, 00));
			List<CreateQuestionSectionWithQuestionsViewModel> questionSections = new List<CreateQuestionSectionWithQuestionsViewModel>
			{
				new CreateQuestionSectionWithQuestionsViewModel() { Title = "I", Description = "hate" , Order = 4},
				new CreateQuestionSectionWithQuestionsViewModel() {  Title = "I",  Description = "hate" , Order = 3 },
			};

			var createModel = new CreatePollWithQuestionSectionsViewModel
			{
				CategoryId = categoryId,
				Title = title,
				Description = description,
				IsAnonymous = isAnonymous,
				StartsAt = startsAt,
				FinishesAt = finishesAt,
				QuestionSections = questionSections
			};

			return createModel;
		}
	}
}
