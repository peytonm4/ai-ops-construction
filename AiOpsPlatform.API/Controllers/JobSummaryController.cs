using Microsoft.AspNetCore.Mvc;
using AiOpsPlatform.API.Models;
using AiOpsPlatform.API.Services;
using AiOpsPlatform.API.Data; 


namespace AiOpsPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobSummaryController : ControllerBase
    {
        private readonly OpenAiService _openAi;
        private readonly AppDbContext _db;

        public JobSummaryController(OpenAiService openAi, AppDbContext db)
        {
            _openAi = openAi;
            _db = db;
        }


        [HttpPost("summarize")]
        public async Task<IActionResult> SummarizeJob([FromBody] JobNoteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NoteText))
                return BadRequest("Note text is required.");

            // 1. Get AI summary (stubbed or real)
            var summary = await _openAi.GenerateSummaryAsync(dto.NoteText);

            // 2. Create and save Job
            var job = new Job
            {
                Name = dto.JobName,
                Summary = summary,
                CreatedAt = DateTime.UtcNow
            };

            _db.Jobs.Add(job);
            await _db.SaveChangesAsync();

            // 3. Return full job
            return Ok(job);
        }

    }
}
