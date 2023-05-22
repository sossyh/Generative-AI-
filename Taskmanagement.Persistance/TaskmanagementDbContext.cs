using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Domain;
using Taskmanagement.Domain.Common;
using Taskmanagement.Domain;

namespace Taskmanagement.Persistence
{
    public class TaskmanagementDbContext : DbContext
    {
        
        public DbSet<User> User { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Checklist> Checklist { get; set; }

        
        
        public TaskmanagementDbContext(DbContextOptions<TaskmanagementDbContext> options)
           : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            // AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Task>()
                .HasMany(t => t.Checklists)
                .WithOne(c => c.Task)
                .HasForeignKey(c => c.AssociatedTaskId)
                .IsRequired();

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.OwnerId)
                .IsRequired();

            modelBuilder.Entity<Checklist>()
                .HasOne(c => c.Task)
                .WithMany(t => t.Checklists)
                .HasForeignKey(c => c.AssociatedTaskId)
                .IsRequired();

            modelBuilder.Entity<Checklist>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Checklists)
                .HasForeignKey(c => c.OwnerId)
                .IsRequired();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskmanagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }

    }
}
