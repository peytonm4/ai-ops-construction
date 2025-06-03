using Microsoft.EntityFrameworkCore;
using AiOpsPlatform.API.Models;

namespace AiOpsPlatform.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Job> Jobs => Set<Job>();
    }
}
