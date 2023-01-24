using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceUpdatePollIsAnonymousAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task UpdatePollIsAnonymous_IntegrationTests()
		{
			var pollEntity = ModelsForPollTests.GetPollEntityModel(isAnonymous: false);

			await AddItems(DbContext, pollEntity);

			var updatePollTitleDTO = new UpdatePollIsAnonymousDTO() { IsAnonymous = true };

			var resultPoll = await PollService.UpdatePollIsAnonymousAsync(updatePollTitleDTO, 1);

			var expectedPoll = ModelsForPollTests.GetPollDTOModel(isAnonymous: true);

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPoll, resultPoll));
		}

		[TestMethod]
		public async Task TestUpdatePollIsAnonymousMethodIdValidation_GivenPollWithAnswers_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(
				id: pollId,
				questionSections:
					new List<QuestionSectionEntity>{ ModelsForPollTests.GetQuestionSectionEntityModel(
						questions:
							new List<QuestionEntity>{ ModelsForPollTests.GetQuestionEntityModel(
								answers:
									new List<AnswerEntity> {
										new AnswerEntity { Id = 1, UserId = "1", QuestionId = 1 }
									})
							})
					}
				);
			await AddItems(DbContext, pollEntity);

			var updatePollIsAnonymousDTO = new UpdatePollIsAnonymousDTO() { IsAnonymous = false };

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await PollService.UpdatePollIsAnonymousAsync(updatePollIsAnonymousDTO, pollId);
			});
		}

		[TestMethod]
		public async Task TestUpdatePollStartDateMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var updatePollIsAnonymousDTO = new UpdatePollIsAnonymousDTO() { IsAnonymous = false };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.UpdatePollIsAnonymousAsync(updatePollIsAnonymousDTO, 1);
			});
		}
	}
}
