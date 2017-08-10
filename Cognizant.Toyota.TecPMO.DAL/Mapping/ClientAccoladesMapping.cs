using Cognizant.Toyota.TecPMO.Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Cognizant.Toyota.TecPMO.DAL.Mapping
{
    public class ClientAccoladesMapping:EntityTypeConfiguration<ClientAccolades>
    {
        public ClientAccoladesMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProjectID)
                .HasMaxLength(50);

           this.Property(t => t.ProjectName)
                .HasMaxLength(500);


            this.Property(t => t.Milestone)
                .HasMaxLength(300);

            this.Property(t => t.AppreciationNote)
                .HasMaxLength(4000);


            this.Property(t => t.AppreciatedBy)
                .HasMaxLength(300);

            this.Property(t => t.Designation)
                .HasMaxLength(300);

            this.Property(t => t.Department)
                .HasMaxLength(300);

            this.Property(t => t.ImageURL)
               .HasMaxLength(500);

            this.Property(t => t.CreatedBy)
               .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
               .HasMaxLength(50);



            // Table & Column Mappings
            this.ToTable("ClientAccolades");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProjectID).HasColumnName("ProjectID");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.Milestone).HasColumnName("Milestone");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.AppreciationNote).HasColumnName("AppreciationNote");
            this.Property(t => t.AppreciatedBy).HasColumnName("AppreciatedBy");
            this.Property(t => t.Designation).HasColumnName("Designation");
            this.Property(t => t.Department).HasColumnName("Department");
            this.Property(t => t.ImageURL).HasColumnName("ImageURL");            
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDt).HasColumnName("CreatedDt");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDt).HasColumnName("ModifiedDt");            

        }
    }
}
