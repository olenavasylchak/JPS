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
	public class PollServiceUpdatePollDescriptionAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task UpdatePollDescription_IntegrationTests()
		{
			var pollEntity = ModelsForPollTests.GetPollEntityModel();

			await AddItems(DbContext, pollEntity);

			var description = "new";

			var updatePollDescriptionDTO = new UpdatePollDescriptionDTO() { Description = description };

			var resultPoll = await PollService.UpdatePollDescriptionAsync(updatePollDescriptionDTO, 1);

			var expectedPoll = ModelsForPollTests.GetPollDTOModel(description: description);

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPoll, resultPoll));
		}

		[TestMethod]
		public async Task TestUpdatePollDescriptionMethod_PollHasStarted_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				startsAt: DateTimeOffset.Now.AddDays(-10));
			await AddItems(DbContext, pollEntity);

			var updatePollDescriptionDTO = new UpdatePollDescriptionDTO() { Description = "test" };

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await PollService.UpdatePollDescriptionAsync(updatePollDescriptionDTO, pollId);
			});
		}

		[TestMethod]
		public async Task TestUpdatePollDescriptionMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var updatePollDescriptionDTO = new UpdatePollDescriptionDTO() { Description = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.UpdatePollDescriptionAsync(updatePollDescriptionDTO, 1);
			});
		}
	}
}
