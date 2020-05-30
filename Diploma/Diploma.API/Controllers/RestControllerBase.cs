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
		protected IUnitOfWork UnitOfWork { get; }

		protected IMapper Mapper { get; }

		public RestControllerBase(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			UnitOfWork = unitOfWork;

			Mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TDto>>> Get(
			int page,
			int? pageSize)
		{
			try
			{
				var entities = await UnitOfWork.GetRepository<TEntity>()
					.GetAsync(page, pageSize, disableTracking: true);
				var dtos = Mapper.Map<IEnumerable<TDto>>(entities);
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
				var entity = await UnitOfWork.GetRepository<TEntity>()
					.GetAsync(id, true);
				var dto = Mapper.Map<TDto>(entity);
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
				var entity = Mapper.Map<TEntity>(dto);
				await UnitOfWork.GetRepository<TEntity>()
					.CreateAsync(entity);
				var adedDto = Mapper.Map<TDto>(entity);
				return Ok(adedDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPut("{id}")]
		public ActionResult<TDto> Update(Guid id, TDto dto)
		{
			try
			{
				var entity = Mapper.Map<TEntity>(dto);
				entity.Id = id;
				UnitOfWork.GetRepository<TEntity>()
					.Update(entity);
				var updateDto = Mapper.Map<TDto>(entity);
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
				UnitOfWork.GetRepository<TEntity>()
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
