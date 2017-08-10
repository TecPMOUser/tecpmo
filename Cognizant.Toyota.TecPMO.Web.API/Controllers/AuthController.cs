using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace Cognizant.Toyota.TecPMO.Web.API.Controllers
{
    public class AuthController : ApiController
    {
        public IHttpActionResult GetUser()
        {
            User user = new User();
            string domainUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] paramsLogin = domainUser.Split('\\');

            using (HostingEnvironment.Impersonate())
            {
                using (DirectorySearcher dsSearch = new DirectorySearcher(ConfigurationManager.AppSettings["LDAP_PATH"]))
                {
                    dsSearch.Filter = "(sAMAccountName=" + paramsLogin[1] + ")";
                    SearchResult sResult = dsSearch.FindOne();
                    using (DirectoryEntry dsResult = sResult.GetDirectoryEntry())
                    {
                        if (dsResult != null)
                        {
                            user.ID = int.Parse(paramsLogin[1]);
                            user.UserName = dsResult.Properties["cn"][0].ToString();
                        }
                    }
                }

            }

            return Ok(user);

        }
    }
}