using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.OptionRowComparers;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.OptionRowServiceTests
{
	[TestClass]
	public class UpdateOptionRowImageAsyncTests : OptionRowServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionRowService = new OptionRowService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateOptionRowImageAsync_GivenValidInput_ShouldBePassed()
		{
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel());

			var optionRowId = 1;

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: optionRowId));

			var optionRowImageDTO = new UpdateOptionRowImageDTO()
			{
				ImageUrl = "new url"
			};

			var expected = ModelsForOptionRowTests.GetOptionRowDTOModel(imageUrl: "new url");
			var result = await OptionRowService.UpdateOptionRowImageAsync(optionRowImageDTO, optionRowId);

			Assert.AreEqual(0, new OptionRowDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestUpdateOptionRowImageMethod_GivenNotExistingRowId_ShouldThrowException()
		{
			var updateRowImageDTO = new UpdateOptionRowImageDTO { ImageUrl = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.UpdateOptionRowImageAsync(updateRowImageDTO, 1);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionRowImageMethod_GivenRowOfPollWithAnswers_ShouldThrowException()
		{
			var questionId = 1;
			var rowId = 1;
			await AddItems(DbContext, new AnswerEntity { QuestionId = questionId });
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: rowId, questionId: questionId));

			var updateRowImageDTO = new UpdateOptionRowImageDTO { ImageUrl = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.UpdateOptionRowImageAsync(updateRowImageDTO, rowId);
			});
		}
	}
}
