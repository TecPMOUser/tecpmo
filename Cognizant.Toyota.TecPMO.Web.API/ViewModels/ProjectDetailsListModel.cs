using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class ProjectDetailsListModel
    {
        IList<ProjectDetails> projectDetails { get; set; }
    }
}