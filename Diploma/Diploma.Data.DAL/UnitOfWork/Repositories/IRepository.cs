using Diploma.Data.Entities.Main;
using System;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.Repository
{
	public interface IRepository<TEntity>
		where TEntity : class, IEntity, new()
	{
		public Task<TEntity> GetAsync(Guid id, bool disableTracking = false);
		public Task AddAsync(TEntity entity);
		public void Update(TEntity entity);
		public void Remove(TEntity entity);
		public void Remove(Guid id);
	}
}
