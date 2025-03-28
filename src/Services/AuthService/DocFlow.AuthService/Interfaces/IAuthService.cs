using DocFlow.AuthService.DTOs;

namespace DocFlow.AuthService.Interfaces
{
	public interface IAuthService
	{
		Task<(bool Succes, string Message)> RegisterUserAsync(RegisterUserDTO dto);

	}
}
