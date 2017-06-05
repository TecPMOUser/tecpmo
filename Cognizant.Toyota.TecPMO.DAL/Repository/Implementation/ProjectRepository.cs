using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Implementation
{
    public class ProjectRepository : Repository, IProjectRepository
    {

        public IList<Project> GetAllProject()
        {
            return GetAll<Project>().ToList();
        }

        public Project GetProjectDetailsById(string projectID) 
        {
            return GetSingle<Project>(x => x.ProjectID == projectID).FirstOrDefault();
        }

        public int SaveProject(List<Project> project)
        {
            int count=0;
            try
            {
                AddRange(project);
                count= Save();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return count;
           
           
        }



    }
}
