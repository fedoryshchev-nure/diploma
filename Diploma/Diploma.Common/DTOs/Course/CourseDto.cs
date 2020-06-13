using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diploma.Common.DTOs.Course
{
	public class CourseDto
	{
		public CourseDto()
		{
			Images = new List<IFormFile>();
			Lessons = new List<LessonDto>();
		}

		public Guid Id { get; set; }

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }
		[MaxLength(1000)]
		public string Description { get; set; }
		public string ImageName { get; set; }

		// Required for add/edit to treat nested files
		public IEnumerable<IFormFile> Images { get; set; }

		[MinLength(1)]
		public IEnumerable<LessonDto> Lessons { get; set; }
	}
}
