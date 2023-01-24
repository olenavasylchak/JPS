using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPS.Services.DTO.DTOs.PollDTOs;

namespace JPS.Services.Services
{
	/// <summary>
	/// Service fot the categories entity, contains bl and validation
	/// </summary>
	public class CategoryService : ICategoryService
	{
		private readonly JPSContext _dataContext;
		private readonly IMapper _mapper;
		public CategoryService(JPSContext dbContext, IMapper mapper)
		{
			_dataContext = dbContext;
			_mapper = mapper;
		}

		///<inheritdoc />
		public async Task<CategoriesTreeAndPollsDTO> GetCategoriesTreeAndPollsWithoutCategory()
		{
			var categories = await _dataContext.Categories
				.Include(category => category.Polls)
				.ToListAsync();

			var pollWithoutCategoryEntities = await _dataContext.Polls
				.AsNoTracking()
				.Where(poll => poll.CategoryId == null)
				.ToListAsync();

			var treeCategories = categories.Where(category => category.ParentCategoryId == null);
			var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(treeCategories);
			var pollWithoutCategoryDTOs = _mapper.Map<IEnumerable<PollDTO>>(pollWithoutCategoryEntities);

			var categoriesTreeAndPolls = new CategoriesTreeAndPollsDTO
			{
				PollsWithoutCategory = pollWithoutCategoryDTOs,
				CategoriesTree = categoryDTOs
			};
			return categoriesTreeAndPolls;
		}

		///<inheritdoc />
		public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
		{
			var categoryEntity = await _dataContext.Categories
				.AsNoTracking()
				.SingleOrDefaultAsync(category => category.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				categoryEntity, ExceptionMessageConstants.CategoryNotFoundMessage);

			var categoryDTO = _mapper.Map<CategoryDTO>(categoryEntity);
			return categoryDTO;
		}

		///<inheritdoc />
		public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO)
		{

			await ValidateDoesParentCategoryExist(categoryDTO.ParentCategoryId);
			var categoryEntity = _mapper.Map<CategoryEntity>(categoryDTO);

			var result = await _dataContext.Categories.AddAsync(categoryEntity);
			await _dataContext.SaveChangesAsync();
			var createdCategoryDTO = _mapper.Map<CategoryDTO>(result.Entity);
			return createdCategoryDTO;
		}

		///<inheritdoc />
		public async Task<CategoryDTO> UpdateCategoryParentAsync(UpdateCategoryParentDTO categoryDTO, int id)
		{
			await ValidateChildHasNotThisAncestor(categoryDTO.ParentCategoryId, id);
			var categoryEntityToUpdate = await _dataContext.Categories
				.SingleOrDefaultAsync(category => category.Id == id);
			ValidationHelper.ValidateDoesItemExist(
				categoryEntityToUpdate, ExceptionMessageConstants.CategoryNotFoundMessage);

			categoryEntityToUpdate.ParentCategoryId = categoryDTO.ParentCategoryId;
			await _dataContext.SaveChangesAsync();
			var updatedCategoryDTO = _mapper.Map<CategoryDTO>(categoryEntityToUpdate);
			return updatedCategoryDTO;
		}


		///<inheritdoc />
		public async Task<CategoryDTO> UpdateCategoryTitleAsync(string title, int id)
		{
			var categoryEntityToUpdate = await _dataContext.Categories
				.SingleOrDefaultAsync(category => category.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				categoryEntityToUpdate, ExceptionMessageConstants.CategoryNotFoundMessage);

			categoryEntityToUpdate.Title = title;
			await _dataContext.SaveChangesAsync();
			var updatedCategoryDTO = _mapper.Map<CategoryDTO>(categoryEntityToUpdate);
			return updatedCategoryDTO;
		}

		///<inheritdoc />
		public async Task DeleteCategoryAsync(int id)
		{
			var categoryEntity = await _dataContext.Categories
				.Include(category => category.Categories)
				.Include(category => category.Polls)
				.FirstOrDefaultAsync(category => category.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				categoryEntity, ExceptionMessageConstants.CategoryNotFoundMessage);
			ValidateCategoryHasNoChildren(categoryEntity);
			ValidateCategoryDoesNotHavePoll(categoryEntity);

			_dataContext.Categories.Remove(categoryEntity);
			await _dataContext.SaveChangesAsync();
		}

		private void ValidateCategoryHasNoChildren(CategoryEntity category)
		{
			if (category.Categories.Any())
			{
				throw new InvalidOperationException(ExceptionMessageConstants.DeleteParentCategoryMessage);
			}
		}

		private async Task ValidateChildHasNotThisAncestor(int? parentCategoryId, int id)
		{
			var categoriesTreeWithAncestors = await _dataContext.Categories.ToListAsync();

			var categoryForParentSearch = categoriesTreeWithAncestors.FirstOrDefault(category => category.Id == parentCategoryId);
			if (categoryForParentSearch == null && parentCategoryId != null)
			{
				throw new ArgumentException(ExceptionMessageConstants.InvalidParentIdMessage);
			}

			while (categoryForParentSearch != null)
			{
				if (categoryForParentSearch.Id == id)
				{
					throw new InvalidOperationException(ExceptionMessageConstants.UpdateCategoryExceptionMessage);
				}
				categoryForParentSearch = categoryForParentSearch.Category;
			}
		}

		private async Task ValidateDoesParentCategoryExist(int? parentCategoryId)
		{
			if (parentCategoryId != null)
			{
				var isParentExist = await _dataContext.Categories.AnyAsync(category => category.Id == parentCategoryId);
				if (!isParentExist)
				{
					throw new ArgumentException(ExceptionMessageConstants.InvalidParentIdMessage);
				}
			}
		}

		private void ValidateCategoryDoesNotHavePoll(CategoryEntity category)
		{
			if (category.Polls.Any())
			{
				throw new InvalidOperationException(ExceptionMessageConstants.DeleteCategoryWithPollMessage);
			}
		}
	}
}
