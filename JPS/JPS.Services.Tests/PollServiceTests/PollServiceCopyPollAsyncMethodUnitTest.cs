using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceCopyPollAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task CopyPoll_IntegrationTest()
		{
			var pollId = 1;

			await AddItems(DbContext, ModelsForPollTests.GetPollEntityModel());

			var pollCopy = await PollService.CopyPollAsync(pollId);

			Assert.IsNotNull(pollCopy);
		}

		[TestMethod]
		public async Task TestCopyPollMethodIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var pollId = 1;

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.CopyPollAsync(pollId);
			});
		}
	}
}
