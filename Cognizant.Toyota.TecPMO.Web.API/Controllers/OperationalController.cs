using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.Service.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using Cognizant.Toyota.TecPMO.Web.API.ViewModels;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System;
using System.Linq;
using System.Globalization;
using System.Configuration;


namespace Cognizant.Toyota.TecPMO.Web.API.Controllers
{
    public class OperationalController : ApiController
    {
        private readonly IProjectDetailsService service = null;

        public OperationalController(IProjectDetailsService projectDetailsService)
        {
            service = projectDetailsService;
        }

        public OperationalController() : this(new ProjectDetailsService()) { }

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
        public HttpResponseMessage SaveProjectDetails(ProjectDocumentViewModel projectDetails)
        {
            HttpResponseMessage response = null;
            if (projectDetails != null)
            {
                DocumentDetails dd=new DocumentDetails();
                dd.ProjectID=projectDetails.projectid;
                dd.DocumentType=projectDetails.DocumentType;
                dd.DocumentName=projectDetails.DocumentName;
                dd.DocumentLocation=projectDetails.DocumentLocation;
                dd.UploadedDate = DateTime.Now;
                var serviceCode = service.SaveProjectDocumentDetails(dd);
                if (serviceCode > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                }

            }
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
        public async Task<IHttpActionResult> UploadFile()
        {

            var filepath = string.Empty;
            var path = string.Empty;
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                       HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                path=("/Documents/"+fileName);
                filepath = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["serverpath"].ToString()), fileName);
                file.SaveAs(filepath);
            }
            return Ok(path);
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
                            "yyyy-MM-dd", "dd-MM-yyyy", "dd MMM yyyy", "M/dd/yy","MM/d/yy","M/d/yy"};
                DateTime d = DateTime.ParseExact(dateValue, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                return Convert.ToDateTime(d.ToString("yyyy-MM-dd"));
            }
            else
            {
                return null;
            }
        }

    }
}
