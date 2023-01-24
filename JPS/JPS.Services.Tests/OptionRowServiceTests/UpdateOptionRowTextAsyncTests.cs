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
	public class UpdateOptionRowTextAsyncTests : OptionRowServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionRowService = new OptionRowService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateOptionRowTextAsync_GivenValidInput_ShouldBePassed()
		{
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel());

			var optionRowId = 1;

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: optionRowId));

			var optionRowTextDTO = new UpdateOptionRowTextDTO
			{
				Text = "new text"
			};

			var expected = ModelsForOptionRowTests.GetOptionRowDTOModel(text: "new text");
			var result = await OptionRowService.UpdateOptionRowTextAsync(optionRowTextDTO, optionRowId);

			Assert.AreEqual(0, new OptionRowDTOComparer().Compare(expected, result));
		}

		[TestMethod]
		public async Task TestUpdateOptionRowTextMethod_GivenNotExistingRowId_ShouldThrowException()
		{
			var updateRowTextDTO = new UpdateOptionRowTextDTO { Text = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.UpdateOptionRowTextAsync(updateRowTextDTO, 1);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionRowTextMethod_GivenRowOfPollWithAnswers_ShouldThrowException()
		{
			var questionId = 1;
			var rowId = 1;
			await AddItems(DbContext, new AnswerEntity { QuestionId = questionId });
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: rowId, questionId: questionId));

			var updateRowTextDTO = new UpdateOptionRowTextDTO { Text = "test" };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.UpdateOptionRowTextAsync(updateRowTextDTO, rowId);
			});
		}
	}
}
