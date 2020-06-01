using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diploma.Common.DTOs
{
	public class CourseDto
	{
		public Guid Id { get; set; }

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }
		[MaxLength(300)]
		public string Description { get; set; }
		public string ImageName { get; set; }

		public IEnumerable<LessonDto> Lessons { get; set; }
	}
}
