using DocFlow.AuthService.Data;
using DocFlow.AuthService.Interfaces;
using MongoDB.Driver;
using DocFlow.AuthService.Models;
using MongoDB.Bson;
using DocFlow.AuthService.Helpers;

namespace DocFlow.AuthService.Repositories
{
	public class DocumetRepository: IDocumentRepository
	{
		private readonly IMongoCollection<Document> _documents;

		public DocumetRepository(MongoDbContext context)
		{
			_documents = context.Documents;
		}

		public async Task CreateDocumentAsync(Document document)
		{
			await _documents.InsertOneAsync(document);
		}

		public async Task DeleteDocumentAsync(string id)
		{			
			var objectId = MongoObjectIdToStringConverter.ConvertStringToObjectId(id);// ConvertString To ObjectId MongoDB;

			await _documents.DeleteOneAsync(d => d.UserId == objectId.ToString());
		}

		public async Task<Document?> GetDocumentByIdAsync(string id)
		{
			return await _documents.Find(d => d.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Document>> GetDocumentsAsync()
		{
			return await _documents.Find(d => true).ToListAsync();
		}

		public async Task<IEnumerable<Document>> GetDocumentsByUserIdAsync(string userId)
		{
			return await _documents.Find(d => d.UserId == userId).ToListAsync();
		}
	}
}
