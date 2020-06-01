using Diploma.API.Services.Interfaces;
using Diploma.Common.DTOs;
using Diploma.Common.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Diploma.API.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService authService;

		public AuthController(IAuthService authService)
		{
			this.authService = authService;
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
		{
			try
			{
				var user = await authService.RegisterAsync(dto);
				if (user == null) return BadRequest();
				return Ok(user);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> Login(LoginDto dto)
		{
			try
			{
				var user = await authService.LoginAsync(dto);
				if (user == null) return BadRequest();
				return Ok(user);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
