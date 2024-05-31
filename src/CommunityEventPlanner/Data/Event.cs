using System.ComponentModel.DataAnnotations;

namespace CommunityEventPlanner.Data
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a description of the event.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please select a date for the event.")]
        [DataType(DataType.Date)]
        public DateOnly? Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = "Please enter a start time for the event.")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Start time must be in HH:mm format.")]
        public string? StartTime { get; set; }

        [Required(ErrorMessage = "Please enter the organiser username.")]
        public string? OrganiserUsername { get; set; }
    }
}
