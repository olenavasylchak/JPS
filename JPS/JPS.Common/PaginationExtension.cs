using System.Linq;
using System.Threading.Tasks;

namespace JPS.Common
{
	/// <summary>
	/// Extension method for pagination.
	/// </summary>
	public static class PaginationExtension
	{
		public static async Task<PagedList<T>> ToPaginatedCollection<T>(this IQueryable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip(pageNumber * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}
