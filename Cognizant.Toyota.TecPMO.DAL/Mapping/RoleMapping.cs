using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{    
    public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RoleName)
                .HasMaxLength(50);

            this.ToTable("Role");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDt).HasColumnName("CreatedDt");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDt).HasColumnName("ModifiedDt");
        }
    }
}
