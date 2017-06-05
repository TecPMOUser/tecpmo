using Cognizant.Toyota.TecPMO.Service.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using Cognizant.Toyota.TecPMO.Web.API.ViewModels;
using Cognizant.Toyota.TecPMO.Core.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System;

namespace Cognizant.Toyota.TecPMO.Web.API.Controllers
{
    public class AccoladesController : ApiController
    {
        private readonly IClientAccoladesService service = null;

        public AccoladesController(IClientAccoladesService accoladesService)
        {
            service = accoladesService;
        }

        public AccoladesController() : this(new ClientAccoladesService()) { }
      
        [HttpGet]
        public HttpResponseMessage GetAllAccolades()
        {
            var project = service.GetAllAccolades();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, project);

            return response;
        }
        [HttpPost]
        public HttpResponseMessage SubmitAccolades([FromBody]AccoladesListViewModel accolades)
        {
            HttpResponseMessage response;
            var accloadesmodel = accolades.Accolades.Select(x => new ClientAccolades()
            {
                CreatedBy = "",
                CreatedDt = DateTime.Now,                             
                ModifiedBy = "",
                ModifiedDt = DateTime.Now,                                
                ProjectName = x.ProjectName,
                Milestone = x.Milestone,
                Date = ConvertToDateTime(x.Date),
                AppreciationNote = x.AppreciationNote,
                AppreciatedBy = x.AppreciatedBy,
                Designation = x.Designation,
                Department = x.Department,
                ImageURL = x.ImageURL,
            }).ToList();
            var serviceCode = service.SaveAccolades(accloadesmodel);
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
        private DateTime? ConvertToDateTime(string dateValue)
        {
            DateTime dateTimeValue = DateTime.MinValue;
            if (!string.IsNullOrEmpty(dateValue))
            {
                DateTime.TryParse(dateValue, out dateTimeValue);
            }

            return DateTime.MinValue != dateTimeValue ? dateTimeValue : (DateTime?)null;
        }

    }
}