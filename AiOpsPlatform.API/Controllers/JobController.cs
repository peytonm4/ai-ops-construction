using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AiOpsPlatform.API.Data;
using AiOpsPlatform.API.Models;

namespace AiOpsPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly AppDbContext _db;

        public JobController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            return await _db.Jobs.OrderByDescending(j => j.CreatedAt).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await _db.Jobs.FindAsync(id);
            if (job == null) return NotFound();
            return job;
        }

        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob([FromBody] Job job)
        {
            _db.Jobs.Add(job);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }
    }
}
