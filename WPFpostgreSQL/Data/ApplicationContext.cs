
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFpostgreSQL.Data
{
    public class ApplicationContext : DbContext
    {
        #region Constructor
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #endregion

        #region Public properties
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        #endregion

        #region Overridden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUsers());
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Profile>().HasData(GetProfiles());
            modelBuilder.Entity<Profile>().ToTable("Profiles");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
    .HasOne(a => a.Profile)
    .WithOne(b => b.ProfileOf)
    .HasForeignKey<Profile>(b => b.UserId);

        }
        #endregion

        #region Private methods
        private User[] GetUsers()
        {
            return new User[]
            {
            new User { Id = 1, UserName = "admin", UserInfo = "Blue T-shirt"},
            new User { Id = 2, UserName = "user2", UserInfo = "Formal Shirt"},
            new User { Id = 3, UserName = "user3", UserInfo = "Wollen"},
            new User { Id = 4, UserName = "user4", UserInfo = "Red"},
            };
        }

        private Profile[] GetProfiles()
        {
            return new Profile[]
            {
            new Profile { Id = 1, UserId = 1, Name = "Blue Color", Info = "Color"},
            new Profile { Id = 2, UserId = 2, Name = "Formal Shirt", Info = "Color"},
            new Profile { Id = 3, UserId = 3, Name = "Wollen", Info = "Color"},
            new Profile { Id = 4, UserId = 4, Name = "Red", Info = "Color"},
            };
        }
        #endregion
    }
}
