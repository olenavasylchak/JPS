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
	public class CategoryServiceGetCategoryByIdAsyncTests : CategoryServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			CategoryService = new CategoryService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task GetCategoryById_IntegrationTest()
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

			var actualCategoryDTO = await CategoryService.GetCategoryByIdAsync(1);

			var expectedCategoryDTO = GetExpectedCategoryDTO();

			Assert.AreEqual(0, new CategoryDTOComparer().Compare(expectedCategoryDTO, actualCategoryDTO));
		}

		[TestMethod]
		public async Task GetCategoryById_GivenNotExistingCategoryId_ShouldThrowNotFoundException()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 05, 25)			
			});

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await CategoryService.GetCategoryByIdAsync(2);
			});
		}

		private CategoryDTO GetExpectedCategoryDTO()
		{
			var expectedCategoryDTO = new CategoryDTO
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 12, 12)
			};

			return expectedCategoryDTO;
		}
	}
}
