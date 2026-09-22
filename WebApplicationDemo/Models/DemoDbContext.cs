using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class DemoDbContext:DbContext
    {
       public DemoDbContext() { }
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);
            
            optionsBuilder.UseSqlServer(@"Data Source=IN-LT-18076\LOCALHOST;Initial Catalog=MYDB;Persist Security Info=True;User ID=sa;Password=Prescribing4Care;MultipleActiveResultSets=True");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
                entity.Property(t => t.Country_Name).IsRequired();
            });
            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");
                entity.Property(t => t.State_Name).IsRequired();
                entity.HasOne(t => t.Country).WithMany(t=>t.States).HasForeignKey(t=>t.Country_Id).HasConstraintName("Fk=State_country");
                
            });
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
                entity.Property(t => t.City_Name).IsRequired();
                entity.HasOne(t => t.State).WithMany(t => t.Cities).HasForeignKey(t=>t.State_Id).HasConstraintName("Fk=City_State");

            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                

                entity.HasOne(t => t.City).WithMany(t => t.Employees).HasForeignKey(t => t.CityId).HasConstraintName("Fk=Employee_City");

            });

        }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        
        public DbSet<Employee> Employee { get; set; }
    }
}
