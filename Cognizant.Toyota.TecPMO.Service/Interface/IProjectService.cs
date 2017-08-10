using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Service.Interface
{
    public interface IProjectService
    {
        IList<Project> GetAllProject();

        int SaveProject(List<Project> project);

        Project GetProjectDetailsById(long id);
    }
}
