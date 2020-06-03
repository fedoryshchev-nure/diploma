using AutoMapper;
using Diploma.Common.Constants;
using Diploma.Common.DTOs;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Main.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Diploma.API.Controllers
{
	[Authorize(Roles = Roles.Admin)]
	public class CourseController : RestControllerBase<CourseDto, Course>
	{
		public CourseController(
			IUnitOfWork unitOfWork,
			IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		[AllowAnonymous]
		[HttpGet("{id:Guid}")]
		public override async Task<ActionResult<CourseDto>> Get(Guid id)
		{
			try
			{
				var query = unitOfWork
					.Query<Course>();

				if (User.IsInRole(Roles.User) || User.IsInRole(Roles.Admin))
				{
					query = query.Include(x => x.CourseLessons)
						.ThenInclude(x => x.Lesson);
				}

				var courses = await query.FirstOrDefaultAsync(x => x.Id == id);
				var dtos = mapper.Map<CourseDto>(courses);
				return Ok(dtos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost]
		public override async Task<ActionResult<CourseDto>> Create([FromForm]CourseDto dto)
		{
			try
			{
				var entity = mapper.Map<Course>(dto);
				entity.ImageName = await SaveImageAsync(dto.Image);
				await unitOfWork.GetRepository<Course>()
					.CreateAsync(entity);
				var adedDto = mapper.Map<CourseDto>(entity);
				return Created(Request.Path, adedDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPut("{id}")]
		public override async Task<ActionResult<CourseDto>> Update(Guid id, CourseDto dto)
		{
			try
			{
				var existingEntity = await unitOfWork.GetRepository<Course>()
					.GetAsync(id, true);
				if (existingEntity == null) return NotFound();

				var entity = mapper.Map<Course>(dto);
				entity.Id = id;
				entity.ImageName = await SaveImageAsync(dto.Image, existingEntity.ImageName);

				unitOfWork.GetRepository<Course>()
					.Update(entity);
				var updateDto = mapper.Map<CourseDto>(entity);
				return Ok(updateDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
