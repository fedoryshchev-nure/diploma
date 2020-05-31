using Diploma.Data.Entities.Linking;
using Diploma.Data.Entities.Main.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Diploma.Data.DAL.Seeders
{
	public static class CourseSeeder
	{

		public static void Seed(ModelBuilder builer)
		{
			SeedLessons(builer);
			SeedCourses(builer);
			SeedCourseLessons(builer);
		}

		private static void SeedLessons(ModelBuilder builder)
		{
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000001"),
					Order = 1,
					Title = "Lesson 1",
					Text = "Course 1, Lesson 1"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000002"),
					Order = 2,
					Title = "Lesson 2",
					Text = "Course 1, Lesson 2"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000003"),
					Order = 3,
					Title = "Lesson 3",
					Text = "Course 1, Lesson 3"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000004"),
					Order = 4,
					Title = "Lesson 4",
					Text = "Course 1, Lesson 4"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000005"),
					Order = 5,
					Title = "Lesson 5",
					Text = "Course 1, Lesson 5"
				},
			});
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000006"),
					Order = 1,
					Title = "Lesson 1",
					Text = "Course 2, Lesson 1"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000007"),
					Order = 2,
					Title = "Lesson 2",
					Text = "Course 2, Lesson 2"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000008"),
					Order = 3,
					Title = "Lesson 3",
					Text = "Course 2, Lesson 3"
				},
			});
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000009"),
					Order = 1,
					Title = "Lesson 1",
					Text = "Course 3, Lesson 1"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000010"),
					Order = 2,
					Title = "Lesson 2",
					Text = "Course 3, Lesson 2"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000011"),
					Order = 3,
					Title = "Lesson 3",
					Text = "Course 3, Lesson 3"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000012"),
					Order = 4,
					Title = "Lesson 4",
					Text = "Course 3, Lesson 4"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000013"),
					Order = 5,
					Title = "Lesson 5",
					Text = "Course 3, Lesson 5"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000014"),
					Order = 6,
					Title = "Lesson 6",
					Text = "Course 3, Lesson 6"
				},
			});
		}

		private static void SeedCourses(ModelBuilder builder)
		{
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000001"),
				Title = "Course 1",
				Description = "Course 1 Description",
			});
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000002"),
				Title = "Course 2",
				Description = "Course 2 Description",
			});
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000003"),
				Title = "Course 3",
				Description = "Course 3 Description",
			});
		}

		private static void SeedCourseLessons(ModelBuilder builder)
		{
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000002")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000003")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000004")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000005")
				}
			});
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000002"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000006")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000002"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000007")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000002"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000008")
				}
			});
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000009")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000010")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000011")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000012")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000013")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000014")
				}
			});
		}
	}
}
