using Diploma.Data.DAL.Repository;
using Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces;
using Diploma.Data.Entities.Main.Course;
using Diploma.Data.Entities.Main.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Data.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		#region Repository Getters

		public IUserRepository UserRepository
		{
			get => repositories[typeof(User)] as IUserRepository;
		}
		public ICourseRepository CourseRepository
		{
			get => repositories[typeof(Course)] as ICourseRepository;
		}
		public ILessonRepository LessonRepository
		{
			get => repositories[typeof(Lesson)] as ILessonRepository;
		}

		#endregion

		protected ApplicationDbContext DbContext { get; }

		// Object as generics wont let you do it otherwise
		private readonly IReadOnlyDictionary<Type, object> repositories;

		public UnitOfWork(ApplicationDbContext dbContext,
			IUserRepository userRepository,
			ICourseRepository courseRepository,
			ILessonRepository lessonRepository)
		{
			DbContext = dbContext;

			repositories = new Dictionary<Type, object>
			{
				{ typeof(User), userRepository },
				{ typeof(Course), courseRepository },
				{ typeof(Lesson), lessonRepository },
			};
		}

		IRepository<TEntity> IUnitOfWork.GetRepository<TEntity, TRepository>()
		{
			return (TRepository)repositories[typeof(TEntity)];
		}

		IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
		{
			return (IRepository<TEntity>)repositories[typeof(TEntity)];
		}

		IQueryable<TEntity> IUnitOfWork.Query<TEntity>()
		{
			return DbContext.Set<TEntity>()
				.AsQueryable();
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
