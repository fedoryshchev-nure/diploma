using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Common.DTOs
{
	public class UserDto
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public IEnumerable<CourseDto> Courses { get; set; }
	}
}
