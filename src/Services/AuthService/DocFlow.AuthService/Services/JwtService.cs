using DocFlow.AuthService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace DocFlow.AuthService.Services
{
	public class JwtService
	{
		private readonly JwtSettings _jwtSettings;
		private readonly IConfiguration _configuration;

		public JwtService(IConfiguration configuration)
		{
			_configuration = configuration;		
		}

		public string GenerateToken(User user)
		{
			//_jwtSettings.Secret = _configuration["JwtSettings:Secret"];
			//_jwtSettings.Issuer = _configuration["JwtSettings:Issuer"];
			//_jwtSettings.Audience = _configuration["JwtSettings:Audience"];

			var claim = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(ClaimTypes.Role, user.Role.ToString()), 
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["JwtSettings:Issuer"],
				audience: _configuration["JwtSettings:Audience"],
				claims: claim,
				expires: DateTime.Now.AddHours(1),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);

		}
	}
}
