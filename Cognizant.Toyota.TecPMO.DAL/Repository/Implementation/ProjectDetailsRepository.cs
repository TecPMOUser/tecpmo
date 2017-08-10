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
    public class ProjectDetailsRepository : Repository, IProjectDetailsRepository
    {
        public IList<ProjectDetails> GetAllProjectDetails()
        {
            return (GetAll<ProjectDetails>().ToList()).Where(x => x.IsActive == true).ToList();
        }
        public int UpdateProjectDetails(ProjectDetails projectdetails)
        {
            int result = 0;
            var prjDetails = GetSingle<ProjectDetails>(x => x.ID == projectdetails.ID).FirstOrDefault();
            if (prjDetails != null)
            {
                prjDetails.ProjectID = projectdetails.ProjectID;
                //prjDetails.ESAProjectName = projectdetails.ESAProjectName;
                //prjDetails.ProjectShortName = projectdetails.ProjectShortName;
                //prjDetails.ProjectDescription = projectdetails.ProjectDescription;
                //prjDetails.ProjectManagerID = projectdetails.ProjectManagerID;
                //prjDetails.ProjectManagerName = projectdetails.ProjectManagerName;
                //prjDetails.ProjectDMName = projectdetails.ProjectDMName;
                prjDetails.ModifiedDt = DateTime.Now;
                Update<ProjectDetails>(prjDetails);
                result = Save();
            }
            return result;
        }
        public IList<DocumentDetails> GetDocumentsForProject(string ProjectID)
        {

            return (GetAll<DocumentDetails>().ToList()).Where(x => x.ProjectID == ProjectID).ToList();

        }
        public int SaveProjectDocumentDetails(DocumentDetails projectdocuemntdetails)
        {
            int count = 0;
            try
            {
                Add(projectdocuemntdetails);
                count = Save();

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
        public int SaveProjectDetails(List<ProjectDetails> projectdetails)
        {
            int result = 0;           
            ProjectDetails projectdetailsupdate = new ProjectDetails();            
            if (projectdetails != null)
            {
            foreach (var project in projectdetails)
            {
                projectdetailsupdate = GetSingle<ProjectDetails>(x => x.ProjectID == project.ProjectID && x.IsActive==true).FirstOrDefault();

                if (projectdetailsupdate !=null)
                {
                    projectdetailsupdate.ProjectName = project.ProjectName;
                    projectdetailsupdate.ManagerName = project.ManagerName;
                    projectdetailsupdate.ManagerID = project.ManagerID;
                    projectdetailsupdate.DMID = project.DMID;
                    projectdetailsupdate.DMName = project.DMName;
                    projectdetailsupdate.StartDate = project.StartDate;
                    projectdetailsupdate.EndDate = project.EndDate;
                    projectdetailsupdate.IsActive = project.IsActive;
                    projectdetailsupdate.ModifiedBy = project.ModifiedBy;
                    projectdetailsupdate.ModifiedDt = project.ModifiedDt;                    
                    Update<ProjectDetails>(projectdetailsupdate);
                    projectdetailsupdate = null;
                }
                else
                {
                    Add<ProjectDetails>(project);
                   
                }                
            }           
                result = Save();
            }
            return result;
        }
        public int DeleteProjectDetails(int ID)
        {
            int result = 0;
            var prjDetails = GetSingle<ProjectDetails>(x => x.ID == ID).FirstOrDefault();
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
