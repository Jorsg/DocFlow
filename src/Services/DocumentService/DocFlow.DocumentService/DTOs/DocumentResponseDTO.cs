namespace DocFlow.AuthService.DTOs
{
	public record DocumentResponseDTO
	(
		string Id,
		string FileName,
		string OriginalName,
		string Category,
		string? Description,
		DateTime UploadDate,
		string FileUrl
	);
}
