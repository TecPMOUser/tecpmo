using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class ProjectDetailsMapping : EntityTypeConfiguration<ProjectDetails>
    {
        public ProjectDetailsMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProjectID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ESAProjectName)
                .HasMaxLength(100);


            this.Property(t => t.ProjectShortName)
                .HasMaxLength(50);

            this.Property(t => t.ProjectDescription)
                .HasMaxLength(250);


            this.Property(t => t.ProjectManagerID)
                .HasMaxLength(50);

            this.Property(t => t.ProjectManagerName)
               .HasMaxLength(50);

            this.Property(t => t.ProjectDMName)
             .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("ProjectDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProjectID).HasColumnName("ProjectID");
            this.Property(t => t.ESAProjectName).HasColumnName("ESAProjectName");
            this.Property(t => t.ProjectShortName).HasColumnName("ProjectShortName");
            this.Property(t => t.ProjectDescription).HasColumnName("ProjectDescription");
            this.Property(t => t.ProjectManagerID).HasColumnName("ProjectManagerID");
            this.Property(t => t.ProjectManagerName).HasColumnName("ProjectManagerName");
            this.Property(t => t.ProjectDMName).HasColumnName("ProjectDMName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");    
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDt).HasColumnName("CreatedDt");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDt).HasColumnName("ModifiedDt");
           

        }
    }
}
