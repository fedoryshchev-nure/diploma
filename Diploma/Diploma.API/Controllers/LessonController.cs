using AutoMapper;
using Diploma.Common.DTOs;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Main.Course;
using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("{id}/complete")]
		public async Task<IActionResult> CompleteLesson(Guid id, bool isCompleted = true) 
		{
			try
			{
				var lesson = CurrentUser.UserLessons
					.FirstOrDefault(x => x.LessonId == id);
				if (lesson == null) return NotFound();

				lesson.IsCompleted = isCompleted;
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
