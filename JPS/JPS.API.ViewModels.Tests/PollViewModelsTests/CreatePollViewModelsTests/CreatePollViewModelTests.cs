using JPS.API.ViewModels.ViewModels.PollStyleViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.PollViewModelsTests.CreatePollViewModelsTests
{
	[TestClass]
	public class CreatePollViewModelTests
	{
		[TestMethod]
		public void TestCreatePollViewModel_GivenValidValues_ShouldBePassed()
		{
			var createPollViewModel = GetCreatePollViewModel();

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCategoryId_GivenNormalValue_ShouldBePassed()
		{
			var createPollViewModel = GetCreatePollViewModel();

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestDescription_GivenNormalString_ShouldBePassed()
		{
			var createPollViewModel = new CreatePollViewModel();
			createPollViewModel.Description = "test description";

			const string expectedDescription = "test description";

			Assert.AreEqual(createPollViewModel.Description, expectedDescription);
		}

		[TestMethod]
		public void TestTitle_GivenMaximumAllowableLength_ShouldBePassed()
		{
			var titleWithLength100 =
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts ea";
			var createPollViewModel = GetCreatePollViewModel(title: titleWithLength100);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestFinishesAt_GivenDateEarlierThanStartsAt_ShouldBeFailed()
		{
			var finishesAt = new DateTimeOffset(new DateTime(3000, 07, 12, 06, 32, 00));
			var startsAt = new DateTimeOffset(new DateTime(3001, 07, 12, 06, 32, 00));

			var createPollViewModel = GetCreatePollViewModel(
				finishesAt: finishesAt,
				startsAt: startsAt
				);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestFinishesAt_GivenDateLaterThanStartsAt_ShouldBePassed()
		{
			var finishesAt = new DateTimeOffset(new DateTime(3001, 07, 12, 06, 32, 00));
			var startsAt = new DateTimeOffset(new DateTime(3000, 07, 12, 06, 32, 00));

			var createPollViewModel = GetCreatePollViewModel(
				finishesAt: finishesAt,
				startsAt: startsAt
			);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestFinishesAt_GivenEqualStartsAt_ShouldBePassed()
		{
			var finishesAt = new DateTimeOffset(new DateTime(3000, 07, 12, 06, 32, 00));
			var startsAt = new DateTimeOffset(new DateTime(3000, 07, 12, 06, 32, 00));

			var createPollViewModel = GetCreatePollViewModel(
				finishesAt: finishesAt,
				startsAt: startsAt
			);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestFinishesAt_GivenDateLaterThanNow_ShouldBePassed()
		{
			var finishesAt = new DateTimeOffset(new DateTime(3000, 03, 12, 04, 32, 00));

			var createPollViewModel = GetCreatePollViewModel(finishesAt: finishesAt);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestStartsAt_GivenDateEarlierThanNow_ShouldBeFailed()
		{
			var startsAt = new DateTimeOffset(new DateTime(2019, 07, 12, 06, 32, 00));

			var createPollViewModel = GetCreatePollViewModel(startsAt: startsAt);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestStartsAt_GivenDateLaterThanNow_ShouldBePassed()
		{
			var startsAt = new DateTimeOffset(new DateTime(3000, 03, 12, 04, 32, 00));

			var createPollViewModel = GetCreatePollViewModel(startsAt: startsAt);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreatePollViewModelCategoryIdData), DynamicDataSourceType.Method)]
		public void TestCategoryIdFails(
			string displayName,
			int categoryId)
		{

			var createPollViewModel = GetCreatePollViewModel(categoryId: categoryId);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreatePollViewModelCategoryIdData()
		{
			yield return new object[]
			{
				"Test case 1: CreatePollViewModel_GivenNegativeCategoryIdValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreatePollViewModel_GivenZeroCategoryIdValue_ShouldBeFailed",
				0
			};
		}


		[DataTestMethod]
		[DynamicData(nameof(GetTestCreatePollViewModelTitleData), DynamicDataSourceType.Method)]
		public void TestCategoryIdFails(
			string displayName,
			string title)
		{
			var createPollViewModel = GetCreatePollViewModel(title: title);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreatePollViewModelTitleData()
		{
			yield return new object[]
			{
				"Test case 1: CreatePollViewModel_GivenTitleLengthMoreThan100Value_ShouldBeFailed",
				"eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat my shorts eat"
			};

			yield return new object[]
			{
				"Test case 1: CreatePollViewModel_GivenNullTitleValue_ShouldBeFailed",
				null
			};
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreatePollViewModelIsAnonymousData), DynamicDataSourceType.Method)]
		public void TestIsAnonymousPasses(
			string displayName,
			bool isAnonymous)
		{

			var createPollViewModel = GetCreatePollViewModel(isAnonymous: isAnonymous);

			var result = Validator.TryValidateObject(
				createPollViewModel,
				new ValidationContext(createPollViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		private static IEnumerable<object[]> GetTestCreatePollViewModelIsAnonymousData()
		{
			yield return new object[]
			{
				"Test case 1: CreatePollViewModel_GivenTrueIsAnonymousValue_ShouldBePassed",
				false
			};

			yield return new object[]
			{
				"Test case 2: CreatePollViewModel_GivenFalseIsAnonymousValue_ShouldBePassed",
				true
			};
		}

		private static CreatePollViewModel GetCreatePollViewModel(
			DateTimeOffset? startsAt = null,
			DateTimeOffset? finishesAt = null,
			int? categoryId = 1,
			string title = "title",
			string description = "description",
			bool isAnonymous = false,
			string font = "default",
			decimal opacity = 0,
			string themeColor = "#000000"
		)
		{
			var createPollViewModel = new CreatePollViewModel
			{
				CategoryId = categoryId,
				Title = title,
				Description = description,
				IsAnonymous = isAnonymous,
				StartsAt = startsAt,
				FinishesAt = finishesAt,
				PollStyle = new CreatePollStyleViewModel
				{
					Font = font,
					Opacity = opacity,
					ThemeColor = themeColor
				}
			};

			return createPollViewModel;
		}
	}
}
