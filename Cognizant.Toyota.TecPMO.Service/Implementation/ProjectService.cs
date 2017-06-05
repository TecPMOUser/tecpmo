using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Service.Implementation
{
    public class ProjectService: IProjectService
    {
        private readonly ProjectRepository repository = null;
        public ProjectService():this(new ProjectRepository()) { }

        public ProjectService(ProjectRepository projectRepository)
        {
            repository = projectRepository;
        }

        public IList<Project> GetAllProject()
        {
            return repository.GetAllProject();
        }

        public int SaveProject(List<Project> project)
        {
            return repository.SaveProject(project);
        }

        public Project GetProjectDetailsById(string projectID)
        {
            return repository.GetProjectDetailsById(projectID);
        }
    }
}
