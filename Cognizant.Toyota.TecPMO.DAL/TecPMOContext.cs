using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Mapping;
using System.Data.Entity;

namespace Cognizant.Toyota.TecPMO.DAL
{
    public class TecPMOContext : DbContext
    {
        static TecPMOContext()
        {
            Database.SetInitializer<TecPMOContext>(null);
        }

        public TecPMOContext()
            : base("Name=TecPMOContext")
        {
        }

        #region Collection

        public DbSet<Project> Project { get; set; }
        public DbSet<ClientAccolades> ClientAccolades { get; set; }
        public DbSet<ProcessTemplate> ProcessTemplate { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }

        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Model Builder

            modelBuilder.Configurations.Add(new ProjectMapping());
            modelBuilder.Configurations.Add(new ClientAccoladesMapping());
            modelBuilder.Configurations.Add(new ProcessTemplateMapping());
            modelBuilder.Configurations.Add(new ProjectDetailsMapping());

            #endregion


        }
    }
}
