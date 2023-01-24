using JPS.API.ViewModels.Enums;
using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.OptionRowComparers;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.OptionRowServiceTests
{
	[TestClass]
	public class CreateOptionRowAsyncTests : OptionRowServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionRowService = new OptionRowService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationCreateOptionRowAsync_GivenValidInput_ShouldBePassed()
		{
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel());

			var createOptionRowDTO = new CreateOptionRowDTO
			{
				QuestionId = 1,
				Text = "text",
				ImageUrl = null,
				Order = 1
			};

			var result = await OptionRowService.CreateOptionRowAsync(createOptionRowDTO);
			var expected = ModelsForOptionRowTests.GetOptionRowDTOModel();

			Assert.AreEqual(0, new OptionRowDTOComparer().Compare(expected, result));
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public async Task TestCreateOptionRowMethod_GivenNotExistingQuestionId_ShouldThrowException()
		{
			var createRowDTO = new CreateOptionRowDTO
			{
				QuestionId = 1,
				Text = "test",
				ImageUrl = "test url",
				Order = 1
			};

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.CreateOptionRowAsync(createRowDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionRowMethod_GivenAnsweredQuestionId_ShouldThrowException()
		{
			await AddItems(DbContext, new QuestionEntity
			{
				Id = 1,
				Text = "text",
				QuestionSectionId = 1,
				IsRequired = false,
				QuestionTypeId = 8,
				Answers = new List<AnswerEntity>
				{
					new AnswerEntity
					{
						Id = 1,
						UserId = "userId",
						QuestionId = 1,
						OptionAnswers = new List<OptionAnswerEntity>
						{
							new OptionAnswerEntity
							{ 
								Id = 1,
								OptionId = 1,
								AnswerId = 1,
								OptionRowId = 1
							}
						}
					}
				}
			});

			var createRowDTO = new CreateOptionRowDTO
			{
				QuestionId = 1,
				Text = "test",
				ImageUrl = "test url",
				Order = 1
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionRowService.CreateOptionRowAsync(createRowDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionRowMethod_GivenQuestionWithWrongType_ShouldThrowException()
		{
			var questionId = 1;
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel(
					id: questionId,
					questionTypeId: (int)QuestionTypes.Paragraph
					));

			var createRowDTO = new CreateOptionRowDTO
			{
				QuestionId = questionId,
				Text = "test",
				ImageUrl = "test url",
				Order = 1
			};

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await OptionRowService.CreateOptionRowAsync(createRowDTO);
			});
		}

		[TestMethod]
		public async Task TestCreateOptionRowMethod_GivenDuplicatedOrderRow_ShouldThrowException()
		{
			var questionId = 1;
			var rowOrder = 1;
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel(
					id: questionId,
					questionTypeId: (int)QuestionTypes.MultipleChoiceGrid
					));
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(
					questionId: questionId,
					order: rowOrder
					));

			var createRowDTO = new CreateOptionRowDTO
			{
				QuestionId = questionId,
				Text = "test",
				ImageUrl = "test url",
				Order = rowOrder
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionRowService.CreateOptionRowAsync(createRowDTO);
			});
		}
	}
}
