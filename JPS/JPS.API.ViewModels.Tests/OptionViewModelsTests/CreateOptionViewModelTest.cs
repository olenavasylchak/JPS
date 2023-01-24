using JPS.API.ViewModels.ViewModels.OptionViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.OptionViewModelsTests
{
	[TestClass]
	public class CreateOptionViewModelTest
	{
		[TestMethod]
		public void TestCreateOptionViewModel_GivenValidValues_ShouldBePassed()
		{
			var createOptionViewModel = GetCreateOptionViewModel();

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestOrder_GivenNormalValue_ShouldBePassed()
		{
			var createOptionViewModel = GetCreateOptionViewModel();
			createOptionViewModel.Order = 50;

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestText_GivenNormalValues_ShouldBePassed()
		{
			var createOptionViewModel = GetCreateOptionViewModel();
			createOptionViewModel.Text = "test text";

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestImageUrl_GivenNormalValues_ShouldBePassed()
		{
			var createOptionViewModel = GetCreateOptionViewModel();
			createOptionViewModel.ImageUrl = "test.image/url";

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestValue_GivenNullValue_ShouldBePassed()
		{
			var createOptionViewModel = GetCreateOptionViewModel();
			createOptionViewModel.Value = null;

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestValue_GivenNormalValue_ShouldBePassed()
		{
			var createOptionViewModel = GetCreateOptionViewModel();
			createOptionViewModel.Value = -5;

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOptionViewModelQuestionIdData), DynamicDataSourceType.Method)]
		public void TestQuestionIdFails(string displayName, int questionId)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createOptionViewModel = GetCreateOptionViewModel(questionId: questionId);

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateOptionViewModelQuestionIdData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionViewModel_GivenNegativeQuestionIdValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionViewModel_GivenZeroQuestionIdValue_ShouldBeFailed",
				0
			};
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOptionViewModelOrderData), DynamicDataSourceType.Method)]
		public void TestOrderFails(string displayName, int order)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createOptionViewModel = GetCreateOptionViewModel(order: order);

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateOptionViewModelOrderData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionViewModel_GivenNegativeOrderValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionViewModel_GivenZeroOrderValue_ShouldBeFailed",
				0
			};
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOptionViewModelTextData), DynamicDataSourceType.Method)]
		public void TestTextFails(string displayName, string text)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createOptionViewModel = GetCreateOptionViewModel(text: text);

			var result = Validator.TryValidateObject(
				createOptionViewModel,
				new ValidationContext(createOptionViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateOptionViewModelTextData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionViewModel_GivenTextLengthMoreThan100Value_ShouldBeFailed",
				"pass me completely pass me completely pass me completely pass me completely pass me completely pass me completely"
			};
		}

		private static CreateOptionViewModel GetCreateOptionViewModel(
			int questionId = 1,
			string text = "sometext",
			string imageUrl = "someUrl",
			int order = 1,
			decimal? value = 5
			)
		{
			var createOptionModel = new CreateOptionViewModel
			{
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order,
				Value = value
			};

			return createOptionModel;
		}
	}
}
