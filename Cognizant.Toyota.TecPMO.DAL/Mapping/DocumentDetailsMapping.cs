using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class DocumentDetailsMapping : EntityTypeConfiguration<DocumentDetails>
    {
        public DocumentDetailsMapping()
        {
            // Primary Key
            this.HasKey(t => t.ProjectDocumentID);

            // Properties



            // Table & Column Mappings
            this.ToTable("ProjectDocuments");
            this.Property(t => t.ProjectDocumentID).HasColumnName("ProjectDocumentID");
            this.Property(t => t.ProjectID).HasColumnName("ProjectID");
            this.Property(t => t.DocumentType).HasColumnName("DocumentType");
            this.Property(t => t.DocumentName).HasColumnName("DocumentName");
            this.Property(t => t.DocumentLocation).HasColumnName("DocumentLocation");
            this.Property(t => t.UploadedBy).HasColumnName("UploadedBy");
            this.Property(t => t.UploadedDate).HasColumnName("UploadedDate");

        }
    }
}
