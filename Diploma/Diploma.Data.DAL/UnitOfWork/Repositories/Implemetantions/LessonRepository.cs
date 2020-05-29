using Diploma.Data.DAL.Repository;
using Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces;
using Diploma.Data.Entities.Main.Course;

namespace Diploma.Data.DAL.UnitOfWork.Repositories.Implemetantions
{
	public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
	{
		public LessonRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
