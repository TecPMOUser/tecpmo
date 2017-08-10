using Cognizant.Toyota.TecPMO.Service.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cognizant.Toyota.TecPMO.Web.API.Controllers
{
    public class ProcessController : ApiController
    {
        private readonly IProcessService service = null;

        public ProcessController(IProcessService processService)
        {
            service = processService;
        }

        public ProcessController() : this(new ProcessService()) { }

        [HttpGet]
        public HttpResponseMessage GetAllProcessTemplate()
        {
            var processTempalte = service.GetAllProcessTemplate().ToList();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, processTempalte);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetAllVideoDetail()
        {
            var videoDetail = service.GetAllVideoDetail().ToList();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, videoDetail);
            return response;
        }
    }
}
