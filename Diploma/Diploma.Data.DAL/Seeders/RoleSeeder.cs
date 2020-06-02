using Diploma.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Diploma.Data.DAL.Seeders
{
	public static class RoleSeeder
	{
		public static void Seed(ModelBuilder builder)
		{
			builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
			{
				Id = new Guid("00000000-0000-0000-0000-000000000001"),
				Name = Roles.User,
				NormalizedName = Roles.User.ToUpper(),
				ConcurrencyStamp = "1"
			});
			builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
			{
				Id = new Guid("00000000-0000-0000-0000-000000000002"),
				Name = Roles.Admin,
				NormalizedName = Roles.Admin.ToUpper(),
				ConcurrencyStamp = "2"
			});
		}
	}
}
