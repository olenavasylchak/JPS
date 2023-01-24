using JPS.Services.Comparers;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceGetPollByIdAsyncMethodUnitTests : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task GetAllPolls_IntegrationTest()
		{
			await AddItems(DbContext, ModelsForPollTests.GetPollEntityModel(id: 1));

			var poll = await PollService.GetPollByIdAsync(1);
			var expectedPollDTO = ModelsForPollTests.GetPollDTOModel(id: 1);

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPollDTO, poll));
		}

		[TestMethod]
		public async Task TestGetPollByIdMethodIdValidation_GivenNotExistingId_ShouldThrowException()
		{
			var pollEntity = ModelsForPollTests.GetPollEntityModel();
			await AddItems(DbContext, pollEntity);

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.GetPollByIdAsync(10);
			});
		}
	}
}
