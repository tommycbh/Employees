using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Employees.Core.Entities;
using Employees.EntityFramework.Seed;

namespace Employees.EntityFramework
{
    public class EmployeesDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Region> Regions { get; set; }

        public EmployeesDbContext() 
            : base("name=EmployeesDbConnection")
        {
            Database.SetInitializer<EmployeesDbContext>(new EmployeesDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Region>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Region>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Employees)
                .WithRequired(e => e.Region);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Children)
                .WithOptional(e => e.Parent);
        }
    }
}
