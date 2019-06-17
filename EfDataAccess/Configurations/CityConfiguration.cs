using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.PostalCode)
                .HasMaxLength(5)
                .IsRequired();

            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasIndex(c => c.PostalCode).IsUnique();

            builder.HasMany(c => c.CityCompanies)
                .WithOne(c => c.City)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
