using JPS.Domain.Entities.Entities;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.OptionServiceTests
{
	[TestClass]
	public class DeleteOptionTests : OptionServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionService = new OptionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task DeleteOption_IntegrationTest()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());

			var optionId = 1;

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());

			await OptionService.DeleteOptionAsync(optionId);

			var option = await DbContext.Options.FindAsync(optionId);

			Assert.IsNull(option);
		}

		[TestMethod]
		public async Task TestDeleteOptionMethod_GivenNotExistingRowId_ShouldThrowException()
		{
			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionService.DeleteOptionAsync(1);
			});
		}

		[TestMethod]
		public async Task TestDeleteOptionMethod_GivenRowOfPollWithAnswers_ShouldThrowException()
		{
			var questionId = 1;
			await AddItems(DbContext, new AnswerEntity { QuestionId = questionId });
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(questionId: questionId));

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.DeleteOptionAsync(1);
			});
		}
	}
}
