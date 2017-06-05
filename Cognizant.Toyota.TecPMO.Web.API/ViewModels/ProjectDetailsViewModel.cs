using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public long ID { get; set; }
        public string ProjectID { get; set; }
        public string ESAProjectName { get; set; }
        public string ProjectShortName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectManagerID { get; set; }
        public string ProjectManagerName { get; set; }
        public string ProjectDMName { get; set; }
        public string URL { get; set; }

    }
}