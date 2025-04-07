using ActivityService.Models.Bos;
using ActivityService.Models.Entities;

namespace ActivityService.Services
{
    public interface IActivityManager
    {
        Task<bool> AddActivityAsync(AddActivityBo addActivity);
        Task<IList<Activity>> SearchActivitiesAsync(string? name);
        Task<bool> RegisterActivityAsync(Guid activityId);
    }
}
