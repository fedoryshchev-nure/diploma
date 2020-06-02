using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Diploma.Common.Constants;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Main;
using Diploma.Data.Entities.Main.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
	[Authorize(Roles = Roles.God)] // No one can access that controller unless rights are specified manually
	[ApiController]
	[Route("api/[controller]")]
	public abstract class RestControllerBase<TDto, TEntity> : ControllerBase
		where TEntity : class, IEntity, new()
	{
		protected virtual User CurrentUser { get => lazyCurrentUserAsync.Value.Result; }
		private readonly Lazy<Task<User>> lazyCurrentUserAsync;

		protected readonly IUnitOfWork unitOfWork;

		protected readonly IMapper mapper;

		public RestControllerBase(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			this.lazyCurrentUserAsync = new Lazy<Task<User>>(GetCurrentUserAsync);
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

		private async Task<User> GetCurrentUserAsync()
		{
			if (this.User == null
				|| this.User.Identity == null
				|| !this.User.Identity.IsAuthenticated) return null;

			var email = User.FindFirst(ClaimTypes.Email).Value;
			var user = await unitOfWork.UserRepository
				.GetAsync(email);

			return user;
		}

		protected async Task<string> SaveImageAsync(IFormFile file, string previousName = null)
		{
			if (!string.IsNullOrEmpty(previousName))
			{
				var pathToDelete = GetImagePath(previousName);
				System.IO.File.Delete(pathToDelete);
			}

			var fileName = $"{Guid.NewGuid()}-{file.FileName}";
			var pathToSave = GetImagePath(fileName);

			using (var fs = new FileStream(pathToSave, FileMode.CreateNew))
			{
				await file.CopyToAsync(fs);
			}

			return fileName;
		}

		private string GetImagePath(string fileName) =>
			Path.Combine(Directory.GetCurrentDirectory(),
				"wwwroot",
				"images",
				fileName);
	}
}
