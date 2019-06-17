using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using EfDataAccess.Configurations;

namespace EfDataAccess
{
    public class BusinessContext : DbContext
    {
        //Tabele
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vocation> Vocations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<ProjectCompany> ProjectCompany { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Konekcioni string sa bazom
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5OHOBEE\SQLEXPRESS;Initial Catalog=BusinessAppDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primenjivanje konfiguracije
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new VocationConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
