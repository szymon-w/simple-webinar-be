using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Models
{
    public class SimpleWebinarDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Webinar> Webinars { get; set; }
        public DbSet<UserWebinar> UserWebinars { get; set; }

        public SimpleWebinarDbContext()
        {
        }

        public SimpleWebinarDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder.Entity<Webinar>()
                .HasIndex(u => u.Code)
                .IsUnique();

            modelBuilder.Entity<UserWebinar>()
              .HasIndex(p => new { p.IdUser, p.IdWebinar }).IsUnique();
        }

    }
}
