using DocFlow.AuthService.DTOs;
using DocFlow.AuthService.Models;

namespace DocFlow.AuthService.Interfaces
{
	public interface IAuthService
	{
		Task<(bool Succes, string Message)> RegisterUserAsync(RegisterUserDTO dto);
		Task<(bool Succes, string Message, string? Token)> LoginUserAsync(LoginUserDto dto); 

	}
}
