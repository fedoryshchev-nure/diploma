using AutoMapper;
using Diploma.Common.DTOs;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Main.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.API.Controllers
{
	public class CourseController : RestControllerBase<CourseDto, Course>
	{
		public CourseController(
			IUnitOfWork unitOfWork, 
			IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		[HttpGet("{id}")]
		public new async Task<ActionResult<CourseDto>> Get(Guid id)
		{
			try
			{
				var courseWithLessons = await unitOfWork
					.Query<Course>()
					.Include(x => x.CourseLessons)
						.ThenInclude(x => x.Lesson)
					.FirstOrDefaultAsync(x => x.Id == id);
				return Ok(courseWithLessons);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
