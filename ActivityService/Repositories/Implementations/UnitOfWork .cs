using ActivityService.Data;
using ActivityService.Models.Entities;
using ActivityService.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace ActivityService.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<ApplicationUser> Users { get; private set; }
        public IRepository<IdentityRole> Roles { get; private set; }
        public IRepository<Activity> Activies { get; private set; }
        public IRepository<ActivityUser> ActivityUsers { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new Repository<ApplicationUser>(_context);
            Roles = new Repository<IdentityRole>(_context);

            Activies = new Repository<Activity>(_context);
            ActivityUsers = new Repository<ActivityUser>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}