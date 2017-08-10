using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class ProjectStatus
    {
        public int Red  { get; set; }
        public int Green { get; set; }
        public int Amber { get; set; }
    }
}