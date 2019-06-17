using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Address)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();
            builder.Property(c => c.BankAccount)
                .HasMaxLength(17)
                .IsRequired();
            builder.Property(c => c.WebSite)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasOne(e => e.City)
                .WithMany(c => c.CityCompanies)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.CompanyEmployees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.CompanyProjects)
                .WithOne(cp => cp.Company)
                .HasForeignKey(cp => cp.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
