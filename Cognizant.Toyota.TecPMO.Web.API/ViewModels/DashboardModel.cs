using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class DashboardModel
    {
        public ProjectStatus ADProject { get; set; }
        public ProjectStatus AVMProject { get; set; }
        public IList<ClientAccolades> Accolades { get; set; }
    }
}