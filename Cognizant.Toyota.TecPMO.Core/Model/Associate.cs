using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public class Associate
    {
        public long ID { get; set; }
        public string AssociateID { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string AssociateName { get; set; }
        public string Designation { get; set; }
        public string GradeDescription { get; set; }
        public string DepartmentGroup { get; set; }
        public string HorizontalName { get; set; }
        public string HCMSupervisorId { get; set; }
        public string HCMSupervisorName { get; set; }
        public string LocationGroup { get; set; }
        public string IsOnsite { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
