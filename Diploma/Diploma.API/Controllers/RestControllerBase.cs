using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
	[Authorize(Roles = "God")] // No one can access that controller unless rights are specified
	[ApiController]
	[Route("api/[controller]")]
	public abstract class RestControllerBase<TDto, TEntity> : ControllerBase
		where TEntity : class, IEntity, new()
	{
		protected readonly IUnitOfWork unitOfWork;

		protected readonly IMapper mapper;

		public RestControllerBase(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			this.unitOfWork = unitOfWork;

			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TDto>>> Get(
			int page,
			int? pageSize)
		{
			try
			{
				var entities = await unitOfWork.GetRepository<TEntity>()
					.GetAsync(page, pageSize, disableTracking: true);
				var dtos = mapper.Map<IEnumerable<TDto>>(entities);
				return Ok(dtos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TDto>> Get(Guid id)
		{
			try
			{
				var entity = await unitOfWork.GetRepository<TEntity>()
					.GetAsync(id, true);
				var dto = mapper.Map<TDto>(entity);
				return Ok(dto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost]
		public async Task<ActionResult<TDto>> Create(TDto dto)
		{
			try
			{
				var entity = mapper.Map<TEntity>(dto);
				await unitOfWork.GetRepository<TEntity>()
					.CreateAsync(entity);
				var adedDto = mapper.Map<TDto>(entity);
				return Created(Request.Path, adedDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<TDto>> Update(Guid id, TDto dto)
		{
			try
			{
				var existingEntity = await unitOfWork.GetRepository<TEntity>()
					.GetAsync(id, true);
				if (existingEntity == null) return NotFound();

				var entity = mapper.Map<TEntity>(dto);
				entity.Id = id;

				unitOfWork.GetRepository<TEntity>()
					.Update(entity);
				var updateDto = mapper.Map<TDto>(entity);
				return Ok(updateDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpDelete("{id}")]
		public ActionResult<TDto> Delete(Guid id)
		{
			try
			{
				unitOfWork.GetRepository<TEntity>()
					.Delete(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
