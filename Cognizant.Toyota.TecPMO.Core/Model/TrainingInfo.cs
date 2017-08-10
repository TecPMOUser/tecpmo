using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public class TrainingInfo
    {
        public long ID { get; set; }
        public string AssociateID { get; set; }
        public string ProjectId { get; set; }
        public string ESAManagerID { get; set; }
        public string ESAManagerName { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string GradeDescription { get; set; }
        public string Status { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string DeliveryMethod { get; set; }
    }
}
