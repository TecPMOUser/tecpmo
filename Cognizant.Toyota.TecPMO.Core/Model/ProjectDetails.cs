using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public class ProjectDetails
    {
        public long ID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ManagerName { get; set; }
        public string ManagerID { get; set; }
        public string DMID { get; set; }
        public string DMName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
    }
}
