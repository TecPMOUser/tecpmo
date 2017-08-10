using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
   
    public class ProcessTemplateMapping : EntityTypeConfiguration<ProcessTemplate>
    {
        public ProcessTemplateMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(t => t.ProcessDescription)
               .HasMaxLength(255);

            this.Property(t => t.Url)
               .HasMaxLength(255);


            // Table & Column Mappings
            this.ToTable("ProcessTemplate");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ProcessDescription).HasColumnName("ProcessDescription");
            this.Property(t => t.Url).HasColumnName("Url");

        }
    }
}
