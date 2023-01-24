using System;
using JPS.Services.Comparers.OptionComparers;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;

namespace JPS.Services.Tests.OptionServiceTests
{
	[TestClass]
	public class UpdateOptionTextTests : OptionServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionService = new OptionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task UpdateOptionText_IntegrationTest()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());

			var optionId = 1;

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: optionId));

			var optionTextDTO = new UpdateOptionTextDTO
			{
				Text = "new text"
			};

			var expected = ModelsForOptionServiceTests.GetOptionDTOModel(text: "new text");
			var result = await OptionService.UpdateOptionTextAsync(optionId, optionTextDTO);

			Assert.AreEqual(0, new OptionDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestUpdateOptionTextMethod_GivenNotExistingOptionId_ShouldThrowException()
		{
			var updateOptionTextDTO = new UpdateOptionTextDTO { Text = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionService.UpdateOptionTextAsync(1, updateOptionTextDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionTextMethod_GivenQuestionWithAnswers_ShouldThrowException()
		{
			await AddItems(DbContext, new AnswerEntity { QuestionId = 1 });
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());

			var updateOptionTextDTO = new UpdateOptionTextDTO { Text = "test" };

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionTextAsync(1, updateOptionTextDTO);
			});
		}
	}
}
