using DocFlow.AuthService.DTOs;
using DocFlow.AuthService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> RegisterUserAsync(RegisterUserDTO dto)
		{
			var result = await _authService.RegisterUserAsync(dto);
			if (!result.Succes)
			{
				return BadRequest(new {message = result.Message});
			}
			return Ok(new {message = result.Message});
		}

		[HttpPost("Login")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> LoginUserAsync(LoginUserDto dto)
		{
			var result = await _authService.LoginUserAsync(dto);
			if (!result.Succes)
			{
				return Unauthorized(new { message = result.Message });
			}

			// Create a token

			return Ok(new
			{
				message = result.Message,
				token = result.Token
			});
		}

		[HttpGet("me")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetCurrentUser()
		{
			var email = User.FindFirst(ClaimTypes.Email)?.Value;
			var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var role = User.FindFirst(ClaimTypes.Role)?.Value;
			return Ok(new { id, email, role });
		}
	}
}
