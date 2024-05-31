using System.ComponentModel.DataAnnotations;

namespace CommunityEventPlanner.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
    }
}