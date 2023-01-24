using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.CreateModelsTests
{
	[TestClass]
	public class CreateDateAnswerViewModelTest
	{
		[TestMethod]
		public void TestCreateDateAnswer_GivenValidDate_ShouldBePassed()
		{
			var createModel = GetCreateDateAnswerViewModel(new DateTime(2020, 07, 22, 08, 32, 00));

			var validationResults = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(createModel, new ValidationContext(createModel), validationResults, true);

			Assert.IsTrue(actual, "Expected success.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of errors.");
		}

		private static CreateDateAnswerViewModel GetCreateDateAnswerViewModel(DateTimeOffset date)
		{
			var createDateAnswer = new CreateDateAnswerViewModel
			{
				Date = date
			};

			return createDateAnswer;
		}
	}
}
