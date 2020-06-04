using AutoMapper;
using Diploma.Common.Constants;
using Diploma.Common.DTOs;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Linking;
using Diploma.Data.Entities.Main.Course;
using Diploma.Data.Entities.Main.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diploma.API.Controllers
{
	public class CourseController : RestControllerBase<CourseDto, Course>
	{
		private readonly UserManager<User> userManager;
		public CourseController(
			UserManager<User> userManager,
			IUnitOfWork unitOfWork,
			IMapper mapper) : base(unitOfWork, mapper)
		{
			this.userManager = userManager;
		}

		[HttpGet]
		public async Task<ActionResult<PagedDto<CourseDto>>> Get(
			string searchTerm,
			int page,
			int? pageSize)
		{
			try
			{
				Expression<Func<Course, bool>> filters = x => 
					!string.IsNullOrEmpty(searchTerm) 
						? (x.Title.ToLower().Contains(searchTerm.ToLower())
							|| x.Description.ToLower().Contains(searchTerm.ToLower())) 
						: true;

				var entities = await unitOfWork.CourseRepository
					.GetAsync(page, pageSize, filters, disableTracking: true);
				var items = mapper.Map<IEnumerable<CourseDto>>(entities);
				var total = await unitOfWork.CourseRepository
					.CountAsync(filters);
				return Ok(new PagedDto<CourseDto>(items, total));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<CourseDto>>> Recommendations()
		{
			try
			{
				var entities = await unitOfWork.CourseRepository
					.GetAsync(0, 3);
				var courses = mapper.Map<IEnumerable<CourseDto>>(entities);
				return Ok(courses);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		public override async Task<ActionResult<CourseDto>> Get(Guid id)
		{
			try
			{
				var authorized = false;
				if (CurrentUser != null)
				{
					var roles = await userManager.GetRolesAsync(CurrentUser);
					authorized |= roles.Contains(Roles.User) || roles.Contains(Roles.Admin);
				}

				var query = unitOfWork
					.Query<Course>();

				if (authorized)
				{
					query = query.Include(x => x.CourseLessons)
						.ThenInclude(x => x.Lesson);
				}

				var courses = await query.FirstOrDefaultAsync(x => x.Id == id);
				var dtos = mapper.Map<CourseDto>(courses);

				if (CurrentUser != null)
				{
					var lessons = CurrentUser.UserLessons.ToDictionary(x => x.LessonId, x => x);
						dtos.Lessons.ForEach(lesson =>
						{
							lesson.IsCompleted = lessons.ContainsKey(lesson.Id) && lessons[lesson.Id].IsCompleted;
						}
					);
				}
				return Ok(dtos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[Authorize(Roles = Roles.User)]
		[HttpGet("{id:Guid}/[action]")]
		public async Task<ActionResult<CourseDto>> Attend(Guid id)
		{
			try
			{
				if (CurrentUser?.UserCourses?.Any(x => x.CourseId == id) ?? false)
					return BadRequest("Already attending");

				var course = await unitOfWork.CourseRepository.GetAsync(id);
				if (course == null) return NotFound();

				course.UserCourses.Add(new UserCourse { UserId = CurrentUser.Id, CourseId = course.Id });
				await unitOfWork.SaveChangesAsync();

				var dto = mapper.Map<CourseDto>(course);
				return Ok(dto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[Authorize(Roles = Roles.Admin)]
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

		[Authorize(Roles = Roles.Admin)]
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

		[Authorize(Roles = Roles.Admin)]
		public override ActionResult<CourseDto> Delete(Guid id)
		{
			return base.Delete(id);
		}
	}
}
