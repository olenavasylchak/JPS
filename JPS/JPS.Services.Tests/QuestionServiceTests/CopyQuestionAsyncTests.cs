using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class CopyQuestionAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationTestCopyQuestionAsync_GivenValidInput_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			await AddItems(DbContext, questionEntity);

			var expectedQuestionDTO = GetExpectedQuestionDTO();
			var actualQuestionDTO = await QuestionService.CopyQuestionAsync(1);

			Assert.AreEqual(
				0,
				new QuestionDTOComparer().Compare(expectedQuestionDTO, actualQuestionDTO)
			);
		}

		[TestMethod]
		public async Task TestCopyQuestionAsyncValidation_GivenNotExistingQuestionId_ShouldThrowException()
		{

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.CopyQuestionAsync(10);
			});
		}

		[TestMethod]
		public async Task TestCopyQuestionAsync_CheckCopyQuestionOrder_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.Id = 4;
			questionEntity.Order = 5;
			await AddItems(DbContext, questionEntity);

			var questionDTO = await QuestionService.CopyQuestionAsync(questionEntity.Id);
			var expectedOdrer = 6;

			Assert.AreEqual(expectedOdrer, questionDTO.Order);
		}

		private QuestionEntity GetQuestionEntity()
		{
			var questionEntity = new QuestionEntity
			{
				Text = "text",
				QuestionSectionId = 1,
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "test comment",
				Order = 1,
				QuestionTypeId = 9,
				ImageUrl = "image url",
				VideoUrl = "video url",
				Options = new List<OptionEntity>
				{
					new OptionEntity
					{
						Text = "test option"
					}
				},
				OptionRows = new List<OptionRowEntity>
				{
					new OptionRowEntity
					{
						Text = "test row"
					}
				}
			};

			return questionEntity;
		}

		private QuestionDTO GetExpectedQuestionDTO()
		{
			var questionDTO = new QuestionDTO
			{
				Id = 2,
				Text = "text",
				QuestionSectionId = 1,
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "test comment",
				Order = 2,
				QuestionTypeId = 9,
				ImageUrl = "image url",
				VideoUrl = "video url",
				Options = new List<QuestionOptionDTO>
				{
					new QuestionOptionDTO
					{
						Id = 2,
						Text = "test option"
					}
				},
				OptionRows = new List<OptionRowDTO>
				{
					new OptionRowDTO
					{
						Id = 2,
						Text = "test row",
						QuestionId = 2
					}
				}
			};

			return questionDTO;
		}
	}
}
