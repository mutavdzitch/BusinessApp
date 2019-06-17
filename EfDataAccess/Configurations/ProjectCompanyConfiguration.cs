using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class ProjectCompanyConfiguration : IEntityTypeConfiguration<ProjectCompany>
    {
        public void Configure(EntityTypeBuilder<ProjectCompany> builder)
        {
            builder.HasKey(pc => new { pc.ProjectId, pc.CompanyId });

            builder.HasOne(pc => pc.Project)
                    .WithMany(p => p.ProjectCompanies)
                    .HasForeignKey(pc => pc.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Company)
                    .WithMany(p => p.CompanyProjects)
                    .HasForeignKey(pc => pc.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
