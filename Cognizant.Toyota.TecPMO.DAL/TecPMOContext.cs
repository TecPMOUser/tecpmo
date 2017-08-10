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
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRoleMapping> UserRoleMapping { get; set; }
        public DbSet<Authorization> Authorization { get; set; }
        public DbSet<DocumentDetails> DocumentDetails { get; set; }
        public DbSet<Associate> Associate { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<TrainingInfo> TrainingInfo { get; set; }
        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Model Builder

            modelBuilder.Configurations.Add(new ProjectMapping());
            modelBuilder.Configurations.Add(new ClientAccoladesMapping());
            modelBuilder.Configurations.Add(new ProcessTemplateMapping());
            modelBuilder.Configurations.Add(new ProjectDetailsMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new UserRoleMapMapping());
            modelBuilder.Configurations.Add(new AuthorizationMapping());
            modelBuilder.Configurations.Add(new DocumentDetailsMapping());
            modelBuilder.Configurations.Add(new VideoDetailsMapping());
            modelBuilder.Configurations.Add(new AssociateMapping());
            modelBuilder.Configurations.Add(new CourseMapping());
            modelBuilder.Configurations.Add(new TrainingInfoMapping());
            #endregion


        }
    }
}
