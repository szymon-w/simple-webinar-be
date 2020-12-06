using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Models
{
    public class SimpleWebinarDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Webinar> Webinar { get; set; }
        public DbSet<UserWebinar> UserWebinar { get; set; }

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
        }

    }
}
