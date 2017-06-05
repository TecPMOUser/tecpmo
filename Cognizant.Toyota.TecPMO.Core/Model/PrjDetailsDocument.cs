using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public class PrjDetailsDocument
    {
        public long ID { get; set; }
        public string ProjectDetailsID { get; set; }
        public string URL { get; set; }        
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
    }
}
