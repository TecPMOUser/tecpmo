using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Implementation
{
    public class ProcessRepository:Repository,IProcessRepository
    {
        public IList<ProcessTemplate> GetAllProcessTemplate()
        {
            return GetAll<ProcessTemplate>().ToList();
        }
        public IList<VideoDetails> GetAllVideoDetail()
        {
            return GetAll<VideoDetails>().ToList();
        }
    }
}
