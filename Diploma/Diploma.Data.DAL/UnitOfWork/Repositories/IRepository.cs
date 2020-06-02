using Diploma.Data.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.Repository
{
	public interface IRepository<TEntity>
		where TEntity : class, IEntity, new()
	{
		public Task<int> CountAsync(Expression<Func<TEntity, bool>> filters = null);
		public Task<IEnumerable<TEntity>> GetAsync(
			int page = 0,
			int? pageSize = 50,
			Expression<Func<TEntity, bool>> filters = null,
			bool disableTracking = false);
		public Task<TEntity> GetAsync(Guid id, bool disableTracking = false);
		public Task CreateAsync(TEntity entity);
		public void Update(TEntity entity);
		public void Delete(TEntity entity);
		public void Delete(Guid id);
	}
}
