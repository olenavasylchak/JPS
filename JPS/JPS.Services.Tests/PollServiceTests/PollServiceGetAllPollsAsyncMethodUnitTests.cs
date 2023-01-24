using JPS.Common;
using JPS.Services.Comparers;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.PollServiceTests
{
	[TestClass]
	public class PollServiceGetAllPollsAsyncMethodUnitTests : PollServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			PollService = new PollService(DbContext, Mapper, EmailSenderServiceMock.Object);
		}

		[TestMethod]
		public async Task GetAllPolls_IntegrationTest()
		{
			await AddItems(DbContext, ModelsForPollTests.GetCategoryEntityModel(id: 1));
			await AddItems(DbContext, ModelsForPollTests.GetPollEntityModel(id: 1));
			await AddItems(DbContext, ModelsForPollTests.GetPollEntityModel(id: 2));
			await AddItems(DbContext, ModelsForPollTests.GetPollEntityModel(id: 3));
			await AddItems(DbContext, ModelsForPollTests.GetPollEntityModel(id: 4));
			var paginationDTO = ModelsForPollTests.GetPaginationDTO();
			var poll = await PollService.GetAllPollsAsync(1, paginationDTO);
			var expectedPollDTO = new List<PollDTO>
			{
				ModelsForPollTests.GetPollDTOModel(id: 1),
				ModelsForPollTests.GetPollDTOModel(id: 2),
				ModelsForPollTests.GetPollDTOModel(id: 3)
			};

			var totalPages = 2;

			Assert.AreEqual(paginationDTO.PageNumber, poll.CurrentPage);
			Assert.AreEqual(paginationDTO.PageSize, poll.PageSize);
			Assert.AreEqual(totalPages, poll.TotalPages);
			Assert.AreEqual(expectedPollDTO.Count, poll.Data.Count(),
				"Actual amount of polls not equal the amount of the expected polls");

			var comparingResult = expectedPollDTO.Zip(poll.Data,
				(first, second) => new PollDTOComparer().Compare(first, second)).Any(x => x != 0);
			Assert.AreEqual(false, comparingResult);
		}

		[TestMethod]
		public async Task TestGetAllPollsMethodCategoryIdValidation_GivenNotExistingCategoryId_ShouldThrowException()
		{
			var pollEntity = ModelsForPollTests.GetPollEntityModel();
			await AddItems(DbContext, pollEntity);
			var paginationDTO = ModelsForPollTests.GetPaginationDTO();

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
				{
					await PollService.GetAllPollsAsync(10, paginationDTO);
				});
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestCategoryIdData), DynamicDataSourceType.Method)]
		public async Task TestCategoryIdPass
			(
			string displayName,
			int? categoryId
			)
		{
			var pollEntity = ModelsForPollTests.GetPollEntityModel();

			await AddItems(DbContext, pollEntity);
			if (categoryId.HasValue)
			{
				await AddItems(DbContext, ModelsForPollTests.GetCategoryEntityModel(id: categoryId.Value));
			}

			var paginationDTO = ModelsForPollTests.GetPaginationDTO();

			var actualPolls = await PollService.GetAllPollsAsync(categoryId, paginationDTO);

			var queryExpectedPolls = DbContext.Polls.AsQueryable();
			if (categoryId != 0)
			{
				queryExpectedPolls = queryExpectedPolls
					.Where(poll => poll.CategoryId == categoryId);
			}
			var expectedPollEntities = await queryExpectedPolls
				.ToPaginatedCollection(paginationDTO.PageNumber, paginationDTO.PageSize);
			var expectedPolls = Mapper.Map<PagedList<PollDTO>>(expectedPollEntities);

			var result = actualPolls.Data.Zip(expectedPolls.Data, (first, second) => new PollDTOComparer()
			.Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		private static IEnumerable<object[]> GetTestCategoryIdData()
		{
			yield return new object[]
			{
			   "Test case 1: GetAllPolls_GivenNullCategoryIdValue_ShouldBePassed",
			   null
			};
			yield return new object[]
			{
			   "Test case 2: GetAllPolls_GivenPositiveCategoryIdValue_ShouldBePassed",
			   1
			};
			yield return new object[]
			{
			   "Test case 3: GetAllPolls_GivenZeroCategoryIdValue_ShouldBePassed",
			   0
			};
		}
	}
}
