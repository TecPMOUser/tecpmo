using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.Service.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using Cognizant.Toyota.TecPMO.Web.API.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Cognizant.Toyota.TecPMO.Web.API.CustomHelper;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;




namespace Cognizant.Toyota.TecPMO.Web.API.Controllers
{
    public class ProjectDetailsController : ApiController
    {
         private readonly IProjectDetailsService service = null;

        public ProjectDetailsController(IProjectDetailsService projectDetailsService)
        {
            service = projectDetailsService;
        }

        public ProjectDetailsController() : this(new ProjectDetailsService()) { }

        [HttpGet]
        public HttpResponseMessage GetAllProjectDetails()
        {
            var project = service.GetAllProjectDetails();
           
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);

            return response;
        }
        [HttpPost]
        public HttpResponseMessage UpdateProjectDetails([FromBody]ProjectDetails projectDetails)
        {
            HttpResponseMessage response;

            var serviceCode = service.UpdateProjectDetails(projectDetails);
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
        [HttpPost]
        public HttpResponseMessage SaveProjectDetails([FromBody]ProjectDetailsViewModel projectDetails)
        {
            HttpResponseMessage response=null;
            ProjectDetails prjdetails = new ProjectDetails();
            if (projectDetails != null)
            {
                //prjdetails.ID = projectDetails.ID;
                //prjdetails.ProjectID = projectDetails.ProjectID;
                //prjdetails.ESAProjectName = projectDetails.ESAProjectName;
                //prjdetails.ProjectShortName = projectDetails.ProjectShortName;
                //prjdetails.ProjectManagerID = projectDetails.ProjectManagerID;
                //prjdetails.ProjectManagerName = projectDetails.ProjectManagerName;
                //prjdetails.ProjectDMName = projectDetails.ProjectDMName;
                //prjdetails.ProjectDescription = projectDetails.ProjectDescription;
                //var path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/Project Documents/"), projectDetails.URL);

            }
            //var serviceCode = service.SaveProjectDetails(prjdetails);
            //if (serviceCode > 0)
            //{
            //    response = Request.CreateResponse(HttpStatusCode.OK);
            //}
            //else
            //{
            //    response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            //}

            return response;
        }
        [HttpGet]
        public HttpResponseMessage DeleteProjectDetails(int ID)
        {
            HttpResponseMessage response;

            var serviceCode = service.DeleteProjectDetails(ID);
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
        [HttpPost]
        public HttpResponseMessage UploadProjectDocuments(HttpPostedFileBase file)
        {
            var path=string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);                
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/Project Documents/"), fileName);
                file.SaveAs(path);
            }
            return Request.CreateResponse(HttpStatusCode.OK, path);
        }

        [HttpPost]
        public async Task<IHttpActionResult> UploadFile()
        {

            var path=string.Empty;
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                       HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);                
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/Project Documents/"), fileName);
                file.SaveAs(path);
            }
            return Ok(path);
        }
        [HttpGet]
        public HttpResponseMessage GetDocumentsForProject(string projectid)
        {
            var project = service.GetDocumentsForProject(projectid);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);

            return response;

        }
    }
}