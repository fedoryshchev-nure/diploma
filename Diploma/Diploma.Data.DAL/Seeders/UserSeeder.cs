using Diploma.Common.Constants;
using Diploma.Data.Entities.Linking;
using Diploma.Data.Entities.Main.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.Seeders
{
	public static class UserSeeder
	{
		public static async Task SeedAsync(UserManager<User> userManager)
		{
			var adminEmail = "admin@admin.admin";
			var user1Email = "user1@gmail.com";
			var user2Email = "user2@gmail.com";
			var defaultPass = "123456";

			if (await userManager.FindByEmailAsync(adminEmail) == null)
			{
				var admin = new User
				{
					Id = new Guid("00000000-0000-0000-0000-000000000001"),
					UserName = adminEmail,
					Email = adminEmail
				};
				IdentityResult result = await userManager.CreateAsync(admin, defaultPass);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(admin, Roles.Admin);
				}
			}

			if (await userManager.FindByEmailAsync(user1Email) == null)
			{
				var user = new User
				{
					Id = new Guid("00000000-0000-0000-0000-000000000002"),
					UserName = user1Email,
					Email = user1Email,
					UserCourses = new List<UserCourse>
					{
						new UserCourse
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							CourseId = new Guid("00000000-0000-0000-0000-000000000001")
						},
						new UserCourse
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							CourseId = new Guid("00000000-0000-0000-0000-000000000002")
						}
					},
					UserLessons = new List<UserLesson>
					{
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000001"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(150),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000002"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(35),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000004"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(75),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000006"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(15),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000007"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(64),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000002"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000008"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(45),
						}
					}
				};
				IdentityResult result = await userManager.CreateAsync(user, defaultPass);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, Roles.User);
				}
			}

			if (await userManager.FindByEmailAsync(user2Email) == null)
			{
				var user = new User
				{
					Id = new Guid("00000000-0000-0000-0000-000000000003"),
					UserName = user2Email,
					Email = user2Email,
					UserCourses = new List<UserCourse>
					{
						new UserCourse
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							CourseId = new Guid("00000000-0000-0000-0000-000000000003")
						},
						new UserCourse
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							CourseId = new Guid("00000000-0000-0000-0000-000000000005")
						}
					},
					UserLessons = new List<UserLesson>
					{
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000009"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(15),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000010"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(86),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000011"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(4),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000012"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(5),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000017"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(76),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000018"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(12),
						},
						new UserLesson
						{
							UserId = new Guid("00000000-0000-0000-0000-000000000003"),
							LessonId = new Guid("00000000-0000-0000-0000-000000000019"),
							IsCompleted = true,
							TimeSpent = TimeSpan.FromMinutes(15),
						},
					}
				};
				IdentityResult result = await userManager.CreateAsync(user, defaultPass);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, Roles.User);
				}
			}
		}
	}
}
