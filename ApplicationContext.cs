using System;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntityFrameworkConsole
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<BusinessTrip> BusinessTrips => Set<BusinessTrip>();
        public DbSet<VacationType> VacationTypes => Set<VacationType>();
        public DbSet<Vacation> Vacations => Set<Vacation>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=database;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessTrip>()
                .Property(b => b.DaysCount)
                .HasComputedColumnSql($"DATEDIFF(day, StartDate, EndDate)");
            modelBuilder.Entity<Vacation>()
                .Property(b => b.DaysCount)
                .HasComputedColumnSql($"DATEDIFF(day, StartDate, EndDate)");

        }
    }
}
