﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Diploma.Common.DTOs
{
	public class CourseDto
	{
		[Required]
		[MaxLength(128)]
		public string Title { get; set; }

		[MaxLength(300)]
		public string Description { get; set; }

		public IEnumerable<LessonDto> Lessons { get; set; }
	}
}
