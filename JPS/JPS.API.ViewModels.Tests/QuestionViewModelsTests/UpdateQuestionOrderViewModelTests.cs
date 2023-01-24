using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.QuestionViewModelsTests
{
	[TestClass]
	public class UpdateQuestionOrderViewModelTests
	{
		[TestMethod]
		public void TestSetQuestionId()
		{
			var updateQuestionSectionIdViewModel = new UpdateQuestionOrderViewModel
			{
				Id = 1
			};

			const int expected = 1;

			Assert.AreEqual(updateQuestionSectionIdViewModel.Id, expected);
		}

		[TestMethod]
		public void TestSetQuestionOrder()
		{
			var updateQuestionSectionIdViewModel = new UpdateQuestionOrderViewModel
			{
				Order = 1
			};

			const int expected = 1;

			Assert.AreEqual(updateQuestionSectionIdViewModel.Order, expected);
		}

		[TestMethod]
		public void TestSetQuestionSectionId()
		{
			var updateQuestionSectionIdViewModel = new UpdateQuestionOrderViewModel
			{
				SectionId = 1
			};

			const int expected = 1;

			Assert.AreEqual(updateQuestionSectionIdViewModel.SectionId, expected);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateIdForQuestionViewModelData), DynamicDataSourceType.Method)]
		public void TestUpdateQuestion_IdIsNegativeOrZero(string displayName, int questionId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var updateQuestionSectionIdViewModel = GetUpdateQuestionOrderViewModel(id: questionId);

			var result = Validator.TryValidateObject(
				updateQuestionSectionIdViewModel,
				new ValidationContext(updateQuestionSectionIdViewModel, null, null),
				null,
				true);


		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateQuestionSectionIdForQuestionViewModelData), DynamicDataSourceType.Method)]
		public void TestUpdateQuestion_SectionIdIsNegativeOrZero(string displayName, int questionSectionId)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var updateQuestionSectionIdViewModel = GetUpdateQuestionOrderViewModel(sectionId: questionSectionId);

			var result = Validator.TryValidateObject(
				updateQuestionSectionIdViewModel,
				new ValidationContext(updateQuestionSectionIdViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateOrderForQuestionViewModelData), DynamicDataSourceType.Method)]
		public void TestUpdateQuestion_OrderIsNegativeOrZero(string displayName, int questionOrder)
		{
			if (displayName is null)
			{
				throw new ArgumentNullException(nameof(displayName));
			}

			var updateQuestionSectionIdViewModel = GetUpdateQuestionOrderViewModel(order: questionOrder);

			var result = Validator.TryValidateObject(
				updateQuestionSectionIdViewModel,
				new ValidationContext(updateQuestionSectionIdViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestUpdateQuestionSectionIdForQuestionViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateSectionIdForQuestionViewModel_Given_negative_sectionId_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateSectionIdForQuestionViewModel_Given_zero_sectionId_value_Should_be_failed",
				0
			};
		}

		private static IEnumerable<object[]> GetTestUpdateOrderForQuestionViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateOrderForQuestionViewModel_Given_negative_order_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateOrderForQuestionViewModel_Given_zero_order_value_Should_be_failed",
				0
			};
		}

		private static IEnumerable<object[]> GetTestUpdateIdForQuestionViewModelData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateIdForQuestionViewModel_Given_negative_id_value_Should_be_failed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateIdForQuestionViewModel_Given_zero_id_value_Should_be_failed",
				0
			};
		}

		[TestMethod]
		public void TestUpdateQuestionOrder_Valid_ShouldBePassed()
		{
			var updateQuestionOrderViewModel = GetUpdateQuestionOrderViewModel();

			var validationResults = new List<ValidationResult>();
			var actual = Validator.TryValidateObject(updateQuestionOrderViewModel, new ValidationContext(updateQuestionOrderViewModel), validationResults, true);

			Assert.IsTrue(actual, "Expected validation to succeed.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
		}

		private static UpdateQuestionOrderViewModel GetUpdateQuestionOrderViewModel(
			int id = 1,
			int sectionId = 1,
			int order = 1
		)
		{
			var updateQuestionOrderViewModel = new UpdateQuestionOrderViewModel
			{
				Id = id,
				SectionId = sectionId,
				Order = order
			};

			return updateQuestionOrderViewModel;
		}
	}
}
