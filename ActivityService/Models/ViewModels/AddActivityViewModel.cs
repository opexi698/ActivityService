namespace ActivityService.Models.ViewModels
{
    public class AddActivityViewModel
    {
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Address { get; set; }
        public decimal Price { get; set; }
    }
}
