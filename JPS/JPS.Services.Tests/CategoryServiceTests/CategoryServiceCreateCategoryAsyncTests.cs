using JPS.Services.Comparers.CategoryComparers;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.CategoryServiceTests
{
	[TestClass]
	public class CategoryServiceCreateCategoryAsyncTests : CategoryServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			CategoryService = new CategoryService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task CreateCategoryAsync_IntegrationTest()
		{		
			var categoryDTO = GetCreateCategoryDTO();

			var actualCategoryDTO = await CategoryService.CreateCategoryAsync(categoryDTO);

			var expectedCategoryDTO = GetExpectedCategoryDTO();

			Assert.AreEqual(0, new CategoryDTOComparer().Compare(expectedCategoryDTO, actualCategoryDTO));
		}

		[TestMethod]
		public async Task CreateCategoryAsync_GivenNotExistingParentCategoryId_ShouldThrowArgumentException()
		{
			var categoryDTO = GetCreateCategoryWithNotExistingParentCategoryIdDTO();

			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await CategoryService.CreateCategoryAsync(categoryDTO);
			});
		}

		private CategoryDTO GetCreateCategoryDTO()
		{
			var createCategoryDTO = new CategoryDTO()
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020,12,5)		
			};

			return createCategoryDTO;
		}

		private CategoryDTO GetCreateCategoryWithNotExistingParentCategoryIdDTO()
		{
			var createCategoryDTO = new CategoryDTO()
			{
				Id = 1,
				Title = "title",
				ParentCategoryId = 3,
				CreatedAt = new DateTime(2020, 12, 5)
			};

			return createCategoryDTO;
		}

		private CategoryDTO GetExpectedCategoryDTO()
		{
			var expectedCategoryDTO = new CategoryDTO()
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 12, 5),
				Polls = new List<PollDTO> 
				{
				}
			};

			return expectedCategoryDTO;
		}
	}
}
