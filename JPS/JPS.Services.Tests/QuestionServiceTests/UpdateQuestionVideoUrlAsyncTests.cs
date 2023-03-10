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
	public class UpdateQuestionVideoUrlAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionVideoUrlAsync_GivenValidInput_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			await AddItems(DbContext, questionEntity);
			var updateQuestionVideoUrlDTO = GetUpdateQuestionVideoDTO();

			var actualQuestionDTO = await QuestionService
				.UpdateQuestionVideoUrlAsync(1, updateQuestionVideoUrlDTO);
			var expectedQuestionDTO = GetExpectedQuestionDTO();

			Assert.AreEqual(
				0,
				new QuestionDTOComparer().Compare(expectedQuestionDTO, actualQuestionDTO)
			);
		}

		[TestMethod]
		public async Task TestUpdateQuestionVideoUrlAsync_GivenNotExistingQuestionId_ShouldThrowException()
		{
			var question = GetQuestionEntity();
			await AddItems(DbContext, question);

			var updateDTO = GetUpdateQuestionVideoDTO();
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.UpdateQuestionVideoUrlAsync(2, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionVideoUrlAsync_QuestionIsAnswered_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.Answers = new List<AnswerEntity> { new AnswerEntity { Id = 1, QuestionId = 1 } };

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionVideoDTO();

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await QuestionService.UpdateQuestionVideoUrlAsync(questionEntity.Id, updateDTO);
			});
		}

		private UpdateQuestionVideoUrlDTO GetUpdateQuestionVideoDTO()
		{
			var updateQuestionVideoUrlDTO = new UpdateQuestionVideoUrlDTO
			{
				VideoUrl = "new url"
			};

			return updateQuestionVideoUrlDTO;
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
				ImageUrl = "test url",
				VideoUrl = "new url",
				Answers = new List<AnswerDTO>()
			};

			return questionDTO;
		}
	}
}
