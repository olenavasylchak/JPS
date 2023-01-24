using JPS.API.ViewModels.Enums;
using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.OptionServiceTests
{
	[TestClass]
	public class CreateOptionTests : OptionServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionService = new OptionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task CreateOption_IntegrationTest(
		)
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());

			var createOptionDTO = new CreateOptionDTO
			{
				QuestionId = 1,
				Text = "Test text",
				ImageUrl = "Test url",
				Order = 2
			};

			var result = await OptionService.CreateOptionAsync(createOptionDTO);

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public async Task TestCreateOptionMethod_GivenNotExistingQuestionId_ShouldThrowNotFoundException()
		{
			var optionDTO = new CreateOptionDTO
			{
				QuestionId = 1,
				Text = "Test text",
				ImageUrl = "Test url",
				Order = 1
			};

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionService.CreateOptionAsync(optionDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionMethod_GivenQuestionWithWrongType_ShouldThrowException()
		{
			var questionId = 1;
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(
				id: questionId,
				questionTypeId: (int)QuestionTypes.Paragraph
			));

			var createOptionDto = new CreateOptionDTO
			{
				QuestionId = questionId,
				Text = "test",
				ImageUrl = "test url",
				Order = 1
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.CreateOptionAsync(createOptionDto);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionMethod_GivenDuplicatedOrder_ShouldThrowException()
		{
			var questionId = 1;
			var order = 1;

			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(
				id: questionId,
				questionTypeId: (int)QuestionTypes.MultipleChoice
			));

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(
				questionId: questionId,
				order: order
			));

			var createOptionDto = new CreateOptionDTO
			{
				QuestionId = questionId,
				Text = "test",
				ImageUrl = "test url",
				Order = order
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.CreateOptionAsync(createOptionDto);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionMethod_GivenQuestionWithAnswer_ShouldThrowException()
		{
			var questionId = 1;
			var order = 1;
			var answerEntity = new AnswerEntity
			{
				QuestionId = questionId
			};

			await AddItems(DbContext, answerEntity);
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(
				id: questionId,
				questionTypeId: (int)QuestionTypes.MultipleChoice
			));

			var createOptionDto = new CreateOptionDTO
			{
				QuestionId = questionId,
				Text = "test",
				ImageUrl = "test url",
				Order = order
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.CreateOptionAsync(createOptionDto);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionMethod_GivenOptionWithValueAndNotScaleType_ShouldThrowException()
		{
			var questionId = 1;

			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(
				id: questionId,
				questionTypeId: (int)QuestionTypes.MultipleChoice
			));

			var createOptionDto = new CreateOptionDTO
			{
				QuestionId = questionId,
				Text = "test",
				ImageUrl = "test url",
				Order = 1,
				Value = 1
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.CreateOptionAsync(createOptionDto);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionMethod_GivenDuplicatedValues_ShouldThrowException()
		{
			var questionId = 1;
			var order = 1;

			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(
				id: questionId,
				questionTypeId: (int)QuestionTypes.LinearScale
			));

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(
				questionId: questionId,
				order: 2,
				value: 1
			));

			var createOptionDto = new CreateOptionDTO
			{
				QuestionId = questionId,
				Text = "test",
				ImageUrl = "test url",
				Order = order,
				Value = 1
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.CreateOptionAsync(createOptionDto);
			});
		}
	}
}
