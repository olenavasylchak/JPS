using JPS.Services.Comparers;
using JPS.Services.DTO.DTOs.PollDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceUpdatePollCategoryIdAsyncMethodUnitTest : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task UpdatePollCategoryId_IntegrationTests()
		{
			var categoryId = 1;
			var categoryEntity = ModelsForPollTests.GetCategoryEntityModel(id: categoryId);
			var pollEntity = ModelsForPollTests.GetPollEntityModel(categoryId: null);

			await AddItems(DbContext, categoryEntity);
			await AddItems(DbContext, pollEntity);

			var updatePollCategoryIdDTO = new UpdatePollCategoryIdDTO() { CategoryId = 1 };

			var resultPoll = await PollService.UpdatePollCategoryIdAsync(updatePollCategoryIdDTO, 1);

			var expectedPoll = ModelsForPollTests.GetPollDTOModel(categoryId: 1);

			Assert.AreEqual(0, new PollDTOComparer().Compare(expectedPoll, resultPoll));
		}

		[TestMethod]
		public async Task TestUpdatePollCategoryIdMethodCategoryIdValidation_GivenNotExistingCategoryId_ShouldThrowException()
		{
			var pollId = 1;
			var pollEntity = ModelsForPollTests.GetPollEntityModel(id: pollId);
			await AddItems(DbContext, pollEntity);

			var updatePollCategoryIdDTO = new UpdatePollCategoryIdDTO() { CategoryId = 1 };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.UpdatePollCategoryIdAsync(updatePollCategoryIdDTO, pollId);
			});
		}

		[TestMethod]
		public async Task TestUpdatePollCategoryIdMethodPollIdValidation_GivenNotExistingPollId_ShouldThrowException()
		{
			var categoryId = 1;
			var categoryEntity = ModelsForPollTests.GetCategoryEntityModel(id: categoryId);
			await AddItems(DbContext, categoryEntity);

			var updatePollCategoryIdDTO = new UpdatePollCategoryIdDTO() { CategoryId = 1 };

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await PollService.UpdatePollCategoryIdAsync(updatePollCategoryIdDTO, 1);
			});
		}
	}
}
