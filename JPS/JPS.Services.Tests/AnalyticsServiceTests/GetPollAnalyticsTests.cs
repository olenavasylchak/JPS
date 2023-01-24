using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using JPS.Services.Comparers.AnalyticsComparers;
using JPS.Services.Exceptions;

namespace JPS.Services.Tests.AnalyticsServiceTests
{
	[TestClass]
	public class GetPollAnalyticsTests : AnalyticsServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			FakeGraphService = new FakeGraphService();
			AnalyticsService = new AnalyticsService(DbContext, Mapper, FakeGraphService);
		}

		[TestMethod]
		public async Task GetPollAnalytics_IntegrationTest()
		{
			var pollWithAnswers = ModelsForAnalyticsServiceTests.GetPollWithAnswersModel();

			await AddItems(DbContext, pollWithAnswers);

			var result = await AnalyticsService.GetPollAnalyticsAsync(1);

			var expected = ModelsForAnalyticsServiceTests.GetPollAnalyticsModel();

			Assert.AreEqual(0, new PollAnalyticsDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestGetPollAnalytics_GivenNotExistingId_ShouldThrowException()
		{
			await AddItems(DbContext, ModelsForAnalyticsServiceTests.GetPollWithAnswersModel());
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await AnalyticsService.GetPollAnalyticsAsync(2);
			});
		}
	}
}
