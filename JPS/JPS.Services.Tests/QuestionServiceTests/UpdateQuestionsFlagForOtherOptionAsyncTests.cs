using JPS.API.ViewModels.Enums;
using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JPS.Services.DTO.DTOs.AnswerDTOs;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class UpdateQuestionsFlagForOtherOptionAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionFlagForOtherOptionAsync_GivenValidInput_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			await AddItems(DbContext, questionEntity);
			var updateQuestionCanHaveOtherOptionDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			var actualQuestionDTO = await QuestionService
				.UpdateQuestionsFlagForOtherOptionAsync(1, updateQuestionCanHaveOtherOptionDTO);
			var expectedQuestionDTO = GetExpectedQuestionDTO();

			Assert.AreEqual(
				0,
				new QuestionDTOComparer().Compare(expectedQuestionDTO, actualQuestionDTO)
			);
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_GivenNotExistingQuestionId_ShouldThrowException()
		{
			var question = GetQuestionEntity();
			await AddItems(DbContext, question);

			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(2, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_QuestionIsAnswered_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.Answers = new List<AnswerEntity> { new AnswerEntity { Id = 1, QuestionId = 1 } };

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_TextQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.Text;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_ParagraphQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.Paragraph;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_DropdownQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.Dropdown;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_FileUploadQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.FileUpload;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_LinearScaleQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.LinearScale;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_ChoiceGridQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.MultipleChoiceGrid;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_CheckBoxGridQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.CheckboxGrid;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_DateQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.Date;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_TimeQuestionCannotHaveOtherOption_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.Time;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_ChoiceQuestionCannotHaveOtherOption_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.MultipleChoice;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			var result = await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(result.CanHaveOtherOption, updateDTO.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestUpdateQuestionsFlagForOtherOptionAsync_CkeckboxQuestionCannotHaveOtherOption_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.QuestionTypeId = (int)QuestionTypes.CheckBoxes;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionCanHaveOtherOptionDTO();

			var result = await QuestionService.UpdateQuestionsFlagForOtherOptionAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(result.CanHaveOtherOption, updateDTO.CanHaveOtherOption);
		}

		private UpdateQuestionCanHaveOtherOptionDTO GetUpdateQuestionCanHaveOtherOptionDTO()
		{
			var updateQuestionCanHaveOtherOptionDTO = new UpdateQuestionCanHaveOtherOptionDTO
			{
				CanHaveOtherOption = true
			};

			return updateQuestionCanHaveOtherOptionDTO;
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
				QuestionTypeId = 3,
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
				CanHaveOtherOption = true,
				Comment = "comment",
				Order = 1,
				QuestionTypeId = 3,
				ImageUrl = "test url",
				VideoUrl = "test url",
				Answers = new List<AnswerDTO>()
			};

			return questionDTO;
		}
	}
}
