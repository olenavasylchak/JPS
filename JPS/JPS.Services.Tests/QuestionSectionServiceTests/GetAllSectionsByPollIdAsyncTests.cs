using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	[TestClass]
	public class GetAllSectionsByPollIdAsyncTests : QuestionSectionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionSectionService = new QuestionSectionService(Mapper, DbContext);
		}

		[TestMethod]
		public async Task IntegrationTestGetAllSectionsByPollIdAsync_GivenValidInput_ShouldBePassed()
		{
			int pollId = 1;
			var poll = new PollEntity { Id = pollId };

			await AddItems(DbContext, poll);
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 1, order: 1));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 2, order: 2));

			var expectedListOfSections = GetExpectedListOfSections();
			var realListOfSections = await QuestionSectionService.GetAllSectionsByPollIdAsync(pollId);

			var result = realListOfSections.Zip(expectedListOfSections, (first, second) =>
				new QuestionSectionDTOComparer().Compare(first, second)).Any(x => x != 0);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public async Task TestGetAllSectionsByPollIdMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionSectionService.GetAllSectionsByPollIdAsync(1);
			});
		}

		private IEnumerable<QuestionSectionDTO> GetExpectedListOfSections()
		{
			var listOfSections = new List<QuestionSectionDTO>
			{
				new QuestionSectionDTO { Id = 1, PollId =1, Description="description", Order=1, Title ="title"},
				new QuestionSectionDTO { Id = 2, PollId =1, Description="description", Order=2, Title ="title"}
			};
			return listOfSections;
		}
	}
}
