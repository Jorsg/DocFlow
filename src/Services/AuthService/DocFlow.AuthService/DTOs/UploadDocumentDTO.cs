namespace DocFlow.AuthService.DTOs
{
	public record UploadDocumentDTO(

		string OriginalName,
		string Category,
		string? Description,
		string FileName
	);
}
