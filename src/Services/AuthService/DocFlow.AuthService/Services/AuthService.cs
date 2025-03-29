using DocFlow.AuthService.Models;
using DocFlow.AuthService.Repositories;
using DocFlow.AuthService.DTOs;
using DocFlow.AuthService.Interfaces;
using MongoDB.Driver;
using DocFlow.AuthService.Helpers;

namespace DocFlow.AuthService.Services
{
	public class AuthService : IAuthService
	{
		private readonly IAuthServiceRepository _authServiceRepository;
		private readonly JwtService _jwtService;
		public AuthService(IAuthServiceRepository authServiceRepository, JwtService jwtService)
		{
			_authServiceRepository = authServiceRepository;
			_jwtService = jwtService;
		}

		public async Task<(bool Succes, string Message, string? Token)> LoginUserAsync(LoginUserDto dto)
		{
			var user = await _authServiceRepository.GetUserByEmailAsync(dto.Email);
			if (user == null)
			{
				return (false, "Ivalid email or password", null);
			}

			var isPasswordValid = PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash);
			if (!isPasswordValid)
			{
				return (false, "Ivalid email or password", null);
			}

			var toke = _jwtService.GenerateToken(user);

			return (true, "user logged in successfully", toke);
		}

		public async Task<(bool Succes, string Message)> RegisterUserAsync(RegisterUserDTO dto)
		{
			var existingUser = await _authServiceRepository.GetUserByEmailAsync(dto.Email);
			if(existingUser != null)
			{
				return (false, "user already exists");
			}
			if(dto.Password != dto.ConfirmPassword)
			{
				return (false, "passwords do not match");
			}

			var hashPasswd = PasswordHasher.HashPassword(dto.Password);

			var newUser = new User
			{
				Username = dto.Username,
				Email = dto.Email,
				PasswordHash = hashPasswd
			};

			await _authServiceRepository.CreateUserAsync(newUser);

			return (true, "user registered successfully");
		}
	}
}
