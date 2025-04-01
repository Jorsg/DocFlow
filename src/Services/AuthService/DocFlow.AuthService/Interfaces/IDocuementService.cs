using DocFlow.AuthService.DTOs;

namespace DocFlow.AuthService.Interfaces
{
	public interface IDocuementService
	{
		Task<DocumentResponseDTO> UploadDocumentAsync(string userid, UploadDocumentDTO dto, string fileUrl);
		Task<IEnumerable<DocumentResponseDTO>> GetUserDocumentsAsync(string userId);
		Task DeleteDocumentAsync(string documentId);
	}
}
