using Microsoft.IdentityModel.Tokens;

namespace Diploma.Common.Settings
{
	public class AuthOptions
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }

		public int ExpiresInMinutes { get; set; }

		public string Secret { get; set; }
		public SigningCredentials SigningCredentials { get; set; }
	}
}
