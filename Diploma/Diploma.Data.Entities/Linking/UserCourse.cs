using Diploma.Data.Entities.Main.Course;
using Diploma.Data.Entities.Main.User;
using System;

namespace Diploma.Data.Entities.Linking
{
	public class UserCourse
	{
		public Guid UserId { get; set; }
		public Guid CourseId { get; set; }

		public bool IsCompleted { get; set; }
		public float Rate { get; set; }

		public virtual User User { get; set; }
		public virtual Course Course { get; set; }
	}
}
