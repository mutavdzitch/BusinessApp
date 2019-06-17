using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(s => s.Value)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasIndex(s => s.Value).IsUnique();

            builder.HasMany(s => s.StatusProjects)
                .WithOne(p => p.Status)
                .HasForeignKey(p => p.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.StatusTasks)
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
