using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class VocationConfiguration : IEntityTypeConfiguration<Vocation>
    {
        public void Configure(EntityTypeBuilder<Vocation> builder)
        {
            builder.Property(v => v.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(v => v.Name).IsUnique();

            builder.HasMany(v => v.VocationEmployees)
                .WithOne(e => e.Vocation)
                .HasForeignKey(e => e.VocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
