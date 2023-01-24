using System;
using System.Collections.Generic;
using JPS.Services.DTO.DTOs.PollDTOs;

namespace JPS.Services.DTO.DTOs.CategoryDTOs
{
	/// <summary>
	/// Base DTO for the categories, using to get categories.
	/// </summary>
	public class CategoryDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int? ParentCategoryId { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public CategoryDTO ParentCategory { get; set; }
		public IEnumerable<CategoryDTO> Children { get; set; }
		public IEnumerable<PollDTO> Polls { get; set; }
	}
}
