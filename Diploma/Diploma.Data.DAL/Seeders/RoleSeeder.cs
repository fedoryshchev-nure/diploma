using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Diploma.Data.DAL.Seeders
{
	public static class RoleSeeder
	{
		public static void Seed(ModelBuilder builder)
		{
			var userRole = "User";
			var adminRole = "Admin";

			builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
			{
				Id = new Guid("00000000-0000-0000-0000-000000000001"),
				Name = userRole,
				NormalizedName = userRole.ToUpper(),
				ConcurrencyStamp = "1"
			});
			builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
			{
				Id = new Guid("00000000-0000-0000-0000-000000000002"),
				Name = adminRole,
				NormalizedName = adminRole.ToUpper(),
				ConcurrencyStamp = "2"
			});
		}
	}
}
