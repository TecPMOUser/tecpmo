using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Service.Interface
{
    public interface IProjectDetailsService
    {
        IList<ProjectDetails> GetAllProjectDetails();

        int UpdateProjectDetails(ProjectDetails projectDetails);

        int SaveProjectDetails(ProjectDetails projectDetails);

        int DeleteProjectDetails(int ID);
    }
}
