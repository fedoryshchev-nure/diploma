using AutoMapper;
using Diploma.Common.DTOs;
using Diploma.Data.Entities.Main.Course;
using Diploma.Data.Entities.Main.User;

namespace Diploma.Common.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDto>()
				.ReverseMap();

			CreateMap<Course, CourseDto>()
				.ReverseMap();
			CreateMap<Lesson, LessonDto>()
				.ReverseMap();
		}

	}
}
