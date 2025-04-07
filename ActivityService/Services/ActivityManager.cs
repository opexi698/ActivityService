using ActivityService.Models.Bos;
using ActivityService.Models.Entities;
using ActivityService.Repositories.Interfaces;
using System.Security.Claims;

namespace ActivityService.Services
{
    public class ActivityManager : IActivityManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ActivityManager(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddActivityAsync(AddActivityBo addActivity)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var activity = new Activity()
            {
                Id = Guid.CreateVersion7(),
                Name = addActivity.Name,
                StartDate = addActivity.StartDate,
                EndDate = addActivity.EndDate,
                Address = addActivity.Address,
                Price = addActivity.Price,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdateBy = userId,
                UpdatedDate = DateTime.Now,
            };

            await _unitOfWork.Activies.AddAsync(activity);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<IList<Activity>> SearchActivitiesAsync(string? name)
        {
            var activities = new List<Activity>();

            if (!string.IsNullOrEmpty(name))
            {
                activities.AddRange(await _unitOfWork.Activies.GetAsync(a => a.Name == name));
            }

            return activities;
        }

        public async Task<bool> RegisterActivityAsync(Guid activityId)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var activityUser = new ActivityUser()
            {
                ActivityId = activityId,
                UserId = userId,
            };
            await _unitOfWork.ActivityUsers.AddAsync(activityUser);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}