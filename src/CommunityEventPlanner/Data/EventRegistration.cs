using System.ComponentModel.DataAnnotations;

namespace CommunityEventPlanner.Data
{
    public class EventRegistration
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public int UserId { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}