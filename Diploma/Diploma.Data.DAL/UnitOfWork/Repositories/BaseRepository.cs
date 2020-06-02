using Diploma.Common.Extensions;
using Diploma.Data.Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.Repository
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity, new()
	{
		protected ApplicationDbContext DbContext { get; }

		public BaseRepository(ApplicationDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filters = null)
		{
			var query = DbContext.Set<TEntity>()
				.AsQueryable();

			if (filters != null)
			{
				query = query.Where(filters);
			}

			var count = await query.CountAsync();

			return count;
		}

		public async Task<IEnumerable<TEntity>> GetAsync(
			int page = 0, 
			int? pageSize = 50,
			Expression<Func<TEntity, bool>> filters = null,
			bool disableTracking = false)
		{
			var query = DbContext.Set<TEntity>()
				.AsQueryable();

			if (disableTracking)
			{
				query.AsNoTracking();
			}

			if (filters != null)
			{
				query = query.Where(filters);
			}

			query = query.Page(page, pageSize);

			var entities = await query.ToListAsync();

			return entities;
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

		public async Task CreateAsync(TEntity entity)
		{
			await DbContext.AddAsync(entity);
		}

		public void Update(TEntity entity)
		{
			DbContext.Update(entity);
		}

		public void Delete(Guid id)
		{
			var entity = new TEntity() { Id = id };
			Delete(entity);
		}

		public void Delete(TEntity entity)
		{
			DbContext.Remove(entity);
		}
	}
}
