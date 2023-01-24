using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	[TestClass]
	public class CreateQuestionSectionAsyncTests : QuestionSectionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionSectionService = new QuestionSectionService(Mapper, DbContext);
		}

		[TestMethod]
		public async Task IntegrationCreateQuestionSectionAsync_GivenValidInput_ShouldBePassed()
		{
			int pollId = 1;
			var poll = new PollEntity { Id = pollId };

			await AddItems(DbContext, poll);

			var createSection = new CreateQuestionSectionDTO
			{
				Title = "title",
				Description = "description",
				Order = 1,
				PollId = pollId
			};

			var result = await QuestionSectionService.CreateQuestionSectionAsync(createSection);
			var expected = ModelsForQuestionSectionsTests.GetQuestionSectionDTOModel();

			Assert.AreEqual(0, new QuestionSectionDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestCreateQuestionSectionMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var createSectionDTO = new CreateQuestionSectionDTO
			{
				Title = "title",
				Description = "description",
				Order = 1,
				PollId = 1
			};

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionSectionService.CreateQuestionSectionAsync(createSectionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateQuestionSectionMethodOrderValidation_GivenDuplicatedOrder_ShouldThrowException()
		{
			var sectionEntity = ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(
				order: 1,
				poll: new PollEntity() { Id = 1 }
				);
			await AddItems(DbContext, sectionEntity);

			var createSectionDTO = new CreateQuestionSectionDTO
			{
				Title = "title",
				Description = "description",
				Order = 1,
				PollId = 1
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionSectionService.CreateQuestionSectionAsync(createSectionDTO);
			});
		}
	}
}
