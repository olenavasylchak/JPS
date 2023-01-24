using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
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
	public class GetAllSectionsWithQuestionsByPollIdAsyncTests : QuestionSectionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionSectionService = new QuestionSectionService(Mapper, DbContext);
		}

		[TestMethod]
		public async Task IntegrationTestGetAllSectionsWithQuestionsByPollIdAsync_GivenValidInput_ShouldBePassed()
		{
			int pollId = 1;
			var poll = new PollEntity { Id = pollId };

			await AddItems(DbContext, poll);



			var section = ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 1, order: 1,
				questions: new List<QuestionEntity>
				{
					ModelsForQuestionSectionsTests.GetQuestionEntityModel(id:1, questionSectionId:1, order:1)
				});

			await DbContext.QuestionSections.AddAsync(section);
			await DbContext.SaveChangesAsync();

			var expectedListOfSections = GetExpectedListOfSections();
			var realListOfSections = await QuestionSectionService.GetAllSectionsWithQuestionsByPollIdAsync(pollId);

			var result = realListOfSections.Zip(expectedListOfSections, (first, second) =>
				new QuestionSectionDTOComparer().Compare(first, second)).Any(x => x != 0);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public async Task TestGetAllSectionsWithQuestionsByPollIdMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionSectionService.GetAllSectionsWithQuestionsByPollIdAsync(1);
			});
		}

		private IEnumerable<QuestionSectionDTO> GetExpectedListOfSections()
		{
			var listOfSections = new List<QuestionSectionDTO>
			{
				new QuestionSectionDTO { Id = 1, PollId =1, Description="description", Order=1, Title ="title", Questions = new List<QuestionDTO>
				{
					new QuestionDTO {Id=1, QuestionSectionId=1 ,QuestionTypeId=1, Text="text", Comment="comment", Order=1}
				}},
			};
			return listOfSections;
		}
	}
}
