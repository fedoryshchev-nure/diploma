using Diploma.Data.Entities.Linking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diploma.Data.Entities.Main.Course
{
	public class Course : EntityBase
	{
		public Course()
		{
			UserCourses = new List<UserCourse>();
			CourseLessons = new List<CourseLesson>();
		}

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }
		[MaxLength(1000)]
		public string Description { get; set; }
		public string ImageName { get; set; }

		public bool IsInUseByRecommendationModule { get; set; }

		public ICollection<UserCourse> UserCourses { get; set; }
		public ICollection<CourseLesson> CourseLessons { get; set; }
	}
}
