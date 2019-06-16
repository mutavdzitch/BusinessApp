using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();
            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.HasIndex(p => p.Title).IsUnique();

            builder.HasOne(p => p.Status)
                .WithMany(s => s.StatusProjects)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(p => p.ProjectCompanies)
                .WithOne(pc => pc.Project)
                .HasForeignKey(pc => pc.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ProjectEmployees)
                .WithOne(ep => ep.Project)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ProjectTasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
