using Diploma.Data.DAL.Seeders;
using Diploma.Data.Entities.Linking;
using Diploma.Data.Entities.Main.Course;
using Diploma.Data.Entities.Main.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Diploma.Data.DAL
{
	public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public DbSet<Course> Courses { get; set; }
		public DbSet<Lesson> Lessons { get; set; }

		public DbSet<UserCourse> UserCourses { get; set; }
		public DbSet<UserLesson> UserLessons { get; set; }


		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<UserCourse>().HasKey(x => new { x.UserId, x.CourseId });
			builder.Entity<UserLesson>().HasKey(x => new { x.UserId, x.LessonId });
			builder.Entity<CourseLesson>().HasKey(x => new { x.CourseId, x.LessonId });

			builder.Entity<UserLesson>()
				.Property(s => s.TimeSpent)
				.HasConversion(new TimeSpanToTicksConverter());

			Seed(builder);
		}

		private void Seed(ModelBuilder builder)
		{
			RoleSeeder.Seed(builder);
			//SeedUsers(builder); // Users are seeded in startup as userManager needed
			CourseSeeder.Seed(builder);
		}
	}
}
