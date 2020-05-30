using System.ComponentModel.DataAnnotations;

namespace Diploma.Common.DTOs.Auth
{
	public class RegisterDto : LoginDto
	{
		[Required]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
	}
}
