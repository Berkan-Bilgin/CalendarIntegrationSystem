using Core.Utilities.Hashing;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEntity = Domain.Entities.Task;


namespace Persistence.Contexts
{
    public class CalendarIntegrationSystemDbContext : DbContext
    {
        public CalendarIntegrationSystemDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Calendar; Trusted_Connection=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var firstUserId = Guid.NewGuid();
            var secondUserId = Guid.NewGuid();
            byte[] passwordHash1, passwordSalt1;
            HashingHelper.CreatePasswordHash("123456", out passwordHash1, out passwordSalt1);

            byte[] passwordHash2, passwordSalt2;
            HashingHelper.CreatePasswordHash("123456", out passwordHash2, out passwordSalt2);

            // Seed data for User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = firstUserId,
                    UserName = "john_doe",
                    Email = "john@example.com",
                    CreatedDate = DateTime.UtcNow,
                    PasswordHash = passwordHash1,
                    PasswordSalt = passwordSalt1
                },
                new User
                {
                    Id = secondUserId,
                    UserName = "jane_doe",
                    Email = "jane@example.com",
                    CreatedDate = DateTime.UtcNow,
                    PasswordHash = passwordHash2,
                    PasswordSalt = passwordSalt2
                }
            );

            // Seed data for Event
            modelBuilder.Entity<Event>().HasData(
               new Event { Id = Guid.NewGuid(), Title = "Event 1", StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddHours(2), CreatedDate = DateTime.UtcNow, UserId = firstUserId },
               new Event { Id = Guid.NewGuid(), Title = "Event 2", StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddHours(3), CreatedDate = DateTime.UtcNow, UserId = secondUserId }
           );

            // Seed data for TaskEntity
            modelBuilder.Entity<TaskEntity>().HasData(
                 new TaskEntity { Id = Guid.NewGuid(), Title = "Task 1", StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddHours(8), Status = Domain.Entities.TaskStatus.Pending, UserId = firstUserId }
             );
        }
    }
}

