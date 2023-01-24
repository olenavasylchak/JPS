using JPS.Services.Comparers.AnalyticsComparers;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace JPS.Services.Tests.AnalyticsServiceTests
{
	[TestClass]
	public class GetPollsComparisonTests : AnalyticsServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			FakeGraphService = new FakeGraphService();
			AnalyticsService = new AnalyticsService(DbContext, Mapper, FakeGraphService);
		}

		[TestMethod]
		public async Task GetPollsComparison_IntegrationTest()
		{
			var pollWithAnswers = ModelsForAnalyticsServiceTests.GetFirstPollToCompareModel();
			var pollWithAnswers2 = ModelsForAnalyticsServiceTests.GetSecondPollToCompareModel();
			await AddItems(DbContext, pollWithAnswers);
			await AddItems(DbContext, pollWithAnswers2);

			var result = await AnalyticsService.GetPollsComparison(1, 2);

			var expected = ModelsForAnalyticsServiceTests.GetPollComparisonModel();

			Assert.AreEqual(0, new PollComparisonDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestGetPollsComparison_GivenOneNotExistingId_ShouldThrowException()
		{
			await AddItems(DbContext, ModelsForAnalyticsServiceTests.GetFirstPollToCompareModel());
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await AnalyticsService.GetPollsComparison(1, 5);
			});
		}

		[TestMethod]
		public async Task TestGetPollsComparison_GivenTwoNotExistingIds_ShouldThrowException()
		{
			await AddItems(DbContext, ModelsForAnalyticsServiceTests.GetFirstPollToCompareModel());
			await AddItems(DbContext, ModelsForAnalyticsServiceTests.GetSecondPollToCompareModel());
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await AnalyticsService.GetPollsComparison(5, 7);
			});
		}
	}
}
