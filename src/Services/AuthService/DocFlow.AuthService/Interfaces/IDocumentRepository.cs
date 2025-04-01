using DocFlow.AuthService.Models;

namespace DocFlow.AuthService.Interfaces
{
	public interface IDocumentRepository
	{
		Task CreateDocumentAsync(Document document);
		Task<Document?> GetDocumentByIdAsync(string id);
		Task<IEnumerable<Document>> GetDocumentsAsync();
		Task<IEnumerable<Document>> GetDocumentsByUserIdAsync(string userId);
		Task DeleteDocumentAsync(string id);
	}
}
