using ActivityService.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ActivityService.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<IdentityRole> Roles { get; }
        IRepository<Activity> Activies { get; }
        IRepository<ActivityUser> ActivityUsers { get; }

        Task<int> CompleteAsync();
    }
}