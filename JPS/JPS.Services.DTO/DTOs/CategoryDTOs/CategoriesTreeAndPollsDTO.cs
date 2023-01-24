using System.Collections.Generic;
using JPS.Services.DTO.DTOs.PollDTOs;

namespace JPS.Services.DTO.DTOs.CategoryDTOs
{
	/// <summary>
	/// Model that contains all categories as a tree and polls without category.
	/// </summary>
	public class CategoriesTreeAndPollsDTO
	{
		public IEnumerable<CategoryDTO> CategoriesTree { get; set; }
		public IEnumerable<PollDTO> PollsWithoutCategory { get; set; }
	}
}
