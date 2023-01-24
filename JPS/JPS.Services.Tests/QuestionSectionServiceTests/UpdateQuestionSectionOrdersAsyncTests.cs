using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.QuestionSectionServiceTests
{
	[TestClass]
	public class UpdateQuestionSectionOrdersAsyncTests : QuestionSectionServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			QuestionSectionService = new QuestionSectionService(Mapper, DbContext);
		}

		[TestMethod]
		public async Task IntegrationUpdateQuestionSectionOrdersAsync_GivenValidInput_ShouldBePassed()
		{
			int pollId = 1;
			var poll = new PollEntity { Id = pollId };

			await AddItems(DbContext, poll);

			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 1, order: 1));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 2, order: 2));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 3, order: 3));

			IEnumerable<UpdateQuestionSectionOrderDTO> updateOrderDTOs = new List<UpdateQuestionSectionOrderDTO>
			{
				new UpdateQuestionSectionOrderDTO
				{
					Id = 1,
					Order =3
				},
				new UpdateQuestionSectionOrderDTO
				{
					Id = 2,
					Order =1
				},
				new UpdateQuestionSectionOrderDTO
				{
					Id = 3,
					Order =2
				},
			};

			IEnumerable<QuestionSectionDTO> expectedDTO = new List<QuestionSectionDTO>
			{
					ModelsForQuestionSectionsTests.GetQuestionSectionDTOModel(id: 1, order: 3),
					ModelsForQuestionSectionsTests.GetQuestionSectionDTOModel(id: 2, order: 1),
					ModelsForQuestionSectionsTests.GetQuestionSectionDTOModel(id: 3, order: 2),
			};

			var resultDTO = await QuestionSectionService.UpdateQuestionSectionOrdersAsync(updateOrderDTOs);
			var result = resultDTO.Zip(expectedDTO, (first, second) => new QuestionSectionDTOComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public async Task TestUpdateQuestionSectionOrders_GivenDuplicatedSectionId_ShouldThrowException()
		{
			var updateSectionOrderDTO = new List<UpdateQuestionSectionOrderDTO>
			{
				new UpdateQuestionSectionOrderDTO { Id=1, Order = 1},
				new UpdateQuestionSectionOrderDTO { Id=1, Order = 2}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionSectionService.UpdateQuestionSectionOrdersAsync(updateSectionOrderDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionSectionOrders_GivenDuplicatedOrder_ShouldThrowException()
		{
			var updateSectionOrderDTO = new List<UpdateQuestionSectionOrderDTO>
			{
				new UpdateQuestionSectionOrderDTO { Id=1, Order = 1},
				new UpdateQuestionSectionOrderDTO { Id=2, Order = 1}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionSectionService.UpdateQuestionSectionOrdersAsync(updateSectionOrderDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionSectionOrders_GivenNotExistingSectionId_ShouldThrowException()
		{
			var updateSectionOrderDTO = new List<UpdateQuestionSectionOrderDTO>
			{
				new UpdateQuestionSectionOrderDTO { Id=1, Order = 1},
				new UpdateQuestionSectionOrderDTO { Id=2, Order = 2}
			};

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await QuestionSectionService.UpdateQuestionSectionOrdersAsync(updateSectionOrderDTO);
			});
		}

		[TestMethod]
		public async Task TestUpdateQuestionSectionOrders_GivenNotAllSectionsBelongOnePoll_ShouldThrowException()
		{
			await AddItems(DbContext, new PollEntity { Id = 1 });
			await AddItems(DbContext, new PollEntity { Id = 2 });

			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(
				id: 1, order: 1, pollId: 1));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(
				id: 2, order: 2, pollId: 1));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(
				id: 3, order: 1, pollId: 2));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(
				id: 4, order: 3, pollId: 1));

			var updateSectionOrderDTO = new List<UpdateQuestionSectionOrderDTO>
			{
				new UpdateQuestionSectionOrderDTO { Id=1, Order = 1},
				new UpdateQuestionSectionOrderDTO { Id=2, Order = 2},
				new UpdateQuestionSectionOrderDTO { Id=3, Order = 3}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionSectionService.UpdateQuestionSectionOrdersAsync(updateSectionOrderDTO);
			});
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateSectionOrdersData), DynamicDataSourceType.Method)]
		public async Task TestUpdateSectionOrders_ShouldThrowException
			(
				string displayName,
				List<UpdateQuestionSectionOrderDTO> updateSectionOrderDTO
			)
		{
			await AddItems(DbContext, new PollEntity { Id = 1 });
			await AddItems(DbContext, new PollEntity { Id = 2 });

			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 1, order: 1));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 2, order: 2));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 3, order: 3));
			await AddItems(DbContext, ModelsForQuestionSectionsTests.GetQuestionSectionEntityModel(id: 4, pollId:2));

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await QuestionSectionService.UpdateQuestionSectionOrdersAsync(updateSectionOrderDTO);
			});
		}

		private static IEnumerable<object[]> GetTestUpdateSectionOrdersData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateQuestionSectionOrders_GivenLessSectionsThanInPoll_ShouldThrowException",
				new List<UpdateQuestionSectionOrderDTO>
				{
					new UpdateQuestionSectionOrderDTO { Id=1, Order = 1},
					new UpdateQuestionSectionOrderDTO { Id=2, Order = 2}
				}
			};
			yield return new object[]
			{
				"Test case 2: UpdateQuestionSectionOrders_GivenMoreSectionsThanInPoll_ShouldThrowException",
				new List<UpdateQuestionSectionOrderDTO>
				{
					new UpdateQuestionSectionOrderDTO { Id=1, Order = 1},
					new UpdateQuestionSectionOrderDTO { Id=2, Order = 2},
					new UpdateQuestionSectionOrderDTO { Id=3, Order = 3},
					new UpdateQuestionSectionOrderDTO { Id=4, Order = 4}
				}
			};
		}
	}
}
