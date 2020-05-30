using Diploma.Data.DAL.Repository;
using Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces;
using Diploma.Data.Entities.Main;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		public IUserRepository UserRepository { get; }
		public ICourseRepository CourseRepository { get; }
		public ILessonRepository LessonRepository { get; }

		public IRepository<TEntity> GetRepository<TEntity>()
			where TEntity : class, IEntity, new();
		public IRepository<TEntity> GetRepository<TEntity, TRepository>()
			where TEntity : class, IEntity, new()
			where TRepository : IRepository<TEntity>;
		public IQueryable<TEntity> Query<TEntity>()
			where TEntity : class, IEntity, new();

		public Task SaveChangesAsync();
	}
}
