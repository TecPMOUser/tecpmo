using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Core.Model
{
    public class DocumentDetails
    {
        public int ProjectDocumentID { get; set; }
        public string ProjectID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentLocation { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }

    }
}
