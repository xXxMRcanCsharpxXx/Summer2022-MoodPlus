using Microsoft.AspNetCore.Identity;

namespace MoodPlus.Models
{
    public class Account : IdentityUser
    {
        public string Id { 
            get 
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }
        public string Name { get; set; }
        public string? UserGoal { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
