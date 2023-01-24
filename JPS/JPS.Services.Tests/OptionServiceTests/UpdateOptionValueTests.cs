using System;
using JPS.Services.Comparers.OptionComparers;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using JPS.Domain.Entities.Entities;
using JPS.Services.Enums;
using JPS.Services.Exceptions;

namespace JPS.Services.Tests.OptionServiceTests
{
	[TestClass]
	public class UpdateOptionValueTests : OptionServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionService = new OptionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task UpdateOptionValue_IntegrationTest()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(questionTypeId: 7));

			var optionId = 1;

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: optionId, value: 1));

			var optionValueDTO = new UpdateOptionValueDTO()
			{
				Value = 5
			};

			var expected = ModelsForOptionServiceTests.GetOptionDTOModel(value: 5);
			var result = await OptionService.UpdateOptionValueAsync(optionId, optionValueDTO);

			Assert.AreEqual(0, new OptionDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestUpdateOptionValueMethod_GivenNotExistingOptionId_ShouldThrowException()
		{
			var updateOptionValueDTO = new UpdateOptionValueDTO { Value = 1 };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionService.UpdateOptionValueAsync(1, updateOptionValueDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionValueMethod_GivenQuestionWithAnswers_ShouldThrowException()
		{
			await AddItems(DbContext, new AnswerEntity { QuestionId = 1 });
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());

			var updateOptionValueDTO = new UpdateOptionValueDTO { Value = 1 };

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionValueAsync(1, updateOptionValueDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionValueMethod_GivenWrongQuestionType_ShouldThrowException()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(
				questionTypeId: (int)QuestionTypes.Dropdown
				));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());

			var updateOptionValueDTO = new UpdateOptionValueDTO { Value = 1 };

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionValueAsync(1, updateOptionValueDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionValueMethod_GivenDuplicatedValues_ShouldThrowException()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(
				questionTypeId: (int)QuestionTypes.LinearScale
			));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id:1, value:1));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id:2, value: 2));

			var updateOptionValueDTO = new UpdateOptionValueDTO { Value = 2 };

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionValueAsync(1, updateOptionValueDTO);
			});
		}
	}
}
