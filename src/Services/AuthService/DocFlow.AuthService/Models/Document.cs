using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocFlow.AuthService.Models
{
	public class Document
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("UserId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string UserId { get; set; }

		[BsonElement("fileName")]
		public string FileName { get; set; }

		[BsonElement("originalName")]
		public string OriginalName { get; set; }

		[BsonElement("Category")]
		public string Category { get; set; }

		[BsonElement("description")]
		public string? Description { get; set; }

		[BsonElement("uploadDate")]
		public DateTime UploadDate { get; set; } = DateTime.UtcNow;

		[BsonElement("fileUrl")]
		public string FileUrl { get; set; }
	}
}
