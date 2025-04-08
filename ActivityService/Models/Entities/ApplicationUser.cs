using Microsoft.AspNetCore.Identity;

namespace ActivityService.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? Birthday { get; set; }
        public string? School { get; set; }
        public string? Major { get; set; }
        public Gender? Gender { get; set; }
        public required string IdCardNumber { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}