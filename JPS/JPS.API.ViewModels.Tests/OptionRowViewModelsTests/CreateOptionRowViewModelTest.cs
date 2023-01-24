using JPS.API.ViewModels.ViewModels.OptionRowViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.OptionRowViewModelsTests
{
	[TestClass]
	public class CreateOptionRowViewModelTests
	{
		[TestMethod]
		public void TestCreateOptionRowViewModel_GivenValidValues_ShouldBePassed()
		{
			var createRowViewModel = GetCreateOptionRowViewModel();

			var result = Validator.TryValidateObject(
				createRowViewModel,
				new ValidationContext(createRowViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestOrder_GivenNormalValue_ShouldBePassed()
		{
			var createRowViewModel = GetCreateOptionRowViewModel();
			createRowViewModel.Order = 50;

			var result = Validator.TryValidateObject(
				createRowViewModel,
				new ValidationContext(createRowViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestText_GivenNormalValues_ShouldBePassed()
		{
			var createRowViewModel = GetCreateOptionRowViewModel();
			createRowViewModel.Text = "test text";

			var result = Validator.TryValidateObject(
				createRowViewModel,
				new ValidationContext(createRowViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestImageUrl_GivenNormalValues_ShouldBePassed()
		{
			var createRowViewModel = GetCreateOptionRowViewModel();
			createRowViewModel.ImageUrl = "test.image/url";

			var result = Validator.TryValidateObject(
				createRowViewModel,
				new ValidationContext(createRowViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOptionRowViewModelQuestionIdData), DynamicDataSourceType.Method)]
		public void TestQuestionIdFails(string displayName, int questionId)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateOptionRowViewModel(questionId: questionId);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateOptionRowViewModelQuestionIdData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionRowViewModel_GivenNegativeQuestionIdValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionRowViewModel_GivenZeroQuestionIdValue_ShouldBeFailed",
				0
			};
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOptionRowViewModelOrderData), DynamicDataSourceType.Method)]
		public void TestOrderFails(string displayName, int order)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateOptionRowViewModel(order: order);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateOptionRowViewModelOrderData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionRowViewModel_GivenNegativeOrderValue_ShouldBeFailed",
				-1
			};

			yield return new object[]
			{
				"Test case 2: CreateOptionRowViewModel_GivenZeroOrderValue_ShouldBeFailed",
				0
			};
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCreateOptionRowViewModelTextData), DynamicDataSourceType.Method)]
		public void TestTextFails(string displayName, string text)
		{
			if (displayName is null)
			{
				throw new System.ArgumentNullException(nameof(displayName));
			}

			var createViewModel = GetCreateOptionRowViewModel(text: text);

			var result = Validator.TryValidateObject(
				createViewModel,
				new ValidationContext(createViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		private static IEnumerable<object[]> GetTestCreateOptionRowViewModelTextData()
		{
			yield return new object[]
			{
				"Test case 1: CreateOptionRowViewModel_GivenTextLengthMoreThan100Value_ShouldBeFailed",
				"pass me completely pass me completely pass me completely pass me completely pass me completely pass me completely"
			};
		}

		private static CreateOptionRowViewModel GetCreateOptionRowViewModel(
			int questionId = 1,
			string text = "sometext",
			string imageUrl = "someUrl",
			int order = 1
			)
		{
			var createOptionRowModel = new CreateOptionRowViewModel
			{
				QuestionId = questionId,
				Text = text,
				ImageUrl = imageUrl,
				Order = order
			};

			return createOptionRowModel;
		}
	}
}
