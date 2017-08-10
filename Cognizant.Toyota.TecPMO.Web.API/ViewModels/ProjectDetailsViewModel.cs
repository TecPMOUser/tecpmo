using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ManagerName { get; set; }
        public string ManagerID { get; set; }
        public string DMID { get; set; }
        public string DMName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}