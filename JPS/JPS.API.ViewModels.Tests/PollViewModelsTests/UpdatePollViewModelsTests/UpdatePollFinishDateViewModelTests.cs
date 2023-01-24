using JPS.API.ViewModels.ViewModels.PollViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.Tests.PollViewModelsTests.UpdatePollViewModelsTests
{
	[TestClass]
	public class UpdatePollFinishDateViewModelTests
	{
		[TestMethod]
		public void TestFinishesAt_GivenDateEarlierThanNow_ShouldBeFailed()
		{
			var updatePollFinishDateViewModel = new UpdatePollFinishDateViewModel
			{
				FinishesAt = new DateTimeOffset(new DateTime(2019, 07, 12, 06, 32, 00))
			};

			var result = Validator.TryValidateObject(
				updatePollFinishDateViewModel,
				new ValidationContext(updatePollFinishDateViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestFinishesAt_GivenDateLaterThanNow_ShouldBePassed()
		{
			var updatePollFinishDateViewModel = new UpdatePollFinishDateViewModel
			{
				FinishesAt = new DateTimeOffset(new DateTime(3000, 03, 12, 04, 32, 00))
			};

			var result = Validator.TryValidateObject(
				updatePollFinishDateViewModel,
				new ValidationContext(updatePollFinishDateViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestFinishesAt_GivenNull_ShouldBePassed()
		{
			var updatePollFinishDateViewModel = new UpdatePollFinishDateViewModel
			{
				FinishesAt = null
			};

			var result = Validator.TryValidateObject(
				updatePollFinishDateViewModel,
				new ValidationContext(updatePollFinishDateViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}
	}
}

