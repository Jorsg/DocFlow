using DocFlow.AuthService.Models;

namespace DocFlow.AuthService.Interfaces
{
	public interface IAuthServiceRepository
	{
		Task CreateUserAsync(User user);
		Task<User?> GetUserByEmailAsync(string email); 
	}
}
