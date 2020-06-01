using AutoMapper;
using Diploma.Common.DTOs;
using Diploma.Common.DTOs.Auth;
using Diploma.Data.Entities.Main.Course;
using Diploma.Data.Entities.Main.User;
using System.Linq;

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
				.ForMember(x => x.Lessons, 
					opt => opt.MapFrom(x => x.CourseLessons.Select(x => x.Lesson)))
				.ReverseMap();
			CreateMap<Lesson, LessonDto>()
				.ReverseMap();
		}

	}
}
