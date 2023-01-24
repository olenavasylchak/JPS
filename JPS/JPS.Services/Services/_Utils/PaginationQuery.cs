using JPS.Services.Constants;
using System.ComponentModel.DataAnnotations;

namespace JPS.Services.Services._Utils
{
	/// <summary>
	/// Model that represents pagination query.
	/// </summary>
	public class PaginationQuery
	{
		[Range(0,int.MaxValue)]
		public int PageNumber { get; set; }

		[Range(1, int.MaxValue)]
		public int PageSize { get; set; }

		public PaginationQuery()
		{
			PageNumber = PaginationConstants.DefaultPageNumber;
			PageSize = PaginationConstants.DefaultPageSize;
		}
	}
}
