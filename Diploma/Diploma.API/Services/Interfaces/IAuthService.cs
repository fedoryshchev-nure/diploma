using Diploma.Common.DTOs;
using Diploma.Common.DTOs.Auth;
using System.Threading.Tasks;

namespace Diploma.API.Services.Interfaces
{
	public interface IAuthService
	{
		public Task<UserDto> RegisterAsync(RegisterDto dto);
		public Task<UserDto> LoginAsync(LoginDto dto);
	}
}
