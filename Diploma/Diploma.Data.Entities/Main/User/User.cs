using Diploma.Data.Entities.Linking;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Diploma.Data.Entities.Main.User
{
	public class User : IdentityUser<Guid>, IEntity
	{
		public User()
		{
			UserCourses = new List<UserCourse>();
			UserLessons = new List<UserLesson>();
		}

		public ICollection<UserLesson> UserLessons { get; set; }
		public ICollection<UserCourse> UserCourses { get; set; }
	}
}
