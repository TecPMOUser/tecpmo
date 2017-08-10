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

        public Project GetProjectDetailsById(long id) 
        {
            return GetSingle<Project>(x => x.ID == id).FirstOrDefault();
        }

        public int SaveProject(List<Project> project)
        {
            int count=0;
            try
            {
                if(project.Count>0)
                {
                foreach(var item in project)
                {
                    var proj = GetSingle<Project>(x => x.ProjectID == item.ProjectID && (x.ProjectName.ToUpper()).Trim()==(item.ProjectName.ToUpper()).Trim()&&(x.Type.ToUpper()).Trim()==(item.Type.ToUpper()).Trim()).FirstOrDefault();
                    if (proj != null)
                    {
                        proj.ProjectManager = item.ProjectManager;
                        proj.PortifolioOwner = item.PortifolioOwner;
                        proj.DesignEndDate = item.DesignEndDate;
                        proj.CUTEndDate = item.CUTEndDate;
                        proj.SITEndDate = item.SITEndDate;
                        proj.UATEndDate = item.UATEndDate;
                        proj.GoLiveDate = item.GoLiveDate;
                        proj.Status = item.Status;
                        proj.ReasonForAR = item.ReasonForAR;
                        proj.PathToMoveGreen = item.PathToMoveGreen;
                        proj.Comments = item.Comments;
                        proj.PathToGreenDate = item.PathToGreenDate;
                        proj.ModifiedDt = DateTime.Now;
                        Update(proj);
                    }
                    else
                    {
                        Add(item);
                    }
                }                                
                count= Save();
                }

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
