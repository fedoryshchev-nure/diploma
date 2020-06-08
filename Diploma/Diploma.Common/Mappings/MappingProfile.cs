using AutoMapper;
using Diploma.Common.DTOs;
using Diploma.Common.DTOs.Auth;
using Diploma.Common.DTOs.Course;
using Diploma.Data.Entities.Linking;
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
				.ForMember(x => x.Courses,
					opt => opt.MapFrom(x => x.UserCourses.Select(x => x.Course)))
				.ReverseMap();
			CreateMap<RegisterDto, User>()
				.ForMember(x => x.UserName,
					opt => opt.MapFrom(x => x.Email)); ;

			CreateMap<Course, CourseDto>()
				.ForMember(x => x.Lessons,
					opt => opt.MapFrom(x => x.CourseLessons.Select(x => x.Lesson).OrderBy(x => x.Order)))
				.ReverseMap()
				.ForMember(x => x.CourseLessons,
					opt => opt.MapFrom(x => x.Lessons));
			CreateMap<LessonDto, CourseLesson>()
				.ForMember(x => x.Lesson,
					ops => ops.MapFrom(x => x));
			CreateMap<Lesson, LessonDto>()
				.ReverseMap();
		}

	}
}
