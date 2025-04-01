using DocFlow.AuthService.DTOs;
using DocFlow.AuthService.Interfaces;
using DocFlow.AuthService.Models;

namespace DocFlow.AuthService.Services
{
	public class DocumentService : IDocuementService
	{
		private readonly IDocumentRepository _documentRepository;

		public DocumentService(IDocumentRepository documentRepository)
		{
			_documentRepository = documentRepository;
		}

		public async Task DeleteDocumentAsync(string documentId)
		{
			await _documentRepository.DeleteDocumentAsync(documentId);
		}

		public async Task<IEnumerable<DocumentResponseDTO>> GetUserDocumentsAsync(string userId)
		{
			var document = await _documentRepository.GetDocumentsByUserIdAsync(userId);

			return document.Select(d => new DocumentResponseDTO(
				d.Id!,
				d.FileName,
				d.OriginalName,
				d.Category,
				d.Description,
				d.UploadDate,
				d.FileUrl)).ToList();
		}

		public async Task<DocumentResponseDTO> UploadDocumentAsync(string userid, UploadDocumentDTO dto, string fileUrl)
		{
			var document = new Document
			{
				UserId = userid,
				FileName = dto.FileName,
				OriginalName = dto.OriginalName,
				Category = dto.Category,
				Description = dto.Description,
				UploadDate = DateTime.Now,
				FileUrl = fileUrl
			};

			await _documentRepository.CreateDocumentAsync(document);

			return new DocumentResponseDTO(
				document.Id!,
				document.FileName,
				document.OriginalName,
				document.Category,
				document.Description,
				document.UploadDate,
				document.FileUrl);
		}
	}
}
