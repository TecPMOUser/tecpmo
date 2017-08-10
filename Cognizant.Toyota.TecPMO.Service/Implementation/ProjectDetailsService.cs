using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Implementation;
using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using Cognizant.Toyota.TecPMO.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Service.Implementation
{
    public class ProjectDetailsService : IProjectDetailsService
    {
         private readonly IProjectDetailsRepository repository = null;
        public ProjectDetailsService():this(new ProjectDetailsRepository()) { }

        public ProjectDetailsService(IProjectDetailsRepository processRepository)
        {
            repository = processRepository;
        }


        public IList<ProjectDetails> GetAllProjectDetails()
        {
            return repository.GetAllProjectDetails();
        }
        public IList<DocumentDetails> GetDocumentsForProject(string ProjectId)
        {
            return repository.GetDocumentsForProject(ProjectId);
        }
        public int SaveProjectDocumentDetails(DocumentDetails projectdocuemntdetails)
        {
            return repository.SaveProjectDocumentDetails(projectdocuemntdetails);
        }
        public int UpdateProjectDetails(ProjectDetails projectDetails)
        {
            return repository.UpdateProjectDetails(projectDetails);
        }
        public int SaveProjectDetails(List<ProjectDetails> projectDetails)
        {
            return repository.SaveProjectDetails(projectDetails);
        }
        public int DeleteProjectDetails(int ID)
        {
            return repository.DeleteProjectDetails(ID);
        }
    }
}
