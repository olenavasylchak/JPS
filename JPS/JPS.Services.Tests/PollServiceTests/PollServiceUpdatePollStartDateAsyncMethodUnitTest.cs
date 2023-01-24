using Hangfire;
using Hangfire.MemoryStorage;
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
	public class PollServiceUpdatePollStartDateAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
			GlobalConfiguration.Configuration.UseMemoryStorage();
		}

		[TestMethod]
		public async Task UpdatePollStartDate_IntegrationTest()
		{
			var pollId = 1;
			var finishesAt = DateTimeOffset.Now.AddDays(10);

			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				startsAt: DateTimeOffset.Now.AddDays(5),
				finishesAt: finishesAt);

			await AddItems(DbContext, pollEntity);

			var updatePollStartDateDTO = new UpdatePollStartDateDTO
			{
				StartsAt = DateTimeOffset.Now.AddDays(8)
			};

			var expectedPoll = ModelsForPollTests.GetPollDTOModel(
				id: pollId,
				startsAt: updatePollStartDateDTO.StartsAt,
				finishesAt: finishesAt);

			var pollDTO = await PollService.UpdatePollStartDateAsync(updatePollStartDateDTO, pollId);

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPoll, pollDTO));
		}

		[TestMethod]
		public async Task TestUpdatePollStartDateMethod_PollHasStarted_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				startsAt: DateTimeOffset.Now.AddDays(-10));
			await AddItems(DbContext, pollEntity);

			var updatePollStartDateDTO = new UpdatePollStartDateDTO() { StartsAt = DateTimeOffset.Now.AddDays(10) };

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await PollService.UpdatePollStartDateAsync(updatePollStartDateDTO, pollId);
			});
		}

		[TestMethod]
		public async Task TestUpdatePollStartDateMethodStartAtValidation_GivenDateLaterThanPollFinishDate_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				startsAt: DateTimeOffset.Now.AddDays(-10),
				finishesAt: DateTimeOffset.Now.AddDays(10));
			await AddItems(DbContext, pollEntity);

			var updatePollStartDateDTO = new UpdatePollStartDateDTO() { StartsAt = DateTimeOffset.Now.AddDays(20) };

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await PollService.UpdatePollStartDateAsync(updatePollStartDateDTO, pollId);
			});
		}

		[TestMethod]
		public async Task TestUpdatePollStartDateMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var updatePollStartDateDTO = new UpdatePollStartDateDTO() { StartsAt = DateTimeOffset.Now.AddDays(1) };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.UpdatePollStartDateAsync(updatePollStartDateDTO, 1);
			});
		}
	}
}
