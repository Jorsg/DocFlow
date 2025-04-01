using MongoDB.Driver;
using DocFlow.AuthService.Models;
using Microsoft.Extensions.Options;

namespace DocFlow.AuthService.Data
{
	public class MongoDbContext
	{
		private readonly IMongoDatabase _database;

		public MongoDbContext(IOptions<MongoDbSettings> settings)
		{
			var client = new MongoClient(settings.Value.ConnectionString);
			_database = client.GetDatabase(settings.Value.DatabaseName);
		}

		public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
		public IMongoCollection<Document> Documents => _database.GetCollection<Document>("Documents");
	}
}
