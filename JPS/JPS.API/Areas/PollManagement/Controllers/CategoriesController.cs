using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.CategoryViewModels;
using JPS.API.ViewModels.ViewModels.CategoryViewModels.UpdateViewModels;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.PollManagement.Controllers
{
	/// <summary>
	/// This controller allows create, update and get categories.
	/// </summary>
	[Area("poll-management")]
	[Route("api/[area]/categories")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		public CategoriesController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		/// <summary>
		/// Gets all existing categories as a tree and polls without category.
		/// </summary>
		/// <returns>Object with categories tree and collection of polls without category.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(CategoriesTreeAndPollsViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<CategoriesTreeAndPollsViewModel>> GetCategoriesTreeAndPollsWithoutCategory()
		{
			var categoriesTreeAndPolls = await _categoryService.GetCategoriesTreeAndPollsWithoutCategory();
			var categoriesTreeAndPollsViewModel = _mapper.Map<CategoriesTreeAndPollsViewModel>(categoriesTreeAndPolls);
			return Ok(categoriesTreeAndPollsViewModel);
		}

		/// <summary>
		/// Gets category by id.
		/// </summary>
		/// <param name="id">Used to find necessary category.</param>
		/// <returns>Category.</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(CategoryViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<CategoryViewModel>> GetCategoryByIdAsync([NumericIdGreaterThanZero] int id)
		{
			var categoryDTO = await _categoryService.GetCategoryByIdAsync(id);
			var categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDTO);
			return Ok(categoryViewModel);
		}

		/// <summary>
		/// Creates a new category.
		/// </summary>
		/// <param name="categoryViewModel">Model with fields necessary for creating new category.</param>
		/// <returns>Created category.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(CategoryViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<CreateCategoryViewModel>> CreateAsync(
			[FromBody] CreateCategoryViewModel categoryViewModel)
		{
			var categoryDTO = _mapper.Map<CategoryDTO>(categoryViewModel);
			var createdCategoryDTO = await _categoryService.CreateCategoryAsync(categoryDTO);
			var createdCategoryViewModel = _mapper.Map<CategoryViewModel>(createdCategoryDTO);
			return Ok(createdCategoryViewModel);
		}

		/// <summary>
		/// Updates category's parent by id.
		/// </summary>
		/// <param name="categoryViewModel">Model with fields to be updated.</param>
		/// <param name="id">Used to find necessary category.</param>
		/// <returns>Updated category.</returns>
		[HttpPut("{id}/parent-category")]
		[ProducesResponseType(typeof(CategoryViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<UpdateCategoryParentViewModel>> UpdateParentAsync(
			[FromBody] UpdateCategoryParentViewModel categoryViewModel,
			[NumericIdGreaterThanZero] int id)
		{
			var categoryDTO = _mapper.Map<UpdateCategoryParentDTO>(categoryViewModel);
			var updatedCategoryDTO = await _categoryService.UpdateCategoryParentAsync(categoryDTO, id);
			var updatedCategoryViewModel = _mapper.Map<CategoryViewModel>(updatedCategoryDTO);
			return Ok(updatedCategoryViewModel);
		}

		/// <summary>
		/// Updates category's title by id.
		/// </summary>
		/// <param name="categoryViewModel">Model with fields to be updated.</param>
		/// <param name="id">Used to find necessary category.</param>
		/// <returns>Updated category.</returns>
		[HttpPut("{id}/title")]
		[ProducesResponseType(typeof(CategoryViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<UpdateCategoryTitleViewModel>> UpdateTitleAsync(
			[FromBody] UpdateCategoryTitleViewModel categoryViewModel,
			[NumericIdGreaterThanZero]int id)
		{
			var categoryDTO = _mapper.Map<CategoryDTO>(categoryViewModel);
			var updatedCategoryDTO = await _categoryService.UpdateCategoryTitleAsync(categoryDTO.Title, id);
			var updatedCategoryViewModel = _mapper.Map<CategoryViewModel>(updatedCategoryDTO);
			return Ok(updatedCategoryViewModel);
		}

		/// <summary>
		/// Deletes a category.
		/// </summary>
		/// <param name="id">Used to find necessary category.</param>
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCategoryAsync([NumericIdGreaterThanZero] int id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return NoContent();
		}
	}
}