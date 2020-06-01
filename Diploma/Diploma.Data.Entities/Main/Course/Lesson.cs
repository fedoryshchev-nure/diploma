using Diploma.Data.Entities.Linking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diploma.Data.Entities.Main.Course
{
	public class Lesson : EntityBase
	{
		public Lesson()
		{
			UserLessons = new List<UserLesson>();
			CourseLessons = new List<CourseLesson>();
		}

		[Required]
		public int? Order { get; set; }

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }
		[MaxLength(2000)]
		public string Text { get; set; }
		public string ImageName { get; set; }

		public ICollection<UserLesson> UserLessons { get; set; }
		public ICollection<CourseLesson> CourseLessons { get; set; }
	}
}
