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

		public async Task<User> GetAsync(string email, bool disableTracking = false, bool includeAll = true)
		{
			var query = DbContext.Users
				.AsQueryable();

			if (includeAll)
			{
				query = query
					.Include(x => x.UserCourses)
						.ThenInclude(x => x.Course)
					.Include(x => x.UserLessons)
						.ThenInclude(x => x.Lesson);
			}

			if (disableTracking)
			{
				query.AsNoTracking();
			}

			var entity = await query.FirstOrDefaultAsync(x => x.Email == email);

			return entity;
		}
	}
}
