using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class ProjectMapping: EntityTypeConfiguration<Project>
    {
        public ProjectMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProjectID)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ProjectName)
                .HasMaxLength(100);


            this.Property(t => t.ProjectManager)
                .HasMaxLength(50);

            this.Property(t => t.PortifolioOwner)
                .HasMaxLength(50);

            
            this.Property(t => t.Status)
                .HasMaxLength(50);
            this.Property(t => t.Type)
               .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("Project");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProjectID).HasColumnName("ProjectID");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.ProjectManager).HasColumnName("ProjectManager");
            this.Property(t => t.PortifolioOwner).HasColumnName("PortifolioOwner");
            this.Property(t => t.DesignEndDate).HasColumnName("DesignEndDate");
            this.Property(t => t.CUTEndDate).HasColumnName("CUTEndDate");
            this.Property(t => t.SITEndDate).HasColumnName("SITEndDate");
            this.Property(t => t.GoLiveDate).HasColumnName("GoLiveDate");
            this.Property(t => t.UATEndDate).HasColumnName("UATEndDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ReasonForAR).HasColumnName("ReasonForAR");
            this.Property(t => t.PathToMoveGreen).HasColumnName("PathToMoveGreen");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDt).HasColumnName("CreatedDt");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDt).HasColumnName("ModifiedDt");
            this.Property(t => t.PathToGreenDate).HasColumnName("PathToGreenDate");
            this.Property(t => t.Type).HasColumnName("Type");

        }
    }
}
