using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	[TestClass]
	public class UpdateQuestionSectionTitleAsyncTests : QuestionSectionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionSectionService = new QuestionSectionService(Mapper, DbContext);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionSectionTitleAsync_GivenValidInput_ShouldBePassed()
		{
			int sectionId = 1;
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: sectionId));


			var updateSection = new UpdateQuestionSectionTitleDTO
			{
				Title = "title new",
			};

			var result = await QuestionSectionService.UpdateQuestionSectionTitleAsync(sectionId, updateSection);
			var expected = ModelsForQuestionSectionsTests.GetQuestionSectionDTOModel(title: "title new");

			Assert.AreEqual(0, new QuestionSectionDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestUpdateQuestionSectionTitleMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var updateSectionTitleDTO = new UpdateQuestionSectionTitleDTO() { Title = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionSectionService.UpdateQuestionSectionTitleAsync(1, updateSectionTitleDTO);
			});
		}
	}
}
