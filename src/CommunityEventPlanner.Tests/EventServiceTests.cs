using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunityEventPlanner.Data;
using Xunit;

namespace CommunityEventPlanner.Tests
{
    public class EventServiceTests
    {
        [Fact]
        public async Task CreateEvent_AddsEventToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventDataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestEventDataContext(options); // Use the derived context
            var service = new EventService(context);

            var newEvent = new Event
            {
                Description = "Test Event",
                Date = DateOnly.FromDateTime(DateTime.Now),
                StartTime = "10:00",
                OrganiserUsername = "testuser"
            };

            // Act
            await service.CreateEventAsync(newEvent);

            // Assert
            var createdEvent = await context.Events.FirstOrDefaultAsync(e => e.Description == "Test Event");
            Assert.NotNull(createdEvent);
            Assert.Equal("Test Event", createdEvent.Description);
        }

        [Fact]
        public async Task GetEvents_ReturnsEventsFromDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventDataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new TestEventDataContext(options); // Use the derived context
            var service = new EventService(context);

            // Add sample events to the database
            await context.Events.AddRangeAsync(new List<Event>
            {
                new Event { Description = "Event 1", Date = DateOnly.FromDateTime(DateTime.Now), StartTime = "10:00", OrganiserUsername = "user1" },
                new Event { Description = "Event 2", Date = DateOnly.FromDateTime(DateTime.Now), StartTime = "11:00", OrganiserUsername = "user2" },
                new Event { Description = "Event 3", Date = DateOnly.FromDateTime(DateTime.Now), StartTime = "12:00", OrganiserUsername = "user3" }
            });
            await context.SaveChangesAsync();

            // Act
            var events = await service.GetEventsAsync();

            // Assert
            Assert.NotNull(events);
            Assert.Equal(3, events.Count()); // Ensure that all sample events are retrieved
        }
    }

    // Mock implementation of EventService
    public class EventService
    {
        private readonly EventDataContext _context;

        public EventService(EventDataContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }
    }
}