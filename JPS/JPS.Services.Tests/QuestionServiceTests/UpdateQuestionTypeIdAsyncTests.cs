using JPS.API.ViewModels.Enums;
using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionServiceTests
{
	[TestClass]
	public class UpdateQuestionTypeIdAsyncTests : QuestionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionService = new QuestionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionTypeIdAsync_GivenValidInput_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity();
			await AddItems(DbContext, questionEntity);
			var updateQuestionTypeIdDTO = GetUpdateQuestionTypeIdDTO();

			var actualQuestionDTO = await QuestionService
				.UpdateQuestionTypeIdAsync(1, updateQuestionTypeIdDTO);
			var expectedQuestionDTO = GetExpectedQuestionDTO();

			Assert.AreEqual(
				0,
				new QuestionDTOComparer().Compare(expectedQuestionDTO, actualQuestionDTO)
			);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_GivenNotExistingQuestionId_ShouldThrowException()
		{
			var question = GetQuestionEntity();
			await AddItems(DbContext, question);

			var updateDTO = GetUpdateQuestionTypeIdDTO();
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionService.UpdateQuestionTypeIdAsync(2, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_QuestionIsAnswered_ShouldThrowException()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.Answers = new List<AnswerEntity> { new AnswerEntity { Id = 1, QuestionId = 1 } };

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();

			await Assert.ThrowsExceptionAsync<NotAllowed>(async () =>
			{
				await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);
			});
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToTextType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.LinearScale);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text", Value = 1} };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Text;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
			Assert.AreEqual(0, updatedQuestion.Options.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToParagraphType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.CheckBoxes);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Paragraph;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
			Assert.AreEqual(0, updatedQuestion.Options.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToChoiceType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.MultipleChoiceGrid);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };
			questionEntity.OptionRows = new List<OptionRowEntity> { new OptionRowEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.MultipleChoice;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToCheckboxType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.CheckboxGrid);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };
			questionEntity.OptionRows = new List<OptionRowEntity> { new OptionRowEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.CheckBoxes;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToDropdownType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.CheckboxGrid);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };
			questionEntity.OptionRows = new List<OptionRowEntity> { new OptionRowEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Dropdown;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToFileType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.CheckboxGrid);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };
			questionEntity.OptionRows = new List<OptionRowEntity> { new OptionRowEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.FileUpload;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
			Assert.AreEqual(0, updatedQuestion.Options.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToLinearScaleType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.CheckboxGrid);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };
			questionEntity.OptionRows = new List<OptionRowEntity> { new OptionRowEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.LinearScale;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
			Assert.AreEqual(0, updatedQuestion.Options.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToDateType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.Dropdown);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Date;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
			Assert.AreEqual(0, updatedQuestion.Options.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToTimeType_ShouldBePassed()
		{
			var questionEntity = GetQuestionEntity((int)QuestionTypes.MultipleChoiceGrid);
			questionEntity.Options = new List<OptionEntity> { new OptionEntity { Id = 1, Text = "text" } };
			questionEntity.OptionRows = new List<OptionRowEntity> { new OptionRowEntity { Id = 1, Text = "text" } };

			await DbContext.Questions.AddAsync(questionEntity);
			await DbContext.SaveChangesAsync();
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Time;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			Assert.AreEqual(0, updatedQuestion.OptionRows.Count());
			Assert.AreEqual(0, updatedQuestion.Options.Count());
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToTimeType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Time;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToTextType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Text;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToParagraphType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Paragraph;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToDropdownType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Dropdown;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToFileType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.FileUpload;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToLinearScaleType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.LinearScale;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToChoiceGridType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.MultipleChoiceGrid;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToCheckboxGridType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.CheckboxGrid;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		[TestMethod]
		public async Task TestQuestionTypeIdAsyncTests_ChangesToDateType_OtherOptionShouldBeFalse()
		{
			var questionEntity = GetQuestionEntity();
			questionEntity.CanHaveOtherOption = true;
			questionEntity.QuestionTypeId = 3;

			await AddItems(DbContext, questionEntity);
			var updateDTO = GetUpdateQuestionTypeIdDTO();
			updateDTO.QuestionTypeId = (int)QuestionTypes.Date;

			var updatedQuestion = await QuestionService.UpdateQuestionTypeIdAsync(questionEntity.Id, updateDTO);

			var expectedFlag = false;
			Assert.AreEqual(expectedFlag, updatedQuestion.CanHaveOtherOption);
		}

		private UpdateQuestionTypeIdDTO GetUpdateQuestionTypeIdDTO()
		{
			var updateQuestionTypeIdDTO = new UpdateQuestionTypeIdDTO
			{
				QuestionTypeId = 7
			};

			return updateQuestionTypeIdDTO;
		}

		private QuestionEntity GetQuestionEntity(int questionTypeId = 1)
		{
			var questionEntity = new QuestionEntity
			{
				Text = "test text",
				IsRequired = true,
				CanHaveOtherOption = false,
				Comment = "comment",
				Order = 1,
				QuestionTypeId = questionTypeId,
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
				QuestionTypeId = 7,
				ImageUrl = "test url",
				VideoUrl = "test url",
				Options = new List<QuestionOptionDTO>(),
				OptionRows = new List<OptionRowDTO>(),
				Answers = new List<AnswerDTO>()
			};

			return questionDTO;
		}
	}
}
