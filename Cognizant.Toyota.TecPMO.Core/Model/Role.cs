using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
    }
}
