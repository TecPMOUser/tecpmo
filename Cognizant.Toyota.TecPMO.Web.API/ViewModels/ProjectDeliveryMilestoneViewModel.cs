using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class ProjectDeliveryMilestoneViewModel
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public string PortifolioOwner { get; set; }
        public string DesignEndDate { get; set; }
        public string CUTEndDate { get; set; }
        public string SITEndDate { get; set; }
        public string UATEndDate { get; set; }
        public string GoLiveDate { get; set; }
        public string Status { get; set; }
        public string ReasonForAR { get; set; }
        public string PathToMoveGreen { get; set; }
        public string PathToGreenDate { get; set; }
        public string Comments { get; set; }

        public string Type { get; set; }
    }
}