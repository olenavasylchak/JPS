using JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using JPS.Services.Exceptions;

namespace JPS.Services.Tests.AnalyticsServiceTests
{
	[TestClass]
	public class GetGroupedAnswersByQuestionIdTests : AnalyticsServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			FakeGraphService = new FakeGraphService();
			AnalyticsService = new AnalyticsService(DbContext, Mapper, FakeGraphService);
		}

		[TestMethod]
		public async Task GetGroupedAnswersByQuestionId_IntegrationTest()
		{
			var pollWithAnswers = ModelsForAnalyticsServiceTests.GetPollWithAnswersModel();

			await AddItems(DbContext, pollWithAnswers);

			var textQuestionResult = await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(1);
			var paragraphQuestionResult = await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(2);
			var optionQuestionResult = await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(3);
			var fileQuestionResult = await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(4);
			var dateQuestionResult = await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(5);
			var timeQuestionResult = await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(6);
			var gridQuestionResult = await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(7);

			var expectedTextQuestionResult = ModelsForAnalyticsServiceTests.GetGroupedTextModel();
			var expectedParagraphQuestionResult = ModelsForAnalyticsServiceTests.GetGroupedParagraphModel();
			var expectedOptionQuestionResult = ModelsForAnalyticsServiceTests.GetGroupedOptionModel();
			var expectedFileQuestionResult = ModelsForAnalyticsServiceTests.GetGroupedFileModel();
			var expectedTimeQuestionResult = ModelsForAnalyticsServiceTests.GetGroupedTimeModel();
			var expectedDateQuestionResult = ModelsForAnalyticsServiceTests.GetGroupedDateModel();
			var expectedGridQuestionResult = ModelsForAnalyticsServiceTests.GetGroupedGridModel();

			Assert.AreEqual(0, new GroupedAnswerDTOComparer().Compare(expectedTextQuestionResult, textQuestionResult), "Text answers analytics failed");
			Assert.AreEqual(0, new GroupedAnswerDTOComparer().Compare(expectedParagraphQuestionResult, paragraphQuestionResult), "Paragraph answers analytics failed");
			Assert.AreEqual(0, new GroupedAnswerDTOComparer().Compare(expectedOptionQuestionResult, optionQuestionResult), "Option answers analytics failed");
			Assert.AreEqual(0, new GroupedAnswerDTOComparer().Compare(expectedFileQuestionResult, fileQuestionResult), "File answers analytics failed");
			Assert.AreEqual(0, new GroupedAnswerDTOComparer().Compare(expectedTimeQuestionResult, timeQuestionResult), "Time answers analytics failed");
			Assert.AreEqual(0, new GroupedAnswerDTOComparer().Compare(expectedDateQuestionResult, dateQuestionResult), "Date answers analytics failed");
			Assert.AreEqual(0, new GroupedAnswerDTOComparer().Compare(expectedGridQuestionResult, gridQuestionResult), "Grid answers analytics failed");
		}

		[TestMethod]
		public async Task TestGetGroupedAnswersByQuestionId_GivenNotExistingId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await AnalyticsService.GetGroupedAnswersByQuestionIdAsync(1);
			});
		}
	}
}
