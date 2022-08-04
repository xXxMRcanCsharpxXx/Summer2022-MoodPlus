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
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Summer2022_MoodPlus;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entry>().HasData(
            //    new Entry() { Id = 1, PatientId = 1, Date = DateTime.Now },
            //    new Entry() { Id = 2, PatientId = 2, Date = DateTime.Now }
            //    );
            modelBuilder.Entity<User>().HasData(
                new User() { Id="test", UserName="test", Password="text", Email="text"}
                );
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id=1, UserId="test", Streak=0, LongestStreak=0}
           
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MoodPlus.Data.TempEntry>? TempEntry { get; set; }
    }
}