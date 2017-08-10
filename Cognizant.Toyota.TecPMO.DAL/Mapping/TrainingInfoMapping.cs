using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class TrainingInfoMapping : EntityTypeConfiguration<TrainingInfo>
    {
        public TrainingInfoMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("TrainingInfo");
            this.Property(t => t.AssociateID).HasColumnName("AssociateID");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.ESAManagerID).HasColumnName("ESAManagerID");
            this.Property(t => t.ESAManagerName).HasColumnName("ESAManagerName");
            this.Property(t => t.CourseCode).HasColumnName("CourseCode");
            this.Property(t => t.CourseName).HasColumnName("CourseName");
            this.Property(t => t.GradeDescription).HasColumnName("GradeDescription");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.DeliveryMethod).HasColumnName("DeliveryMethod");     
        }
    }
}
