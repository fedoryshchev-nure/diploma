using AutoMapper;
using Diploma.Common.Constants;
using Diploma.Common.DTOs.Course;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Linking;
using Diploma.Data.Entities.Main.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.API.Controllers
{
	public class LessonController : RestControllerBase<LessonDto, Lesson>
	{
		public LessonController(
			IUnitOfWork unitOfWork,
			IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		[HttpGet("{id:Guid}/complete")]
		[Authorize(Roles = Roles.User)]
		public async Task<IActionResult> Complete(Guid id, bool isCompleted = true) 
		{
			try
			{
				var lesson = await unitOfWork.Query<Lesson>()
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.Id == id);
				if (lesson == null) return NotFound();

				var existingUserLesson = CurrentUser.UserLessons
					.FirstOrDefault(x => x.LessonId == lesson.Id);
				if (existingUserLesson != null) existingUserLesson.IsCompleted = isCompleted;
				else
					CurrentUser.UserLessons.Add(new UserLesson { UserId = CurrentUser.Id, LessonId = lesson.Id, IsCompleted = true });

				await unitOfWork.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
