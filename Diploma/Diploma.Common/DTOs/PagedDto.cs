using System.Collections.Generic;

namespace Diploma.Common.DTOs
{
	public class PagedDto<TDto>
	{

		public PagedDto(IEnumerable<TDto> items, int total)
		{
			Items = items;
			Total = total;
		}

		public IEnumerable<TDto> Items { get; set; }
		public int Total { get; set; }
	}
}
