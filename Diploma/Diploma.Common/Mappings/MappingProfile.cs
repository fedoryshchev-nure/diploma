using AutoMapper;
using Diploma.Common.DTOs;
using Diploma.Common.DTOs.Auth;
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
			CreateMap<RegisterDto, User>();

			CreateMap<Course, CourseDto>()
				.ReverseMap();
			CreateMap<Lesson, LessonDto>()
				.ReverseMap();
		}

	}
}
