using System;
using JPS.Services.Comparers.OptionComparers;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Tests.OptionRowServiceTests;

namespace JPS.Services.Tests.OptionServiceTests
{
	[TestClass]
	public class UpdateOptionImageTests : OptionServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionService = new OptionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task UpdateOptionImage_IntegrationTest()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());

			var optionId = 1;

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());

			var optionImageDTO = new UpdateOptionImageDTO()
			{
				ImageUrl = "new url"
			};

			var expected = ModelsForOptionServiceTests.GetOptionDTOModel(imageUrl: "new url");
			var result = await OptionService.UpdateOptionImageAsync(optionId, optionImageDTO);

			Assert.AreEqual(0, new OptionDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestUpdateOptionImageMethod_GivenNotExistingOptionId_ShouldThrowException()
		{
			var updateOptionImageDTO = new UpdateOptionImageDTO { ImageUrl = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionService.UpdateOptionImageAsync(1, updateOptionImageDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionImageMethod_GivenQuestionWithAnswers_ShouldThrowException()
		{
			await AddItems(DbContext, new AnswerEntity { QuestionId = 1 });
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());

			var updateOptionImageDTO = new UpdateOptionImageDTO { ImageUrl = "test" };

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionImageAsync(1, updateOptionImageDTO);
			});
		}
	}
}
