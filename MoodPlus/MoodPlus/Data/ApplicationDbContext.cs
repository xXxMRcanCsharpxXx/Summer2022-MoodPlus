using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoodPlus.Models;
using MoodPlus.Data;

namespace MoodPlus.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Entry> Entries { get; set; }
        public DbSet<MoodRating> MoodRatings { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Summer2022_MoodPlus;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                    new Account() { Id = "test", Email = "test", Password = "test", Name = "test"}
                );
            modelBuilder.Entity<Patient>().HasData(
                    new Patient() { Id = 1, AccountId = "test", Streak = 0, LongestStreak = 0}
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}