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
		#region Repositories

		public IUserRepository UserRepository
		{
			get => Repositories[typeof(User)] as IUserRepository;
		}
		public ICourseRepository CourseRepository
		{
			get => Repositories[typeof(Course)] as ICourseRepository;
		}
		public ILessonRepository LessonRepository
		{
			get => Repositories[typeof(Lesson)] as ILessonRepository;
		}

		#endregion

		protected ApplicationDbContext DbContext { get; }

		// Object as generics wont let you do it otherwise
		private IReadOnlyDictionary<Type, object> Repositories { get; }

		public UnitOfWork(ApplicationDbContext dbContext,
			IUserRepository userRepository,
			ICourseRepository courseRepository,
			ILessonRepository lessonRepository)
		{
			DbContext = dbContext;

			Repositories = new Dictionary<Type, object>
			{
				{ typeof(User), userRepository },
				{ typeof(Course), courseRepository },
				{ typeof(Lesson), lessonRepository },
			};
		}

		IRepository<TEntity> IUnitOfWork.GetRepository<TEntity, TRepository>()
		{
			return (TRepository)Repositories[typeof(TEntity)];
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
