using System;
using System.Collections.Generic;

namespace JPS.Common
{
	/// <summary>
	/// Used to create paged list.
	/// </summary>
	/// <typeparam name="T">Generic type parameter.</typeparam>
	/// <summary>
	/// Used for implementing paging skip/take logic.
	/// </summary>
	/// <typeparam name="T">A generic type parameter.
	/// Allows to specify an arbitrary type T to a method at compile-time.</typeparam>
	public class PagedList<T> 
	{
		public IEnumerable<T> Data { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }

		public PagedList()
		{
		}

		/// <summary>
		/// Set properties that will come in handy as metadata for response.
		/// </summary>
		/// <param name="items">Used to set a necessary data.</param>
		/// <param name="count">Used to calculate a total count of pages.</param>
		/// <param name="pageNumber">Used to set the number of current page.</param>
		/// <param name="pageSize">Used to set a size of page.</param>
		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			Data = items;
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int) Math.Ceiling(count / (double) pageSize);
		}
	}
}

