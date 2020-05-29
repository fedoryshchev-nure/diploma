using Diploma.Data.Entities.Linking;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Diploma.Data.Entities.Main.User
{
	public class User : IdentityUser<Guid>, IEntity
	{
		public ICollection<UserLesson> UserLessons { get; set; }
		public ICollection<UserCourse> UserCourses { get; set; }
	}
}
