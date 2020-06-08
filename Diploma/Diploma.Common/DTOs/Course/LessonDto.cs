using System;
using System.ComponentModel.DataAnnotations;

namespace Diploma.Common.DTOs.Course
{
	public class LessonDto
	{
		public Guid Id { get; set; }

		public int? Order { get; set; }

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }
		[MaxLength(4000)]
		public string Text { get; set; }
		public string ImageName { get; set; }
		public bool IsCompleted { get; set; }
	}
}
