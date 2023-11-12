using AVIDI.ApiService.Data.Configuration;
using AVIDI.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace AVIDI.ApiService.Data.DbContexts
{
    public class AVIDIDbContext : DbContext
    {
        public DbSet<DateEvent> DataEvents { get; set; }

        public DbSet<Event> Events { get; set; }

        public AVIDIDbContext(DbContextOptions<AVIDIDbContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EventConfig());
        }
    }
}
