using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {

            //builder.HasKey(t => new { t.EmployeeId, t.ProjectId });
            //Ovo ne treba jer mora da ima svoj Id kao primarni

            builder.Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(1000)
                .IsRequired();
            builder.Property(t => t.StartDate)
                .IsRequired();

            builder.HasOne(t => t.Employee)
                .WithMany(e => e.EmployeeTasks)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(t => t.Project)
                .WithMany(p => p.ProjectTasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(t => t.Status)
                .WithMany(s=> s.StatusTasks)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
