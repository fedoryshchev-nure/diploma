using Diploma.Data.DAL.Repository;
using Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces;
using Diploma.Data.Entities.Main.User;

namespace Diploma.Data.DAL.UnitOfWork.Repositories.Implemetantions
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
