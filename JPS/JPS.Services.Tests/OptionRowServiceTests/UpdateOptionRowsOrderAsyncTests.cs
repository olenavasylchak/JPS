using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.OptionRowComparers;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.OptionRowServiceTests
{
	[TestClass]
	public class UpdateOptionRowsOrderAsyncTests : OptionRowServiceTestBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionRowService = new OptionRowService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task IntegrationUpdateOptionRowsOrderAsync_GivenValidInput_ShouldBePassed()
		{
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel());

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: 1, order: 1));

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: 2, order: 2));

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: 3, order: 3));

			IEnumerable<UpdateOptionRowOrderDTO> updateOrdersDTO = new List<UpdateOptionRowOrderDTO>
			{
				new UpdateOptionRowOrderDTO
				{
					Id = 1,
					Order = 3
				},
				new UpdateOptionRowOrderDTO
				{
					Id = 2,
					Order = 1
				},
				new UpdateOptionRowOrderDTO
				{
					Id = 3,
					Order = 2
				}
			};

			IEnumerable<OptionRowDTO> expectedDTO = new List<OptionRowDTO>
			{
				ModelsForOptionRowTests.GetOptionRowDTOModel(id: 1, order: 3),
				ModelsForOptionRowTests.GetOptionRowDTOModel(id: 2, order: 1),
				ModelsForOptionRowTests.GetOptionRowDTOModel(id: 3, order: 2),
			};

			var resultDTO = await OptionRowService.UpdateOptionRowsOrderAsync(updateOrdersDTO);
			var result = resultDTO.Zip(expectedDTO, (first, second) => new OptionRowDTOComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public async Task TestUpdateOptionRowsOrder_GivenDuplicatedRowId_ShouldThrowException()
		{
			var updateRowOrderDTOs = new List<UpdateOptionRowOrderDTO>
			{
				new UpdateOptionRowOrderDTO { Id=1, Order = 1},
				new UpdateOptionRowOrderDTO { Id=1, Order = 2}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionRowService.UpdateOptionRowsOrderAsync(updateRowOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionRowsOrder_GivenDuplicatedOrders_ShouldThrowException()
		{
			var updateRowOrderDTOs = new List<UpdateOptionRowOrderDTO>
			{
				new UpdateOptionRowOrderDTO { Id=1, Order = 1},
				new UpdateOptionRowOrderDTO { Id=2, Order = 1}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionRowService.UpdateOptionRowsOrderAsync(updateRowOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionRowOrderMethod_GivenNotExistingRowId_ShouldThrowException()
		{
			var updateRowOrderDTOs = new List<UpdateOptionRowOrderDTO>
			{
				new UpdateOptionRowOrderDTO { Id=1, Order = 1},
				new UpdateOptionRowOrderDTO { Id=2, Order = 2}
			};

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionRowService.UpdateOptionRowsOrderAsync(updateRowOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionRowOrderMethod_GivenRowOfPollWithAnswers_ShouldThrowException()
		{
			var questionId = 1;
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel(id: questionId));
			await AddItems(DbContext, new AnswerEntity { QuestionId = questionId });
			await AddItems(DbContext,
				ModelsForOptionRowTests.GetOptionRowEntityModel(id: 1, questionId: questionId));
			await AddItems(DbContext,
				ModelsForOptionRowTests.GetOptionRowEntityModel(id: 2, questionId: questionId));

			var updateRowOrderDTOs = new List<UpdateOptionRowOrderDTO>
			{
				new UpdateOptionRowOrderDTO { Id=1, Order = 1},
				new UpdateOptionRowOrderDTO { Id=2, Order = 2}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionRowService.UpdateOptionRowsOrderAsync(updateRowOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionRowOrders_GivenNotAllRowsBelongOneQuestion_ShouldThrowException()
		{
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel(id: 1));
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel(id: 2));

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(
				id: 1, order: 1, questionId: 1));
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(
				id: 2, order: 2, questionId: 1));
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(
				id: 3, order: 1, questionId: 2));
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(
				id: 4, order: 3, questionId: 1));

			var updateRowOrderDTOs = new List<UpdateOptionRowOrderDTO>
		   {
				new UpdateOptionRowOrderDTO { Id=1, Order = 1},
				new UpdateOptionRowOrderDTO { Id=2, Order = 2},
				new UpdateOptionRowOrderDTO { Id=3, Order = 3}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionRowService.UpdateOptionRowsOrderAsync(updateRowOrderDTOs);
			});
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateOptionRowOrdersData), DynamicDataSourceType.Method)]
		public async Task TestRowOrders_ShouldThrowException
			(
				string displayName,
				List<UpdateOptionRowOrderDTO> updateOptionRowOrderDTOs
			)
		{

			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel(id: 1));
			await AddItems(DbContext, ModelsForOptionRowTests.GetQuestionEntityModel(id: 2));

			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel());
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: 2, order: 2));
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: 3, order: 3));
			await AddItems(DbContext, ModelsForOptionRowTests.GetOptionRowEntityModel(id: 4, questionId: 2));

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionRowService.UpdateOptionRowsOrderAsync(updateOptionRowOrderDTOs);
			});
		}

		private static IEnumerable<object[]> GetTestUpdateOptionRowOrdersData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateOptionRowOrders_GivenLessRowsThanInPoll_ShouldThrowException",
				new List<UpdateOptionRowOrderDTO>
				{
					new UpdateOptionRowOrderDTO { Id=1, Order = 1},
					new UpdateOptionRowOrderDTO { Id=2, Order = 2}
				}
			};
			yield return new object[]
			{
				"Test case 2: UpdateOptionRowOrders_GivenMoreRowsThanInPoll_ShouldThrowException",
				new List<UpdateOptionRowOrderDTO>
				{
					new UpdateOptionRowOrderDTO { Id=1, Order = 1},
					new UpdateOptionRowOrderDTO { Id=2, Order = 2},
					new UpdateOptionRowOrderDTO { Id=3, Order = 3},
					new UpdateOptionRowOrderDTO { Id=4, Order = 4}
				}
			};
		}
	}
}
