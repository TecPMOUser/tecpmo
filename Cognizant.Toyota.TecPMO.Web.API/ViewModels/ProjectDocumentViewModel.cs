using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognizant.Toyota.TecPMO.Web.API.ViewModels
{
    public class ProjectDocumentViewModel
    {
        public string projectid { get; set; }        
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentLocation { get; set; }
    }
}