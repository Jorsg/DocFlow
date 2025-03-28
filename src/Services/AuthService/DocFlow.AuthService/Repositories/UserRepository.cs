using DocFlow.AuthService.Data;
using DocFlow.AuthService.Interfaces;
using DocFlow.AuthService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DocFlow.AuthService.Repositories
{
	public class UserRepository : IAuthServiceRepository
	{
		private readonly IMongoCollection<User> _users;		

		public UserRepository(MongoDbContext context)
		{
			_users = context.Users;

		}

		public async Task CreateUserAsync(User user)
		{
			await _users.InsertOneAsync(user);
		}

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
		}
	}
}
