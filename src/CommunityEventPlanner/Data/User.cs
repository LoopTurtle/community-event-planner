using System.ComponentModel.DataAnnotations;

namespace CommunityEventPlanner.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string? Password { get; set; }
    }
}