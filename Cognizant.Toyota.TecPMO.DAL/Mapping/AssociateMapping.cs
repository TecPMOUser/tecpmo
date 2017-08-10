using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class AssociateMapping : EntityTypeConfiguration<Associate>
    {
        public AssociateMapping()
        {

            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.AssociateID)
                .IsRequired();

            this.Property(t => t.AssociateName)
               .HasMaxLength(255);

            this.ToTable("Associate");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.AssociateName).HasColumnName("AssociateName");
            this.Property(t => t.Designation).HasColumnName("Designation");
            this.Property(t => t.GradeDescription).HasColumnName("GradeDescription");
            this.Property(t => t.DepartmentGroup).HasColumnName("DepartmentGroup");
            this.Property(t => t.HorizontalName).HasColumnName("HorizontalName");
            this.Property(t => t.HCMSupervisorId).HasColumnName("HCMSupervisorId");
            this.Property(t => t.HCMSupervisorName).HasColumnName("HCMSupervisorName");
            this.Property(t => t.LocationGroup).HasColumnName("LocationGroup");
            this.Property(t => t.IsOnsite).HasColumnName("IsOnsite");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
        }
    }
}
