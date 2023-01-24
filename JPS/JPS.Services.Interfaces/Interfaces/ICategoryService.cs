using JPS.Services.DTO.DTOs.CategoryDTOs;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Category service interface, holds methods that creates, updates and gets categories.
	/// </summary>
	public interface ICategoryService
	{
		/// <summary>
		/// Get categories tree and polls without category.
		/// </summary>
		/// <returns>Categories tree and polls without category collection.</returns>
		Task<CategoriesTreeAndPollsDTO> GetCategoriesTreeAndPollsWithoutCategory();

		/// <summary>
		/// Get category by id.
		/// </summary>
		/// <param name="id">Used to find necessary category.</param>
		/// <returns>Category.</returns>
		Task<CategoryDTO> GetCategoryByIdAsync(int id);

		/// <summary>
		/// Creates new category.
		/// </summary>
		/// <param name="category">Model with fields necessary for creating new category.</param>
		/// <returns>Created category.</returns>
		Task<CategoryDTO> CreateCategoryAsync(CategoryDTO category);

		/// <summary>
		/// Updates category title.
		/// </summary>
		/// <param name="title">Model with field necessary for updating category title.</param>
		/// <param name="id">Used to find category to be updated.</param>
		/// <returns>Updated category.</returns>
		Task<CategoryDTO> UpdateCategoryTitleAsync(string title, int id);

		/// <summary>
		/// Updates category parent id.
		/// </summary>
		/// <param name="category">Model with field necessary for updating category parent id.</param>
		/// <param name="id">Used to find category to be updated.</param>
		/// <returns>Updated category.</returns>
		Task<CategoryDTO> UpdateCategoryParentAsync(UpdateCategoryParentDTO category, int id);

		/// <summary>
		///  Deletes existing category.
		/// </summary>
		/// <param name="id">Used to indicate category we want to delete.</param>
		Task DeleteCategoryAsync(int id);
	}
}
