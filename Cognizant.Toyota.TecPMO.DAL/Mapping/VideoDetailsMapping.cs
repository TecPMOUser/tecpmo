using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class VideoDetailsMapping : EntityTypeConfiguration<VideoDetails>
    {
        public VideoDetailsMapping()
        {
            this.HasKey(t => t.ID);

            this.ToTable("VideoDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VideoName).HasColumnName("VideoName");
            this.Property(t => t.VideoLink).HasColumnName("VideoLink");
            this.Property(t => t.CreatedBy).HasColumnName("CreateBy");
            this.Property(t => t.CreatedDt).HasColumnName("CreatedDt");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDt).HasColumnName("ModifiedDt");
        }
    }
}
