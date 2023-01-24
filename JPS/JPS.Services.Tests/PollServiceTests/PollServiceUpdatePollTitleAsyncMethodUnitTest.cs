using JPS.Services.Comparers;
using JPS.Services.DTO.DTOs.PollDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceUpdatePollTitleAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task UpdatePollTitle_IntegrationTests()
		{
			var pollEntity = ModelsForPollTests.GetPollEntityModel();

			await AddItems(DbContext, pollEntity);

			var title = "new";

			var updatePollTitleDTO = new UpdatePollTitleDTO() { Title = title };

			var resultPoll = await PollService.UpdatePollTitleAsync(updatePollTitleDTO, 1);

			var expectedPoll = ModelsForPollTests.GetPollDTOModel(title: title);

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPoll, resultPoll));
		}

		[TestMethod]
		public async Task TestUpdatePollTitleMethod_PollHasStarted_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				startsAt: DateTimeOffset.Now.AddDays(-10));
			await AddItems(DbContext, pollEntity);

			var updatePollTitleDTO = new UpdatePollTitleDTO() { Title = "test" };

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await PollService.UpdatePollTitleAsync(updatePollTitleDTO, pollId);
			});
		}

		[TestMethod]
		public async Task TestUpdatePollTitleMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var updatePollTitleDTO = new UpdatePollTitleDTO() { Title = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.UpdatePollTitleAsync(updatePollTitleDTO, 1);
			});
		}
	}
}
