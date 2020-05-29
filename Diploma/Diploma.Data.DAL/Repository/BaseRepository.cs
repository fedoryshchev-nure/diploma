using Diploma.Data.Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.Repository
{
	public class BaseRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity, new()
	{
		protected ApplicationDbContext DbContext { get; }

		public BaseRepository(ApplicationDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public async Task<TEntity> GetAsync(Guid id, bool disableTracking = false)
		{
			var query = DbContext.Set<TEntity>();

			if (disableTracking)
			{
				query.AsNoTracking();
			}

			var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

			return entity;
		}

		public async Task AddAsync(TEntity entity)
		{
			await DbContext.AddAsync(entity);
		}

		public void Update(TEntity entity)
		{
			DbContext.Update(entity);
		}

		public void Remove(Guid id)
		{
			var entity = new TEntity() { Id = id };
			Remove(entity);
		}

		public void Remove(TEntity entity)
		{
			DbContext.Remove(entity);
		}

		public async Task SaveChangesAsync()
		{
			await DbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			DbContext.Dispose();
		}
	}
}
