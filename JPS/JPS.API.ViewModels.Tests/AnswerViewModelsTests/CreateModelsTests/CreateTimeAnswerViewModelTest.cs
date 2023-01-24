using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.AnswerViewModelsTests.CreateModelsTests
{
	[TestClass]
	public class CreateTimeAnswerViewModelTest
	{
		[TestMethod]
		public void TestCreateTimeAnswer_GivenValidTime_ShouldBePassed()
		{
			var createModel = GetCreateTimeAnswerViewModel();

			var validationResults = new List<ValidationResult>();

			var actual = Validator.TryValidateObject(createModel, new ValidationContext(createModel), validationResults, true);

			Assert.IsTrue(actual, "Expected success.");
			Assert.AreEqual(0, validationResults.Count, "Unexpected number of errors.");
		}

		private static CreateTimeAnswerViewModel GetCreateTimeAnswerViewModel()
		{
			TimeSpan time = new TimeSpan(4, 20, 0);
			var createTimeAnswer = new CreateTimeAnswerViewModel
			{
				Time = time
			};

			return createTimeAnswer;
		}
	}
}
