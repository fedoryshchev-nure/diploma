using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Diploma.Common.DTOs
{
	public class LessonDto
	{
		[Required]
		public int? Order { get; set; }

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }

		[MaxLength(2000)]
		public string Text { get; set; }
		public string ImageName { get; set; }
	}
}
