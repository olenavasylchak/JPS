using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceCreatePollAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task CreatePoll_IntegrationTest()
		{
			var categoryId = 1;

			var categoryEntity = ModelsForPollTests.GetCategoryEntityModel(id: categoryId);

			await AddItems(DbContext, categoryEntity);

			var createPollDTO = ModelsForPollTests.GetCreatePollDTOModel(categoryId: categoryId);

			var result = await PollService.CreatePollAsync(createPollDTO);

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public async Task TestCreatePollMethodCategoryIdValidation_GivenNotExistingCategoryId_ShouldThrowException()
		{
			var categoryEntity = ModelsForPollTests.GetCategoryEntityModel(id: 1);
			await AddItems(DbContext, categoryEntity);
			categoryEntity = ModelsForPollTests.GetCategoryEntityModel(id: 2);
			await AddItems(DbContext, categoryEntity);

			var categoryId = 3;
			var createPollDTO = ModelsForPollTests.GetCreatePollDTOModel(categoryId: categoryId);

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.CreatePollAsync(createPollDTO);
			});
		}

		[TestMethod]
		public async Task TestCreatePollMethodDatesValidation_GivenFinishDateEalierThanStartDate_ShouldThrowException()
		{
			var finishDate = new DateTimeOffset(2020, 10, 20, 20, 20, 20, 20, new TimeSpan());
			var createPollDTO = ModelsForPollTests.GetCreatePollDTOModel(
				finishesAt: finishDate,
				startsAt: finishDate.AddDays(5)
				);

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await PollService.CreatePollAsync(createPollDTO);
			});
		}
	}
}
