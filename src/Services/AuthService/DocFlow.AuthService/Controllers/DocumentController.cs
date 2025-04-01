using DocFlow.AuthService.DTOs;
using DocFlow.AuthService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DocFlow.AuthService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class DocumentController : ControllerBase
	{
		private readonly IDocuementService _documentService;
		private readonly IConfiguration _configuration;

		public DocumentController(IDocuementService documentService, IConfiguration configuration)
		{
			_documentService = documentService;
			_configuration = configuration;
		}

		[HttpPost("upload")]
		[ProducesResponseType(typeof(DocumentResponseDTO),(int)StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UploadDocumentAsync([FromForm] UploadDocumentDTO dto, IFormFile file)
		{
			if (file == null || file.Length == 0)
				return BadRequest(new { message = "File is required" });

			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var ulrStorage = $"{_configuration["ConnectionString"]}{file.Name}";

			var response = await _documentService.UploadDocumentAsync(userId, dto, ulrStorage);

			return response != null ? Ok(response) : BadRequest(new { message = "Failed to upload document" });
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<DocumentResponseDTO>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetUserDocumentsAsync()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var documents = await _documentService.GetUserDocumentsAsync(userId);
			return Ok(documents);
		}
	}
}
