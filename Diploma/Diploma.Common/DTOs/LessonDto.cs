using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Diploma.Common.DTOs
{
	public class LessonDto
	{
		public Guid Id { get; set; }

		[Required]
		public int? Order { get; set; }

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }
		[MaxLength(2000)]
		public string Text { get; set; }
		public IFormFile Image { get; set; }
		public string ImageName { get; set; }
	}
}
