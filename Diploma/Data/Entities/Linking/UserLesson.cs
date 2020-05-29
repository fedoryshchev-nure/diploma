using Diploma.Data.Entities.Main.Course;
using Diploma.Data.Entities.Main.User;
using System;

namespace Diploma.Data.Entities.Linking
{
	public class UserLesson
	{
		public Guid UserId { get; set; }
		public Guid LessonId { get; set; }

		public TimeSpan TimeSpent { get; set; }
		public bool IsCompleted { get; set; }

		public virtual User User { get; set; }
		public virtual Lesson Lesson { get; set; }
	}
}
