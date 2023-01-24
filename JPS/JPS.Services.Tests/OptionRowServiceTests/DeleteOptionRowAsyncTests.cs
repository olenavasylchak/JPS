using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.OptionRowServiceTests
{
	[TestClass]
	public class DeleteOptionRowAsyncTests : OptionRowServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionRowService = new OptionRowService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationDeleteOptionRowAsync_GivenValidInput_ShouldBePassed()
		{
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel());

			var optionRowId = 1;

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: optionRowId));

			await OptionRowService.DeleteOptionRowAsync(optionRowId);

			var optionRow = await DbContext.OptionRows.FindAsync(optionRowId);

			Assert.IsNull(optionRow);
		}

		[TestMethod]
		public async Task TestDeleteOptionRowMethod_GivenNotExistingRowId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.DeleteOptionRowAsync(1);
			});
		}

		[TestMethod]
		public async Task TestDeleteOptionRowMethod_GivenRowOfPollWithAnswers_ShouldThrowException()
		{
			var questionId = 1;
			await AddItems(DbContext, new AnswerEntity { QuestionId = questionId });
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(questionId: questionId));

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.DeleteOptionRowAsync(1);
			});
		}
	}
}
