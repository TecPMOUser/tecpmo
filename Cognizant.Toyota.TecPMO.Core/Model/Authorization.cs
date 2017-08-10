using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{    
    public class Authorization
    {
        public int ID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int Role { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
    }
}
