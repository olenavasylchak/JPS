using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.CategoryComparers;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.CategoryServiceTests
{
	[TestClass]
	public class CategoryServiceUpdateCategoryParentAsyncTests : CategoryServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			CategoryService = new CategoryService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task UpdateCategoryParent_IntegrationTest()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 2,
				Title = "parent category of category 1",
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 4,
						CategoryId = 2,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "category 1",
				ParentCategoryId = 2,
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 1,
						CategoryId = 1,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			var categoryDTO = GetUpdateCategoryParentDTO();

			var actualCategoryDTO = await CategoryService.UpdateCategoryParentAsync(categoryDTO, 1);

			var expectedCategoryDTO = GetExpectedCategoryDTO();

			Assert.AreEqual(0, new CategoryDTOComparer().Compare(expectedCategoryDTO, actualCategoryDTO));
		}

		[TestMethod]
		public async Task UpdateCategoryParentId_GivenNotExistingCategoryParentId_ShouldThrowArgumentException()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 3,
				Title = "parent category of category 1",
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 4,
						CategoryId = 2,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "category 1",
				ParentCategoryId = 3,
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 1,
						CategoryId = 1,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			var categoryDTO = GetUpdateCategoryParentDTO();

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await CategoryService.UpdateCategoryParentAsync(categoryDTO, 1); 
			});
		}

		[TestMethod]
		public async Task UpdateCategoryParentId_GivenOwnIdAsCategoryParentId_ShouldThrowInvalidOperationException()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 4,
						CategoryId = 1,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 2,
				Title = "title",
				ParentCategoryId = 1,
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 1,
						CategoryId = 2,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			var categoryDTO = GetUpdateCategoryParentDTO();

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await CategoryService.UpdateCategoryParentAsync(categoryDTO, 2);
			});
		}

		[TestMethod]
		public async Task UpdateCategoryParentId_GivenNotExistingCategoryId_ShouldThrowNotFoundException()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 4,
						CategoryId = 1,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 2,
				Title = "title",
				ParentCategoryId = 1,
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 1,
						CategoryId = 2,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23)
					}
				}
			});
			var categoryDTO = GetUpdateCategoryParentDTO();

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await CategoryService.UpdateCategoryParentAsync(categoryDTO, 5);
			});
		}

		private UpdateCategoryParentDTO GetUpdateCategoryParentDTO()
		{
			var updateCategoryParentDTO = new UpdateCategoryParentDTO()
			{
				ParentCategoryId = 2
			};

			return updateCategoryParentDTO;
		}

		private CategoryDTO GetExpectedCategoryDTO()
		{
			var expectedCategoryDTO = new CategoryDTO
			{
				Id = 1,
				Title = "category 1",
				ParentCategoryId=2,
				CreatedAt = new DateTime(2020, 12, 12)
			};

			return expectedCategoryDTO;
		}
	}
}
