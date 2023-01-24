using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.AnalyticsServiceTests
{
	[TestClass]
	public class GetPerсentOfUsersAnsweredThePollTests : AnalyticsServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			FakeGraphService = new FakeGraphService();
			AnalyticsService = new AnalyticsService(DbContext, Mapper, FakeGraphService);
		}

		[TestMethod]
		public async Task GetPerсentOfUsersAnsweredThePoll_IntegrationTest()
		{
			var pollWithAnswers = ModelsForAnalyticsServiceTests.GetPollWithAnswersModel();
			await AddItems(DbContext, pollWithAnswers);
			var expected = Math.Round(4.0 / 6.0, 2);
			var percent = await AnalyticsService.GetPerсentOfUsersAnsweredThePoll(pollWithAnswers.Id);
			Assert.AreEqual(expected, percent);
		}

		[TestMethod]
		public async Task TestGetPerсentOfUsersAnsweredThePoll_GivenNotExistingId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await AnalyticsService.GetPerсentOfUsersAnsweredThePoll(1);
			});
		}
	}
}
