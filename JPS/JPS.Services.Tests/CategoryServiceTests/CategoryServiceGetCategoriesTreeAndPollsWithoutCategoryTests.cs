using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.CategoryComparers;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Tests.CategoryServiceTests
{
	[TestClass]
	public class CategoryServiceGetCategoriesTreeAndPollsWithoutCategoryTests : CategoryServiceTestsBase
	{
		[TestInitialize]
		public void TestInitialize()
		{
			DbContext = CreateDbContext();
			CategoryService = new CategoryService(DbContext, Mapper);
		}

		[TestMethod]
		public async Task GetCategoriesTreeAndPollsWithoutCategories_IntegrationTest()
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
						CreatedAt = new DateTime(2020, 05, 23),
						QuestionSections = new List<QuestionSectionEntity>
						{
						}
					}
				}
			});
			await AddItems(DbContext, new PollEntity
			{
				Id = 2,
				Title = "title",
				Description = "description",
				IsAnonymous = false,
				StartsAt = null,
				FinishesAt = null,
				CreatedAt = new DateTime(2020, 05, 23),
				QuestionSections = new List<QuestionSectionEntity>
				{
				}
			});

			var actualCategoryTreeAndPollsDTO = await CategoryService.GetCategoriesTreeAndPollsWithoutCategory();

			var expectedDTO = GetExpectedTreeAndPollsDTO();

			Assert.AreEqual(0, new CategoriesTreeAndPollsDTOComparer().Compare(expectedDTO, actualCategoryTreeAndPollsDTO));
		}

		private CategoriesTreeAndPollsDTO GetExpectedTreeAndPollsDTO()
		{
			var expectedtreeDTO = new CategoriesTreeAndPollsDTO
			{
				CategoriesTree = new List<CategoryDTO>
				{
					new CategoryDTO
					{
						Id = 1,
						Title = "title",
						CreatedAt = new DateTime(2020,12,12),
						Polls = new List<PollDTO>
						{
							new PollDTO
							{
								Id = 1,
								CategoryId = 1,
								Title = "title",
								Description = "description",
								IsAnonymous = false,
								StartsAt = null,
								FinishesAt = null,
								CreatedAt = new DateTime(2020, 05, 23),
								QuestionSections=new List<QuestionSectionDTO>
								{
								}
							}
						}
					}
				},
				PollsWithoutCategory = new List<PollDTO>
				{
					new PollDTO
					{
						Id = 2,
						Title = "title",
						Description = "description",
						IsAnonymous = false,
						StartsAt = null,
						FinishesAt = null,
						CreatedAt = new DateTime(2020, 05, 23),
						QuestionSections = new List<QuestionSectionDTO>
						{
						}
					}
				}
			};

			return expectedtreeDTO;
		}
	}
}
