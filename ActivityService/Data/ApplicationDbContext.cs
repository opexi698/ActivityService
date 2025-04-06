using ActivityService.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActivityService.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityUser> ActivityUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Activity>()
                   .HasKey(a => a.Id);

            builder.Entity<Activity>()
                   .Property(a => a.Price)
                   .HasPrecision(18, 2);

            builder.Entity<ActivityUser>()
                   .HasKey(au => new { au.ActivityId, au.UserId });

            builder.Entity<ActivityUser>()
                   .HasOne(au => au.Activity)
                   .WithMany(a => a.ActivityUsers)
                   .HasForeignKey(au => au.ActivityId);

            builder.Entity<ActivityUser>()
                   .HasOne(au => au.User)
                   .WithMany()
                   .HasForeignKey(au => au.UserId);
        }
    }
}