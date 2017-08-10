using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.Service.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cognizant.Toyota.TecPMO.Web.API.Authorization
{
    public class RoleAuthorization : System.Web.Http.AuthorizeAttribute
    {
         private readonly IAuthorizationService service = null;

        public RoleAuthorization(IAuthorizationService authorizeService)
        {
            service = authorizeService;
        }
        IList<UserRoleModel> userRole = new List<UserRoleModel>();

        public RoleAuthorization() : this(new AuthorizationService()) { }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            userRole = service.GetAllUserRole();

            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();

            var res = userRole.Where(x => x.UserName == Username && x.Controller == controller).Select(x=>x.UserName).FirstOrDefault();

            if (res == null)
            {
                filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,"invalid request");
            }  
            
            return;
        }
        
    }
}