namespace ActivityService.Models.Entities
{
    public abstract class EntityBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public required string CreatedBy { get; set; }
        public virtual ApplicationUser? CreatedByUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public required string UpdateBy { get; set; }
        public virtual ApplicationUser? UpdatedByUser { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}