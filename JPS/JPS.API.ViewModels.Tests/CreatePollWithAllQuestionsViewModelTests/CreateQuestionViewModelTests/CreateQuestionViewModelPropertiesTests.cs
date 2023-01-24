using JPS.API.ViewModels.Enums;
using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPS.API.ViewModels.Tests.CreatePollWithAllQuestionsViewModelTests.CreateQuestionViewModelTests
{
	[TestClass]
	public class CteateQuestionViewModelPropertiesTest
	{
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
		public void TestText()
		{
			var updateQuestionViewModel = new CreateQuestionsViewModel();
			updateQuestionViewModel.Text = "test it";

			const string expected = "test it";

			Assert.AreEqual(updateQuestionViewModel.Text, expected);
        }

        [TestMethod]
		public void TestIsRequired()
		{
			var updateQuestionViewModel = new CreateQuestionsViewModel();
			updateQuestionViewModel.IsRequired = true;

			const bool expected = true;

			Assert.AreEqual(updateQuestionViewModel.IsRequired, expected);
		}

		[TestMethod]
		public void TestCanHaveOtherOption()
		{
			var updateQuestionViewModel = new CreateQuestionsViewModel();
			updateQuestionViewModel.CanHaveOtherOption = true;

			const bool expected = true;

			Assert.AreEqual(updateQuestionViewModel.CanHaveOtherOption, expected);
		}

		[TestMethod]
		public void TestCreateQuestion_CommentLength251_ShouldBeFailed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 251; i++)
			{
				text.Append("A");
			}

			var createViewModel = GetCreateQuestionViewModel(comment: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCreateQuestion_CommentLength250_ShouldBePassed()
		{
			var text = new StringBuilder();
			for (int i = 0; i < 250; i++)
			{
				text.Append("A");
			}
			var createViewModel = GetCreateQuestionViewModel(comment: Convert.ToString(text));

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
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

		[TestMethod]
		public void TestOrder()
		{
			var updateQuestionViewModel = new CreateQuestionsViewModel();
			updateQuestionViewModel.Order = 1;

			const int expected = 1;

			Assert.AreEqual(updateQuestionViewModel.Order, expected);
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
		public void TestImageUrl()
		{
			var updateQuestionViewModel = new CreateQuestionsViewModel();
			updateQuestionViewModel.ImageUrl = "test it";

			const string expected = "test it";

			Assert.AreEqual(updateQuestionViewModel.ImageUrl, expected);
		}

		[TestMethod]
		public void TestVideoUrl()
		{
			var updateQuestionViewModel = new CreateQuestionsViewModel();
			updateQuestionViewModel.VideoUrl = "test it";

			const string expected = "test it";

			Assert.AreEqual(updateQuestionViewModel.VideoUrl, expected);
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

		private static IEnumerable<object[]> GetTestCreateQuestionTypeIdForQuestionViewModelShouldBePassedData()
		{
			yield return new object[]
			{
				"Test case 1: CteateQuestionViewModel_Given_zero_questionTypeID_value_Should_be_failed",
				1
			};

			yield return new object[]
			{
				"Test case 2: CteateQuestionViewModel_Given_12_questionTypeID_value_Should_be_failed",
				11
			};
		}

		private static IEnumerable<object[]> GetTestCreateQuestionTypeIdForQuestionViewModelShouldBeFailedData()
		{
			yield return new object[]
			{
				"Test case 1: CteateQuestionViewModel_Given_zero_questionTypeID_value_Should_be_failed",
				0
			};

			yield return new object[]
			{
				"Test case 2: CteateQuestionViewModel_Given_12_questionTypeID_value_Should_be_failed",
				12
			};
		}

		private static IEnumerable<object[]> GetTestCreateOrderForQuestionViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: CteateQuestionViewModel_Given_negative_order_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CteateQuestionViewModel_Given_zero_order_value_Should_be_failed",
				0
			};
		}

		private static CreateQuestionsViewModel GetCreateQuestionViewModel(
			string text = "cheburek",
			bool isRequired = true,
			bool canHaveOtherOption= false,
			string comment = "comment",
			string imageUrl ="url",
			string videoUrl= "uek",
			int order = 1,
			int questionTypeId= 1
		)
		{
			var createModel = new CreateQuestionsViewModel
			{
				Text = text,
				IsRequired=isRequired ,
				CanHaveOtherOption=canHaveOtherOption ,
				Comment = comment,
				ImageUrl =imageUrl ,
				Order = order,
				QuestionTypeId= questionTypeId,
				VideoUrl=videoUrl 
			};

			return createModel;
		}
	}
}
