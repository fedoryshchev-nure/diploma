using System.Linq;

namespace Diploma.Common.Extensions
{
	// It could have been just IEnumerableExt, but it would require Extra casts
	public static class IQueryableExtensions
	{
		public static IQueryable<T> Page<T>(this IQueryable<T> target, int page, int? pageSize)
		{
			if (pageSize.HasValue)
			{
				target = target
					.Skip(page * pageSize.Value)
					.Take(pageSize.Value);
			}

			return target;
		}
	}
}
