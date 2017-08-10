using Cognizant.Toyota.TecPMO.Core;
using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.Service.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using Cognizant.Toyota.TecPMO.Web.API.Authorization;
using Cognizant.Toyota.TecPMO.Web.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cognizant.Toyota.TecPMO.Web.API.Controllers
{    
    public class ProjectController : ApiController
    {

        private readonly IProjectService service = null;

        public ProjectController(IProjectService projectService)
        {
            service = projectService;
        }

        public ProjectController() : this(new ProjectService()) { }

        [HttpPost]
        public HttpResponseMessage SubmitProject1([FromBody]ProjectViewModel project)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage SubmitProject([FromBody]ProjectRequestModel project)
        {
            HttpResponseMessage response;
            var projectModel = project.Project.Select(x => new Project()
            {
                CreatedBy = "",
                CreatedDt = DateTime.Now,
                ProjectManager = x.ProjectManager,
                DesignEndDate = DateFormat(x.DesignEndDate),
                SITEndDate = DateFormat(x.SITEndDate),
                UATEndDate = DateFormat(x.UATEndDate),
                CUTEndDate = DateFormat(x.CUTEndDate),
                GoLiveDate = DateFormat(x.GoLiveDate),
                ModifiedBy = "",
                ModifiedDt = DateTime.Now,
                PortifolioOwner = x.PortifolioOwner,
                Status = (!string.IsNullOrEmpty(x.Status)) ? ConvertStatus(x.Status) : "Green",
                ReasonForAR = x.ReasonForAR,
                PathToMoveGreen = x.PathToMoveGreen,
                Comments = x.Comments,
                ProjectName = x.ProjectName,
                ProjectID = x.ProjectID,
                PathToGreenDate = DateFormat(x.PathToGreenDate),
                Type = x.Type
            }).ToList();
            var serviceCode = service.SaveProject(projectModel);
            if (serviceCode > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetAllProject()
        {
            var project = service.GetAllProject().Where(a => a.Status.ToUpper() != "GREEN");
            project = StatusOrder(project.ToList());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetAllADProject()
        {
            var project = service.GetAllProject().Where(a => a.Status.ToUpper() != "GREEN" && a.Type.ToUpper() == "AD");
            project = StatusOrder(project.ToList());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);

            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetAllAVMProject()
        {
            var project = service.GetAllProject().Where(a => a.Status.ToUpper() != "GREEN" && a.Type.ToUpper() == "AVM");
            project = StatusOrder(project.ToList());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);

            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetProjectStatus()
        {
            IClientAccoladesService accservice = new ClientAccoladesService();
            DashboardModel projectStatus = new DashboardModel();
            projectStatus.ADProject = GetADProjectStatus();
            projectStatus.AVMProject = GetAVMProjectStatus();
            projectStatus.Accolades = accservice.GetAllAccolades();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projectStatus);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetADProjectCalendar()
        {
            var project = service.GetAllProject().Where(a => a.Type.ToUpper() == "AD");
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, CalendarOrder(project.ToList()));
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetAVMProjectCalendar()
        {
            var project = service.GetAllProject().Where(a => a.Type.ToUpper() == "AVM");
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, CalendarOrder(project.ToList()));
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetProjectDetailsById(long id)
        {
            var project = service.GetProjectDetailsById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);
            return response;
        }

        #region PrivateMethods
        private ProjectStatus GetADProjectStatus()
        {
            var adproject = service.GetAllProject().Where(a => a.Type.ToUpper() == "AD").ToList();
            var adredCount = adproject.Count(a => a.Status.ToUpper() == "RED");
            var adamberCount = adproject.Count(a => a.Status.ToUpper() == "AMBER");
            var adgreenCount = adproject.Count(a => a.Status.ToUpper() == "GREEN");

            var adprojectStatus = new ProjectStatus()
            {
                Red = adredCount,
                Amber = adamberCount,
                Green = adgreenCount
            };

            //HttpResponseMessage response =  Request.CreateResponse(HttpStatusCode.OK, projectStatus);

            return adprojectStatus;
        }

        private ProjectStatus GetAVMProjectStatus()
        {
            var project = service.GetAllProject().Where(a => a.Type.ToUpper() == "AVM").ToList();
            var redCount = project.Count(a => a.Status.ToUpper() == "RED");
            var amberCount = project.Count(a => a.Status.ToUpper() == "AMBER");
            var greenCount = project.Count(a => a.Status.ToUpper() == "GREEN");

            var projectStatus = new ProjectStatus()
            {
                Red = redCount,
                Amber = amberCount,
                Green = greenCount
            };
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projectStatus);

            return projectStatus;
        }


        private DateTime? ConvertToDateTime(string dateValue)
        {
            DateTime dateTimeValue = DateTime.MinValue;
            if (!string.IsNullOrEmpty(dateValue))
            {
                DateTime.TryParse(dateValue, out dateTimeValue);
            }

            return DateTime.MinValue != dateTimeValue ? dateTimeValue : (DateTime?)null;
        }

        private DateTime? DateFormat(string dateValue)
        {
            if (dateValue != null)
            {
                string[] formats = new[] { "MM/dd/yyyy", "dd-MMM-yyyy", 
                            "yyyy-MM-dd", "dd-MM-yyyy", "dd MMM yyyy", "M/dd/yy","M/dd/yyyy","MM/d/yy","MM/d/yyyy","M/d/yy","M/d/yyyy"};
                DateTime d = DateTime.ParseExact(dateValue, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                return Convert.ToDateTime(d.ToString("yyyy-MM-dd"));
            }
            else
            {
                return null;
            }
        }

        private string ConvertStatus(string status)
        {
            string statusValue = "";

            switch (status.ToUpper())
            {
                case "RED":
                    statusValue = "Red";
                    break;
                case "GREEN":
                    statusValue = "Green";
                    break;
                case "AMBER":
                    statusValue = "Amber";
                    break;

            }
            return statusValue;
        }
        private IList<Project> StatusOrder(List<Project> obj)
        {

            List<Status> status = new List<Status>() {
            new Status() { StatusId=1,StatusName= "Red" },
            new Status() { StatusId = 2, StatusName = "Amber" },
            new Status() { StatusId = 3, StatusName = "Green"}};


            var project = (from t1 in obj
                           join t2 in status
                           on t1.Status equals t2.StatusName
                           orderby t2.StatusId ascending
                           select t1).ToList();
            return project;
        }

        private List<CalendarEventModel> CalendarOrder(List<Project> project)
        {
            List<CalendarEventModel> eventmodel = new List<CalendarEventModel>();
            foreach (var item in project)
            {

                if (item.DesignEndDate != null)
                {
                    eventmodel.Add(new CalendarEventModel(item.ProjectName + " - " + Constant.Design, Convert.ToDateTime(item.DesignEndDate), item.Status, item.ProjectID, Constant.Design,item.ID));
                }
                if (item.CUTEndDate != null)
                {
                    eventmodel.Add(new CalendarEventModel(item.ProjectName + " - " + Constant.Cut, Convert.ToDateTime(item.CUTEndDate), item.Status, item.ProjectID, Constant.Cut, item.ID));
                }
                if (item.SITEndDate != null)
                {
                    eventmodel.Add(new CalendarEventModel(item.ProjectName + " - " + Constant.Sit, Convert.ToDateTime(item.SITEndDate), item.Status, item.ProjectID, Constant.Sit, item.ID));
                }
                if (item.UATEndDate != null)
                {
                    eventmodel.Add(new CalendarEventModel(item.ProjectName + " - " + Constant.Uat, Convert.ToDateTime(item.UATEndDate), item.Status, item.ProjectID, Constant.Uat, item.ID));
                }
                if (item.GoLiveDate != null)
                {
                    eventmodel.Add(new CalendarEventModel(item.ProjectName + " - " + Constant.GoLive, Convert.ToDateTime(item.GoLiveDate), item.Status, item.ProjectID, Constant.GoLive, item.ID));
                }

            }
            return eventmodel;
        }
        #endregion PrivateMethods
    }
    public class Status
    {
        public int StatusId;
        public string StatusName;
    }


}
