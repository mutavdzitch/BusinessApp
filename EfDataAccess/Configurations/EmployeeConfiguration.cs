using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(e => e.Username)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.Password)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(e => e.Username).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();

            builder.HasOne(e => e.Company)
                .WithMany(c => c.CompanyEmployees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Vocation)
                .WithMany(c => c.VocationEmployees)
                .HasForeignKey(e => e.VocationId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(p => p.EmployeeProjects)
                .WithOne(ep => ep.Employee)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
