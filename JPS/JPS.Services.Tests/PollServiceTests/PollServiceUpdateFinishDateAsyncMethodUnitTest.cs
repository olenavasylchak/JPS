using Hangfire;
using Hangfire.MemoryStorage;
using JPS.Services.Comparers;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceUpdateFinishDateAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
			GlobalConfiguration.Configuration.UseMemoryStorage();
		}

		[TestMethod]
		public async Task UpdatePollFinishDate_IntegrationTest()
		{
			var pollId = 1;
			var startsAt = DateTimeOffset.Now.AddDays(10);

			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				startsAt: startsAt,
				finishesAt: DateTimeOffset.Now.AddDays(15));

			await AddItems(DbContext, pollEntity);

			var updatePollFinishDateDTO = new UpdatePollFinishDateDTO
			{
				FinishesAt = DateTimeOffset.Now.AddDays(11)
			};

			var expectedPoll = ModelsForPollTests.GetPollDTOModel(
				id: pollId,
				startsAt: startsAt,
				finishesAt: updatePollFinishDateDTO.FinishesAt);

			var pollDTO = await PollService.UpdatePollFinishDateAsync(updatePollFinishDateDTO, pollId);

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPoll, pollDTO));
		}

		[TestMethod]
		public async Task TestUpdatePollFinishDateMethodStartAtValidation_GivenDateEarlierThanPollStartDate_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				startsAt: DateTimeOffset.Now.AddDays(10),
				finishesAt: DateTimeOffset.Now.AddDays(15));
			await AddItems(DbContext, pollEntity);

			var updatePollFinishDateDTO = new UpdatePollFinishDateDTO() { FinishesAt = DateTimeOffset.Now.AddDays(5) };

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await PollService.UpdatePollFinishDateAsync(updatePollFinishDateDTO, pollId);
			});
		}

		[TestMethod]
		public async Task TestUpdatePollFinishDateMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var updatePollFinishDateDTO = new UpdatePollFinishDateDTO() { FinishesAt = DateTimeOffset.Now.AddDays(1) };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.UpdatePollFinishDateAsync(updatePollFinishDateDTO, 1);
			});
		}
	}
}
