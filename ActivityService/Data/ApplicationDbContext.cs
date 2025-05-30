﻿using ActivityService.Models.Entities;
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

            builder.Entity<Activity>()
                   .HasOne(a => a.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Activity>()
                   .HasOne(a => a.UpdatedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.UpdateBy)
                   .OnDelete(DeleteBehavior.Restrict);

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

            builder.Entity<ApplicationUser>()
                   .Property(u => u.IdCardNumber)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Entity<ApplicationUser>()
                   .HasIndex(u => u.IdCardNumber)
                   .IsUnique();
        }
    }
}