using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.OptionComparers;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Tests.OptionServiceTests
{
	[TestClass]
	public class UpdateOptionOrderTests : OptionServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			OptionService = new OptionService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task UpdateOptionOrder_IntegrationTest()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 1, order: 1));

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 2, order: 2));

			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 3, order: 3));

			IEnumerable<UpdateOptionOrderDTO> updateOrdersDTO = new List<UpdateOptionOrderDTO>
			{
				new UpdateOptionOrderDTO
				{
					Id = 1,
					Order = 3
				},
				new UpdateOptionOrderDTO
				{
					Id = 2,
					Order = 1
				},
				new UpdateOptionOrderDTO
				{
					Id = 3,
					Order = 2
				}
			};

			IEnumerable<OptionDTO> expectedDTO = new List<OptionDTO>
			{
				ModelsForOptionServiceTests.GetOptionDTOModel(id: 1, order: 3),
				ModelsForOptionServiceTests.GetOptionDTOModel(id: 2, order: 1),
				ModelsForOptionServiceTests.GetOptionDTOModel(id: 3, order: 2),
			};

			var resultDTO = await OptionService.UpdateOptionsOrderAsync(updateOrdersDTO);
			var result = resultDTO.Zip(expectedDTO, (first, second) => new OptionDTOComparer().Compare(first, second)).Any(x => x != 0);

			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public async Task TestUpdateOptionsOrder_GivenDuplicatedOptionId_ShouldThrowException()
		{
			var updateOptionOrderDTOs = new List<UpdateOptionOrderDTO>
			{
				new UpdateOptionOrderDTO { Id=1, Order = 1},
				new UpdateOptionOrderDTO { Id=1, Order = 2}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionsOrderAsync(updateOptionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionsOrder_GivenDuplicatedOrders_ShouldThrowException()
		{
			var updateOptionOrderDTOs = new List<UpdateOptionOrderDTO>
			{
				new UpdateOptionOrderDTO { Id=1, Order = 1},
				new UpdateOptionOrderDTO { Id=2, Order = 1}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionsOrderAsync(updateOptionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionsOrder_GivenNotExistingOptionId_ShouldThrowException()
		{
			var updateOptionOrderDTOs = new List<UpdateOptionOrderDTO>
			{
				new UpdateOptionOrderDTO { Id=1, Order = 1},
				new UpdateOptionOrderDTO { Id=2, Order = 2}
			};

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await OptionService.UpdateOptionsOrderAsync(updateOptionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionsOrder_GivenQuestionWithAnswers_ShouldThrowException()
		{
			await AddItems(DbContext, new AnswerEntity { QuestionId = 1 });
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 2, order: 2));

			var updateOptionOrderDTOs = new List<UpdateOptionOrderDTO>
			{
				new UpdateOptionOrderDTO { Id=1, Order = 2},
				new UpdateOptionOrderDTO { Id=2, Order = 1}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionsOrderAsync(updateOptionOrderDTOs);
			});
		}

		[TestMethod]
		public async Task TestUpdateOptionsOrder_GivenOptionsBelongsToDifferentQuestions_ShouldThrowException()
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(id: 2));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 2));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 3, questionId: 2));

			var updateOptionOrderDTOs = new List<UpdateOptionOrderDTO>
			{
				new UpdateOptionOrderDTO { Id=1, Order = 2},
				new UpdateOptionOrderDTO { Id=3, Order = 1}
			};

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionsOrderAsync(updateOptionOrderDTOs);
			});
		}

		[DataTestMethod]
		[DynamicData(nameof(GetTestUpdateOptionsOrdersData), DynamicDataSourceType.Method)]
		public async Task TestOptionOrders_ShouldThrowException
		(
			string displayName,
			List<UpdateOptionOrderDTO> updateOptionRowOrderDTOs
		)
		{
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetQuestionEntityModel(id: 2));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel());
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 2, order: 2));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 3, order: 3));
			await AddItems(DbContext, ModelsForOptionServiceTests.GetOptionEntityModel(id: 4, questionId: 2));

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await OptionService.UpdateOptionsOrderAsync(updateOptionRowOrderDTOs);
			});
		}

		private static IEnumerable<object[]> GetTestUpdateOptionsOrdersData()
		{
			yield return new object[]
			{
				"Test case 1: UpdateOptionRowOrders_GivenLessOptionsThanInQuestion_ShouldThrowException",
				new List<UpdateOptionOrderDTO>
				{
					new UpdateOptionOrderDTO { Id=1, Order = 1},
					new UpdateOptionOrderDTO { Id=2, Order = 2}
				}
			};
			yield return new object[]
			{
				"Test case 2: UpdateOptionRowOrders_GivenMoreOptionsThanInQuestion_ShouldThrowException",
				new List<UpdateOptionOrderDTO>
				{
					new UpdateOptionOrderDTO { Id=1, Order = 1},
					new UpdateOptionOrderDTO { Id=2, Order = 2},
					new UpdateOptionOrderDTO { Id=3, Order = 3},
					new UpdateOptionOrderDTO { Id=4, Order = 4}
				}
			};
		}
	}
}
