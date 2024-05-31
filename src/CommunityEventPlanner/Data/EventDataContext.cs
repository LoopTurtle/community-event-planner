using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CommunityEventPlanner.Data
{
    public class EventDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public EventDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("EventsDB"));
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
    }
}