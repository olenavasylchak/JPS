using System.Collections.Generic;
using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using JPS.Services.DTO.DTOs.AnswerDTOs;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class UpdateQuestionImageUrlAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionImageUrlAsync_GivenValidInput_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			await AddItems(DbContext, questionEntity);
			var updateQuestionImageUrlDTO = GetUpdateQuestionImageDTO();

			var actualQuestionDTO = await QuestionService
				.UpdateQuestionImageUrlAsync(1, updateQuestionImageUrlDTO);
			var expectedQuestionDTO = GetExpectedQuestionDTO();

			Assert.AreEqual(
				0,
				new QuestionDTOComparer().Compare(expectedQuestionDTO, actualQuestionDTO)
			);
		}

		[TestMethod]
		public async Task TestUpdateQuestionImageUrlAsync_GivenNotExistingQuestionId_ShouldThrowException()
		{
			var question = GetQuestionEntity();
			await AddItems(DbContext, question);

			var updateDTO = GetUpdateQuestionImageDTO();
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.UpdateQuestionImageUrlAsync(2, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionImageUrlAsync_QuestionIsAnswered_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.Answers = new List<AnswerEntity> { new AnswerEntity { Id = 1, QuestionId = 1 } };

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionImageDTO();

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await QuestionService.UpdateQuestionImageUrlAsync(questionEntity.Id, updateDTO);
			});
		}

		private UpdateQuestionImageUrlDTO GetUpdateQuestionImageDTO()
		{
			var updateQuestionImageUrlDTO = new UpdateQuestionImageUrlDTO
			{
				ImageUrl = "new url"
			};

			return updateQuestionImageUrlDTO;
		}

		private QuestionEntity GetQuestionEntity()
		{
			var questionEntity = new QuestionEntity
			{
				Text = "test text",
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "comment",
				Order = 1,
				QuestionTypeId = 6,
				ImageUrl = "test url",
				VideoUrl = "test url"
			};

			return questionEntity;
		}

		private QuestionDTO GetExpectedQuestionDTO()
		{
			var questionDTO = new QuestionDTO()
			{
				Id = 1,
				Text = "test text",
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "comment",
				Order = 1,
				QuestionTypeId = 6,
				ImageUrl = "new url",
				VideoUrl = "test url",
				Answers = new List<AnswerDTO>()
			};

			return questionDTO;
		}
	}
}
