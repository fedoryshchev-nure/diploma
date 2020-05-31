using Diploma.Data.Entities.Main.User;
using Microsoft.AspNetCore.Identity;
using System;
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

			if (await userManager.FindByEmailAsync(adminEmail) == null)
			{
				var admin = new User
				{
					Id = new Guid("00000000-0000-0000-0000-000000000001"),
					UserName = adminEmail,
					Email = adminEmail
				};
				IdentityResult result = await userManager.CreateAsync(admin, "123456");
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(admin, "Admin");
				}
			}

			if (await userManager.FindByEmailAsync(user1Email) == null)
			{
				var user = new User
				{
					Id = new Guid("00000000-0000-0000-0000-000000000002"),
					UserName = user1Email,
					Email = user1Email
				};
				IdentityResult result = await userManager.CreateAsync(user, "123456");
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "User");
				}
			}

			if (await userManager.FindByEmailAsync(user2Email) == null)
			{
				var user = new User
				{
					Id = new Guid("00000000-0000-0000-0000-000000000003"),
					UserName = user2Email,
					Email = user2Email
				};
				IdentityResult result = await userManager.CreateAsync(user, "123456");
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "User");
				}
			}
		}
	}
}
