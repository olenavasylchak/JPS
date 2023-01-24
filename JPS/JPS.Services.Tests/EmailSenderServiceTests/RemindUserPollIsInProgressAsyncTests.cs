using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace JPS.Services.Tests.EmailSenderServiceTests
{
	[TestClass]
	public class RemindUserPollIsInProgressAsyncTests : EmailSenderServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			EmailSenderService = new EmailSenderService(
				SendGridOptionsMock.Object, DbContext, GraphServiceMock.Object);
		}

		[TestMethod]
		public async Task IntegrationRemindUserPollIsInProgress_GivenValidInput_ShouldBePassed()
		{
			var pollEntity = ModelsForEmailSenderTests.GetPollEntityModel();
			await AddItems(DbContext, pollEntity);

			var response = await EmailSenderService
				.RemindUserPollIsInProgressAsync(1, "test@test.test");
			var actualResponseStatus = (int)response.StatusCode;
			var expectedResponseStatus = (int)HttpStatusCode.Accepted;

			Assert.AreEqual(actualResponseStatus, expectedResponseStatus);
		}

		[TestMethod]
		public async Task TestRemindUserPollIsInProgress_GivenNotExistingPollId_ShouldBeFailed()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await EmailSenderService.RemindUserPollIsInProgressAsync(2, "test@test.test");
			});
		}
	}
}
