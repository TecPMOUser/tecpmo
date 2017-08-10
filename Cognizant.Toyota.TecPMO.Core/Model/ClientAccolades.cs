using System;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public  class ClientAccolades
    {
        public long ID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Milestone { get; set; }
        public DateTime? Date { get; set; }
        public string AppreciationNote { get; set; }
        public string AppreciatedBy { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string ImageURL { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDt { get; set; }

    }
}
