using JPS.API.ViewModels.ViewModels.QuestionViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class CreateQuestionViewModelTests
	{
		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateQuestionTypeIdForQuestionViewModelShouldBePassedData), DynamicDataSourceType.Method)]
		public void TestCreateQuestion_QuestionTypeId_ShouldBePassed(string displayName, int questionTypeId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateQuestionViewModel(questionTypeId: questionTypeId);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCreateQuestion_CommentLength250_ShouldBePassed()
		{
			var comment = new StringBuilder();
			for (int index = 0; index < 250; index++)
			{
				comment.Append("a");
			}
			var createViewModel = GetCreateQuestionViewModel(comment: comment.ToString());

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCreateQuestion_TextIsRequired_ShouldBeFailed()
		{

			var createViewModel = GetCreateQuestionViewModel(text: null);

			var result = Validator.TryValidateObject(
			  createViewModel,
			  new ValidationContext(createViewModel, null, null),
			  null,
			  true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestSetQuestionText()
		{
			var createQuestionTextViewModel = new CreateQuestionViewModel
			{
				Text = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(createQuestionTextViewModel.Text, expected);
		}

		[TestMethod]
		public void TestSetQuestionComment()
		{
			var createQuestionCommentViewModel = new CreateQuestionViewModel
			{
				Comment = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(createQuestionCommentViewModel.Comment, expected);
		}

		[TestMethod]
		public void TestSetQuestionIsRequired()
		{
			var createQuestionIsRequiredViewModel = new CreateQuestionViewModel
			{
				IsRequired = true
			};

			const bool expected = true;

			Assert.AreEqual(createQuestionIsRequiredViewModel.IsRequired, expected);
		}

		[TestMethod]
		public void TestSetQuestionCanHaveOtherOption()
		{
			var createQuestionCanHaveOtherOptionViewModel = new CreateQuestionViewModel
			{
				CanHaveOtherOption = true
			};

			const bool expected = true;

			Assert.AreEqual(createQuestionCanHaveOtherOptionViewModel.CanHaveOtherOption, expected);
		}

		[TestMethod]
		public void TestSetQuestionOrder()
		{
			var createQuestionOrderViewModel = new CreateQuestionViewModel
			{
				Order = 1
			};

			const int expected = 1;

			Assert.AreEqual(createQuestionOrderViewModel.Order, expected);
		}

		[TestMethod]
		public void TestSetQuestionImageUrl()
		{
			var createQuestionImageUrlViewModel = new CreateQuestionViewModel
			{
				ImageUrl = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(createQuestionImageUrlViewModel.ImageUrl, expected);
		}

		[TestMethod]
		public void TestSetQuestionSectionId()
		{
			var createQuestionSectionIdViewModel = new CreateQuestionViewModel
			{
				QuestionSectionId = 1
			};

			const int expected = 1;

			Assert.AreEqual(createQuestionSectionIdViewModel.QuestionSectionId, expected);
		}

		[TestMethod]
		public void TestSetQuestionVideoUrl()
		{
			var createQuestionVideoUrlViewModel = new CreateQuestionViewModel
			{
				VideoUrl = "test it"
			};

			const string expected = "test it";

			Assert.AreEqual(createQuestionVideoUrlViewModel.VideoUrl, expected);
		}

		[TestMethod]
		public void TestSetQuestionTypeId()
		{
			var createQuestionTypeIdViewModel = new CreateQuestionViewModel
			{
				QuestionTypeId = 1
			};

			const int expected = 1;

			Assert.AreEqual(createQuestionTypeIdViewModel.QuestionTypeId, expected);
		}

		[TestMethod]
		public void TestCreateQuestion_CommentLength251_ShouldBeFailed()
		{
			var comment = new StringBuilder();
			for (int index = 0; index < 251; index++)
			{
				comment.Append("a");
			}

			var createViewModel = GetCreateQuestionViewModel(comment: comment.ToString());

			var result = Validator.TryValidateObject(
			  createViewModel,
			  new ValidationContext(createViewModel, null, null),
			  null,
			  true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateSectionIdForQuestionViewModelDataShouldBeFailed), DynamicDataSourceType.Method)]
		public void TestCreateQuestion_SectionIdIsNegativeOrZero(string displayName, int sectionId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateQuestionViewModel(questionSectionId: sectionId);
			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOrderForQuestionViewModelData), DynamicDataSourceType.Method)]
		public void TestCreateQuestion_OrderIsNegativeOrZero(string displayName, int order)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateQuestionViewModel(order: order);
			var result = Validator.TryValidateObject(
			  createViewModel,
			  new ValidationContext(createViewModel, null, null),
			  null,
			  true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateQuestionTypeIdForQuestionViewModelShouldBeFailedData), DynamicDataSourceType.Method)]
		public void TestCreateQuestion_QuestionTypeId_ShouldBeFailed(string displayName, int questionTypeId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateQuestionViewModel(questionTypeId: questionTypeId);
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

			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(createViewModel, new ValidationContext(createViewModel), validationResults, true);

			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}

		private static IEnumerable<object[]> GetTestCreateQuestionTypeIdForQuestionViewModelShouldBePassedData()
		{
			yield return new object[]
			{
				"Test case 1: CreateQuestionTypeIdForQuestionViewModel_Given_positive_questionTypeID_value_Should_be_failed",
				1
			};

			yield return new object[]
			{
				"Test case 2: CreateQuestionTypeIdForQuestionViewModel_Given_less_than_12_questionTypeID_value_Should_be_failed",
				11
			};
		}

		private static IEnumerable<object[]> GetTestCreateQuestionTypeIdForQuestionViewModelShouldBeFailedData()
		{
			yield return new object[]
			{
				"Test case 1: CreateQuestionTypeIdForQuestionViewModel_Given_negative_questionTypeID_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 1: CreateQuestionTypeIdForQuestionViewModel_Given_zero_questionTypeID_value_Should_be_failed",
				0
			};

			yield return new object[]
			{
				"Test case 2: CreateQuestionTypeIdForQuestionViewModel_Given_above_11_questionTypeID_value_Should_be_failed",
				12
			};
		}

		private static IEnumerable<object[]> GetTestCreateOrderForQuestionViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOrderForQuestionViewModel_Given_negative_order_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOrderForQuestionViewModel_Given_zero_order_value_Should_be_failed",
				0
			};
		}

		private static IEnumerable<object[]> GetTestCreateSectionIdForQuestionViewModelDataShouldBeFailed()
		{
			yield return new object[]
			{
				"Test case 1: CreateSectionIdForQuestionViewModel_Given_negative_question_section_id_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateSectionIdForQuestionViewModel_Given_zero_section_id_value_Should_be_failed",
				0
			};
		}

		private static CreateQuestionViewModel GetCreateQuestionViewModel(
			string text = "test text",
			bool isRequired = true,
			int questionSectionId = 1,
			bool canHaveOtherOption = false,
			string comment = "comment",
			string imageUrl = "img",
			string videoUrl = "vid",
			int order = 1,
			int questionTypeId = 1
		)
		{
			var createModel = new CreateQuestionViewModel
			{
				Text = text,
				IsRequired = isRequired,
				QuestionSectionId = questionSectionId,
				CanHaveOtherOption = canHaveOtherOption,
				Comment = comment,
				ImageUrl = imageUrl,
				Order = order,
				QuestionTypeId = questionTypeId,
				VideoUrl = videoUrl
			};

			return createModel;
		}
	}
}