using DocFlow.AuthService.DTOs;
using DocFlow.AuthService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocFlow.AuthService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterUserAsync(RegisterUserDTO dto)
		{
			var result = await _authService.RegisterUserAsync(dto);
			if (!result.Succes)
			{
				return BadRequest(new {message = result.Message});
			}
			return Ok(new {message = result.Message});
		}
	}
}
