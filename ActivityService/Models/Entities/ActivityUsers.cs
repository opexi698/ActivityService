namespace ActivityService.Models.Entities
{
    public class ActivityUser
    {
        public Guid ActivityId { get; set; }
        public virtual required Activity Activity { get; set; }

        public required string UserId { get; set; }
        public virtual required ApplicationUser User { get; set; }
    }
}
