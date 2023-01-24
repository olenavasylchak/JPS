using System;
using System.ComponentModel.DataAnnotations;
using JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JPS.API.ViewModels.Tests.PollViewModelsTests.UpdatePollViewModelsTests
{
	[TestClass]
	public class UpdatePollStartDateViewModelTests
	{
		[TestMethod]
		public void TestStartsAt_GivenDateEarlierThanNow_ShouldBeFailed()
		{
			var updatePollStartDateViewModel = new UpdatePollStartDateViewModel
			{
				StartsAt = new DateTimeOffset(new DateTime(2019, 07, 12, 06, 32, 00))
			};

			var result = Validator.TryValidateObject(
				updatePollStartDateViewModel,
				new ValidationContext(updatePollStartDateViewModel, null, null),
				null,
				true);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestStartsAt_GivenDateLaterThanNow_ShouldBePassed()
		{
			var updatePollStartDateViewModel = new UpdatePollStartDateViewModel
			{
				StartsAt = new DateTimeOffset(new DateTime(3000, 03,12,04, 32, 00))
			};

			var result = Validator.TryValidateObject(
				updatePollStartDateViewModel,
				new ValidationContext(updatePollStartDateViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestStartsAt_GivenNull_ShouldBePassed()
		{
			var updatePollStartDateViewModel = new UpdatePollStartDateViewModel
			{
				StartsAt = null
			};

			var result = Validator.TryValidateObject(
				updatePollStartDateViewModel,
				new ValidationContext(updatePollStartDateViewModel, null, null),
				null,
				true);

			Assert.IsTrue(result);
		}
	}
}
