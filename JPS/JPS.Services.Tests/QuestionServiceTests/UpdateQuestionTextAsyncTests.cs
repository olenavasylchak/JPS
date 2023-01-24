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
	public class UpdateQuestionTextAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionTextAsync_GivenValidInput_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			await AddItems(DbContext, questionEntity);
			var updateQuestionTextDTO = GetUpdateQuestionTextDTO();

			var actualQuestionDTO = await QuestionService
				.UpdateQuestionTextAsync(1, updateQuestionTextDTO);
			var expectedQuestionDTO = GetExpectedQuestionDTO();

			Assert.AreEqual(
				0,
				new QuestionDTOComparer().Compare(expectedQuestionDTO, actualQuestionDTO)
			);
		}

		[TestMethod]
		public async Task TestUpdateQuestionTextAsync_GivenNotExistingQuestionId_ShouldThrowException()
		{
			var question = GetQuestionEntity();
			await AddItems(DbContext, question);

			var updateDTO = GetUpdateQuestionTextDTO();
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.UpdateQuestionTextAsync(2, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionTextAsync_QuestionIsAnswered_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.Answers = new List<AnswerEntity> { new AnswerEntity { Id = 1, QuestionId = 1 } };

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTextDTO();

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await QuestionService.UpdateQuestionTextAsync(questionEntity.Id, updateDTO);
			});
		}

		private UpdateQuestionTextDTO GetUpdateQuestionTextDTO()
		{
			var updateQuestionTextDTO = new UpdateQuestionTextDTO
			{
				Text = "new text"
			};

			return updateQuestionTextDTO;
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
				Text = "new text",
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "comment",
				Order = 1,
				QuestionTypeId = 6,
				ImageUrl = "test url",
				VideoUrl = "test url",
				Answers = new List<AnswerDTO>()
			};

			return questionDTO;
		}
	}
}
