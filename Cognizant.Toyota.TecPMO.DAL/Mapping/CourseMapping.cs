using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.ToTable("Course");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CourseCode).HasColumnName("CourseCode");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Type).HasColumnName("Type");     
        }
    }
}
