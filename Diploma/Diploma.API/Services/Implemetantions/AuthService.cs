using AutoMapper;
using Diploma.API.Services.Interfaces;
using Diploma.Common.Constants;
using Diploma.Common.DTOs;
using Diploma.Common.DTOs.Auth;
using Diploma.Common.Settings;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.Entities.Linking;
using Diploma.Data.Entities.Main.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Diploma.API.Services.Implemetantions
{
	public class AuthService : IAuthService
	{
		private readonly AuthOptions authSettings;

		private readonly UserManager<User> userManager;
		private readonly IUnitOfWork unitOfWork;

		private readonly IMapper mapper;

		public AuthService(
			IOptions<AuthOptions> appSettings,
			UserManager<User> userManager,
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			authSettings = appSettings.Value;
			this.userManager = userManager;
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public async Task<UserDto> RegisterAsync(RegisterDto dto)
		{
			if (dto == null) throw new ArgumentNullException($"Dto cannot be null");

			var user = await userManager.FindByEmailAsync(dto.Email);
			if (user != null) throw new Exception($"Email: {dto.Email} is taken");

			user = mapper.Map<User>(dto);
			var creationResult = await userManager.CreateAsync(user, dto.Password);
			if (!creationResult.Succeeded)
				throw new Exception(string.Join(", ",
					creationResult.Errors.Select(x => x.Description)));

			await userManager.AddToRoleAsync(user, Roles.User);

			return await GetUserDtoWithTokenAsync(user);
		}

		public async Task<UserDto> LoginAsync(LoginDto dto)
		{
			if (dto == null) throw new ArgumentNullException($"Dto cannot be null");

			var user = await unitOfWork.UserRepository.GetAsync(dto.Email, true);
			if (user == null) throw new Exception("User not found");

			var valid = await userManager.CheckPasswordAsync(user, dto.Password);
			if (!valid) throw new Exception("Password is incorrect");

			return await GetUserDtoWithTokenAsync(user);
		}

		private async Task<UserDto> GetUserDtoWithTokenAsync(User user)
		{
			var lessons = user.UserLessons.ToDictionary(x => x.LessonId, x => x);
			var userDto = mapper.Map<UserDto>(user);
			userDto.Courses.ForEach(course =>
				course.Lessons.ForEach(lesson =>
					lesson.IsCompleted = lessons.ContainsKey(lesson.Id) && lessons[lesson.Id].IsCompleted
				)
			);
			userDto.Token = await GenerateEncodedTokenAsync(user);
			return userDto;
		}

		private async Task<string> GenerateEncodedTokenAsync(User user)
		{
			var roles = await userManager.GetRolesAsync(user);
			var claims = new[]
			{
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, string.Join(",", roles)),
			};

			var jwt = new JwtSecurityToken(
				issuer: authSettings.Issuer,
				audience: authSettings.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(authSettings.ExpiresInMinutes),
				signingCredentials: authSettings.SigningCredentials);

			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			return encodedJwt;
		}
	}
}
