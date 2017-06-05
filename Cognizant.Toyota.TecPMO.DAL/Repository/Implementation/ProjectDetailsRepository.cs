using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Implementation
{
    public class ProjectDetailsRepository : Repository, IProjectDetailsRepository
    {
        public IList<ProjectDetails> GetAllProjectDetails()
        {
            return (GetAll<ProjectDetails>().ToList()).Where(x=>x.IsActive==true).ToList();
        }
        public int UpdateProjectDetails(ProjectDetails projectdetails)
        {
            int result = 0;
            var prjDetails = GetSingle<ProjectDetails>(x=>x.ID==projectdetails.ID).FirstOrDefault();
            if (prjDetails != null)
            {
                prjDetails.ProjectID = projectdetails.ProjectID;
                prjDetails.ESAProjectName = projectdetails.ESAProjectName;
                prjDetails.ProjectShortName = projectdetails.ProjectShortName;
                prjDetails.ProjectDescription = projectdetails.ProjectDescription;
                prjDetails.ProjectManagerID = projectdetails.ProjectManagerID;
                prjDetails.ProjectManagerName = projectdetails.ProjectManagerName;
                prjDetails.ProjectDMName = projectdetails.ProjectDMName;
                prjDetails.ModifiedDt = DateTime.Now;
                Update<ProjectDetails>(prjDetails);
                result = Save();
            }
            return result;
        }
        public int SaveProjectDetails(ProjectDetails projectdetails)
        {
            int result = 0;
            if (projectdetails != null)
            {
                projectdetails.IsActive = true;
                projectdetails.CreatedDt = DateTime.Now;
                Add<ProjectDetails>(projectdetails);
                result = Save();
            }
            return result;
        }
     public  int DeleteProjectDetails(int ID)
    {
        int result = 0;
          var prjDetails = GetSingle<ProjectDetails>(x=>x.ID==ID).FirstOrDefault();
          if (prjDetails != null)
          {
              prjDetails.IsActive = false;
              prjDetails.ModifiedDt = DateTime.Now;
              Update<ProjectDetails>(prjDetails);
              result = Save();

          }
        return result;
    }
    }
}
