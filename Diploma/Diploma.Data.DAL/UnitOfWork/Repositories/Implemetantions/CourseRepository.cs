using Diploma.Data.DAL.Repository;
using Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces;
using Diploma.Data.Entities.Main.Course;

namespace Diploma.Data.DAL.UnitOfWork.Repositories.Implemetantions
{
	public class CourseRepository : BaseRepository<Course>, ICourseRepository
	{
		public CourseRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
