namespace DocFlow.AuthService.Models
{
	public class RegisterRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string confirmPassword { get; set; }
		public string Email { get; set; }		
	}
}
