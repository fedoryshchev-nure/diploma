using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Data.Entities.Main.User
{
	public class User : IdentityUser<Guid>, IEntity
	{
	}
}
