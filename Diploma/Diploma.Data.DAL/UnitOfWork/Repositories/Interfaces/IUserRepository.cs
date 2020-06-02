using Diploma.Data.DAL.Repository;
using Diploma.Data.Entities.Main.User;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		public Task<User> GetAsync(string email, bool disableTracking = false, bool includeAll = true);
	}
}
