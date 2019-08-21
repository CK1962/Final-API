using FosterCareAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FosterCareAPI.Infrastructure.Data
{
    public class FosterDbContext : DbContext
    {
        public DbSet<Children> Child { get; set; }

       // public DbSet<House> Home { get; set; }

         //public DbSet<Appointment> Appts { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Children>().HasData(
                new Children { Id = 1, Name = "Ashton", Dob = "01/01/01", MoveInDate = "08/08/08" });

            //modelBuilder.Entity<Appointment>().HasData(
             //   new Appointment { Id = 1, Type = "Medical", DrName = "Vuelvas" });

            //modelBuilder.Entity<House>().HasData(
            //    new House { Id = 1, Name = "Keslin", City = "Lubbock"});
         }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=../FosterCareAPI.Infrastructure/Children.db");
        }
    }
}
