using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	[TestClass]
	public class UpdateQuestionSectionDescriptionAsyncTests : QuestionSectionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionSectionService = new QuestionSectionService(Mapper, DbContext);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionSectionDescriptionAsync_GivenValidInput_ShouldBePassed()
		{
			int sectionId = 1;
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: sectionId));


			var updateSection = new UpdateQuestionSectionDescriptionDTO
			{
				Description = "description new",
			};

			var result = await QuestionSectionService.UpdateQuestionSectionDescriptionAsync(sectionId, updateSection);
			var expected = ModelsForQuestionSectionsTests.GetQuestionSectionDTOModel(description: "description new");

			Assert.AreEqual(0, new QuestionSectionDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TesUpdateQuestionSectionDescriptionMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var updateSectionDescriptionDTO = new UpdateQuestionSectionDescriptionDTO() { Description = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionSectionService.UpdateQuestionSectionDescriptionAsync(1, updateSectionDescriptionDTO);
			});
		}
	}
}
