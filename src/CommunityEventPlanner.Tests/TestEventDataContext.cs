using CommunityEventPlanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CommunityEventPlanner.Tests
{
    public class TestEventDataContext : EventDataContext
    {
        public TestEventDataContext(DbContextOptions<EventDataContext> options)
            : base(new ConfigurationBuilder().Build()) // Pass an empty configuration
        {
            Options = options;
        }

        public DbContextOptions<EventDataContext> Options { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Options != null)
            {
                optionsBuilder.UseInMemoryDatabase("TestDatabase");
            }
        }
    }
}