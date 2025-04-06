namespace ActivityService.Models.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ActivityUser> ActivityUsers { get; set; }
        public Activity()
        {
            ActivityUsers = new HashSet<ActivityUser>();
        }
    }
}
