using Diploma.Data.DAL.Repository;
using Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces;
using Diploma.Data.Entities.Main.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.UnitOfWork.Repositories.Implemetantions
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<User> GetAsync(string email, bool disableTracking = false)
		{
			var query = DbContext.Users
				.Include(x => x.UserCourses)
				.Include(x => x.UserLessons);

			if (disableTracking)
			{
				query.AsNoTracking();
			}

			var entity = await query.FirstOrDefaultAsync(x => x.Email == email);

			return entity;
		}
	}
}
