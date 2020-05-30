using System.Collections.Generic;
using System.Linq;

namespace Diploma.Common.Extensions
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> Page<T>(this IEnumerable<T> target, int page, int? pageSize)
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
