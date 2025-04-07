namespace ActivityService.Models.Entities
{
    public class ActivityUser
    {
        public Guid ActivityId { get; set; }
        public virtual Activity? Activity { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
