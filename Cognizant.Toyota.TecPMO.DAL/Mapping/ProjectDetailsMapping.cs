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

            this.Property(t => t.ProjectName)
                .HasMaxLength(100);


            this.Property(t => t.ManagerID)
                .HasMaxLength(10);

            this.Property(t => t.ManagerName)
                .HasMaxLength(250);


            this.Property(t => t.DMID)
                .HasMaxLength(10);

            this.Property(t => t.DMName)
               .HasMaxLength(50);



            // Table & Column Mappings
            this.ToTable("ProjectDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProjectID).HasColumnName("ProjectID");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.ManagerName).HasColumnName("ManagerName");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");
            this.Property(t => t.DMID).HasColumnName("DMID");
            this.Property(t => t.DMName).HasColumnName("DMName");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");    
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDt).HasColumnName("CreatedDt");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDt).HasColumnName("ModifiedDt");
           

        }
    }
}
