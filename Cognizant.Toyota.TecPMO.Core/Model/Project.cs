using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public class Project
    {
        
        public long ID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public string PortifolioOwner { get; set; }
        public DateTime? DesignEndDate { get; set; }
        public DateTime? CUTEndDate { get; set; }
        public DateTime? SITEndDate { get; set; }
        public DateTime? UATEndDate { get; set; }
        public DateTime? GoLiveDate { get; set; }
        public string Status { get; set; }
        public string ReasonForAR { get; set; }
        public string PathToMoveGreen { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDt { get; set; }
        public DateTime? PathToGreenDate { get; set; }
        public string Type { get; set; }
    }
}
