using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocFlow.AuthService.Models
{
	public class User
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("username")]
		public string Username { get; set; }

		[BsonElement("passwordHash")]
		public string PasswordHash { get; set; } 

		[BsonElement("role")]
		[BsonRepresentation(BsonType.String)]
		public UserRole Role { get; set; } = UserRole.user;

		[BsonElement("email")]
		public string Email { get; set; }
		[BsonElement("createAt")]
		public DateTime CreateAt { get; set; } = DateTime.UtcNow;
	}
}
