using Microsoft.AspNetCore.Mvc;
using AiOpsPlatform.API.Models;
using AiOpsPlatform.API.Services;

namespace AiOpsPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobSummaryController : ControllerBase
    {
        private readonly OpenAiService _openAi;

        public JobSummaryController(OpenAiService openAi)
        {
            _openAi = openAi;
        }

        [HttpPost("summarize")]
        public async Task<IActionResult> SummarizeJob([FromBody] JobNoteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NoteText))
                return BadRequest("Note text is required.");

            var summary = await _openAi.GenerateSummaryAsync(dto.NoteText);
            return Ok(new { summary });
        }
    }
}
