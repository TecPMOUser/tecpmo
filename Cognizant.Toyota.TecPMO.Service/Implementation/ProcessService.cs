using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Implementation;
using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using Cognizant.Toyota.TecPMO.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Service.Implementation
{
    public  class ProcessService: IProcessService
    {

        private readonly IProcessRepository repository = null;
        public ProcessService():this(new ProcessRepository()) { }

        public ProcessService(IProcessRepository processRepository)
        {
            repository = processRepository;
        }

        
        public IList<ProcessTemplate> GetAllProcessTemplate()
        {
            return repository.GetAllProcessTemplate();
        }
    }
}
