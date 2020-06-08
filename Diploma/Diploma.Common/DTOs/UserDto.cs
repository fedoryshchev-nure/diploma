using Diploma.Common.DTOs.Course;
using System.Collections.Generic;

namespace Diploma.Common.DTOs
{
	public class UserDto
	{
		public string Email { get; set; }

		public string Token { get; set; }

		public IEnumerable<CourseDto> Courses { get; set; }
	}
}
