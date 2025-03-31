using ActivityService.Models.Entities;

namespace ActivityService.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }
        Task<int> CompleteAsync();
    }

}
