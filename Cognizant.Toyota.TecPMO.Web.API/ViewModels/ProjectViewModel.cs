using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class ProjectViewModel
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectManagerID { get; set; }
        public string ProjectManagetName { get; set; }
        public string DeliveryManagerID { get; set; }
        public string DeliveryManagerName { get; set; }
        public string ProjectRagStatus { get; set; }
        public string StatusReason { get; set; }
        public string PathToGreen { get; set; }        
        public string ProjectCurrentMilestone { get; set; }
        public string CurrentMilestoneStartDt { get; set; }
        public string CurrentMilestoneEndDt { get; set; }
        
    }
}