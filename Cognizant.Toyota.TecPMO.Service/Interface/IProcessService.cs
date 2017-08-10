using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Service.Interface
{
    public interface IProcessService
    {
        IList<ProcessTemplate> GetAllProcessTemplate();
        IList<VideoDetails> GetAllVideoDetail();
    }
}
