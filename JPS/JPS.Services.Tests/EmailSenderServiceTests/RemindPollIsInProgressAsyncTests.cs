using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace JPS.Services.Tests.EmailSenderServiceTests
{
	[TestClass]
	public class RemindPollIsInProgressAsyncTests : EmailSenderServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			EmailSenderService = new EmailSenderService(
				SendGridOptionsMock.Object, DbContext, GraphServiceMock.Object);
		}

		[TestMethod]
		public async Task IntegrationRemindPollIsInProgress_GivenValidInput_ShouldBePassed()
		{
			var pollEntity = ModelsForEmailSenderTests.GetPollEntityModel();
			await AddItems(DbContext, pollEntity);

			var response = await EmailSenderService
				.RemindPollIsInProgressAsync(1);
			var actualResponseStatus = (int)response.StatusCode;
			var expectedResponseStatus = (int)HttpStatusCode.Accepted;

			Assert.AreEqual(actualResponseStatus, expectedResponseStatus);
		}

		[TestMethod]
		public async Task TestRemindPollIsInProgress_GivenNotExistingPollId_ShouldBeFailed()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await EmailSenderService.RemindPollIsInProgressAsync(2);
			});
		}
	}
}
