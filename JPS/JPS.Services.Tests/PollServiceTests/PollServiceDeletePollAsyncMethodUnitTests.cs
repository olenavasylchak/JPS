using Hangfire;
using Hangfire.MemoryStorage;
using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceDeletePollAsyncMethodUnitTests : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
			GlobalConfiguration.Configuration.UseMemoryStorage();
		}

		[TestMethod]
		public async Task DeleteOption_IntegrationTest()
		{
			int pollId = 1;

			await AddItems(DbContext, ModelsForPollTests.GetPollEntityModel(id: pollId));

			await PollService.DeletePollAsync(pollId);

			var poll = await DbContext.Options.FindAsync(pollId);

			Assert.IsNull(poll);
		}

		[TestMethod]
		public async Task TestDeletePollMethodIdValidation_GivenNotExistingId_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(id: pollId);
			await AddItems(DbContext, pollEntity);

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.DeletePollAsync(10);
			});
		}

		[TestMethod]
		public async Task TestDeletePollMethodIdValidation_GivenPollWithAnswers_ShouldThrowException()
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

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await PollService.DeletePollAsync(pollId);
			});
		}
	}
}
