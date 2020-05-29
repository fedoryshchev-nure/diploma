using Diploma.Data.Entities.Main.Course;
using System;

namespace Diploma.Data.Entities.Linking
{
	public class CourseLesson
	{
		public Guid CourseId { get; set; }
		public Guid LessonId { get; set; }

		public virtual Course Course { get;set;}
		public virtual Lesson Lesson { get;set;}
	}
}
