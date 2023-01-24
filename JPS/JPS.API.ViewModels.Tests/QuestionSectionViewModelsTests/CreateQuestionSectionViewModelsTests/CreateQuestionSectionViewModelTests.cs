using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.QuestionSectionViewModelsTests.CreateQuestionSectionViewModelsTests
{
	[TestClass]
	public class CreateQuestionSectionViewModelTests
	{
		[TestMethod]
		public void TestCreateQuestionSectionViewModel_GivenValidValues_ShouldBePassed()
		{
			var createQuestionSectionViewModel = GetCreateQuestionSectionViewModel();

			var result = Validator.TryValidateObject(
				createQuestionSectionViewModel,
				new ValidationContext(createQuestionSectionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateQuestionSectionViewModelPollIdData), DynamicDataSourceType.Method)]
		public void TestPollIdFails(
			string displayName,
			int pollId
		)
		{
			var createQuestionSectionViewModel = GetCreateQuestionSectionViewModel(pollId: pollId);

			var result = Validator.TryValidateObject(
				createQuestionSectionViewModel,
				new ValidationContext(createQuestionSectionViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestTitle_GivenLengthMoreThan100Symbols_ShouldBeFailed()
		{
			var titleWithLengthMoreThan100 =
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat";
			var createQuestionSectionViewModel = GetCreateQuestionSectionViewModel(title: titleWithLengthMoreThan100);

			var result = Validator.TryValidateObject(
				createQuestionSectionViewModel,
				new ValidationContext(createQuestionSectionViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestTitle_GivenLength100Symbols_ShouldBePassed()
		{
			var titleWithLength100 =
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts ea";
			var createQuestionSectionViewModel = GetCreateQuestionSectionViewModel(title: titleWithLength100);

			var result = Validator.TryValidateObject(
				createQuestionSectionViewModel,
				new ValidationContext(createQuestionSectionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateQuestionSectionViewModelOrderData), DynamicDataSourceType.Method)]
		public void TestOrderFails(
			string displayName,
			int order
		)
		{
			var createQuestionSectionViewModel = GetCreateQuestionSectionViewModel(order: order);

			var result = Validator.TryValidateObject(
				createQuestionSectionViewModel,
				new ValidationContext(createQuestionSectionViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestDescription_GivenNormalValue_ShouldBePassed()
		{
			var updateQuestionSectionDescriptionViewModel = new CreateQuestionSectionViewModel();
			updateQuestionSectionDescriptionViewModel.Description = "test description";

			const string expectedDescription = "test description";

			Assert.AreEqual(updateQuestionSectionDescriptionViewModel.Description, expectedDescription);
		}

		private static IEnumerable<object[]> GetTestCreateQuestionSectionViewModelOrderData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateQuestionSectionViewModel_GivenNegativeOrderValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateQuestionSectionViewModel_GivenZeroOrderValue_ShouldBeFailed",
				0
			};
		}

		private static IEnumerable<object[]> GetTestCreateQuestionSectionViewModelPollIdData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateQuestionSectionViewModel_GivenNegativePollIdValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: UpdateQuestionSectionViewModel_GivenZeroPollIdValue_ShouldBeFailed",
				0
			};
		}

		private static CreateQuestionSectionViewModel GetCreateQuestionSectionViewModel(
			int pollId = 1,
			string title = "test title",
			string description = "test description",
			int order = 1
		)
		{
			var createQuestionSectionViewModel = new CreateQuestionSectionViewModel
			{
				PollId = pollId,
				Title = title,
				Description = description,
				Order = order
			};

			return createQuestionSectionViewModel;
		}
	}
}
