using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Exceptions;
using JPS.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.CategoryServiceTests
{
	[TestClass]
	public class CategoryServiceDeleteCategoryAsyncTests : CategoryServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			CategoryService = new CategoryService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task DeleteCategoryAsync_IntegrationTest()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 12, 12),
				Categories = null,
				Polls = null
			});

			await CategoryService.DeleteCategoryAsync(1);

			var hasDbContextCategory = await HasDbCategory(DbContext, 1);

			Assert.IsFalse(hasDbContextCategory);
		}

		[TestMethod]
		public async Task DeleteCategoryById_GivenNotExistingCategoryId_ShouldThrowNotFoundException()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 05, 25)
			});

			await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
			{
				await CategoryService.DeleteCategoryAsync(2);
			});
		}

		[TestMethod]
		public async Task DeleteCategoryById_GivenCategoryIdWhichHasChildren_ShouldThrowInvalidOperationException()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 05, 25),
				Categories = new List<CategoryEntity>
				{
					new CategoryEntity
					{
						Id = 2,
						Title = "title",
						CreatedAt = new DateTime(2020, 05, 26),
					}
				}
			});

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await CategoryService.DeleteCategoryAsync(1);
			});
		}

		[TestMethod]
		public async Task DeleteCategoryById_GivenCategoryIdWhichHasPoll_ShouldThrowInvalidOperationException()
		{
			await AddItems(DbContext, new CategoryEntity
			{
				Id = 1,
				Title = "title",
				CreatedAt = new DateTime(2020, 05, 25),
				Polls = new List<PollEntity>
				{
					new PollEntity
					{
						Id = 1,
						CategoryId = 1,
						Title = "title",
						IsAnonymous = false,
						CreatedAt = new DateTime(2020, 05, 25)
					}
				}
			});

			await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
			{
				await CategoryService.DeleteCategoryAsync(1);
			});
		}

		private async Task<bool> HasDbCategory(JPSContext context, int categoryId)
		{
			return await context.Categories
				.AnyAsync(category => category.Id == categoryId);
		}
	}
}