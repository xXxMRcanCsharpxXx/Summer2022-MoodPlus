using Microsoft.AspNetCore.Identity;

namespace MoodPlus.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? UserGoal { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
