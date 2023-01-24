using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	[TestClass]
	public class DeleteQuestionSectionAsyncTests : QuestionSectionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionSectionService = new QuestionSectionService(Mapper, DbContext);
		}

		[TestMethod]
		public async Task IntegrationDeleteQuestionSectionAsync_GivenValidInput_ShouldBePassed()
		{
			int pollId = 1;
			var poll = new PollEntity { Id = pollId };

			await AddItems(DbContext, poll);

			var sectionId = 2;

			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: sectionId));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel());

			await QuestionSectionService.DeleteQuestionSectionAsync(sectionId);

			var section = await DbContext.QuestionSections.FindAsync(sectionId);

			Assert.IsNull(section);
		}

		[TestMethod]
		public async Task TestDeleteQuestionSectionMethodSectionIdValidation_GivenNotExistingSectionId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionSectionService.DeleteQuestionSectionAsync(1);
			});
		}

		[TestMethod]
		public async Task TestDeleteQuestionSectionMethod_GivenSectionWithQuestions_ShouldThrowException()
		{
			var sectionId = 1;
			var sectionEntity = ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(
				id: sectionId,
				poll: new PollEntity(),
				questions: new List<QuestionEntity>()
					{
						ModelsForQuestionSectionsTests.GetQuestionEntityModel(id: 1)
					}
				);
			await AddItems(DbContext, sectionEntity);

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionSectionService.DeleteQuestionSectionAsync(sectionId);
			});
		}

		[TestMethod]
		public async Task TestDeleteQuestionSectionMethod_GivenLastSectionInPoll_ShouldThrowException()
		{
			var sectionId = 1;
			var sectionEntity = ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(
				id: sectionId,
				poll: new PollEntity(),
				questions: new List<QuestionEntity>()
					{
						ModelsForQuestionSectionsTests.GetQuestionEntityModel(id: 1)
					}
				);
			await AddItems(DbContext, sectionEntity);

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionSectionService.DeleteQuestionSectionAsync(sectionId);
			});
		}
	}
}
