using Cognizant.Toyota.TecPMO.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Interface
{
    public interface IProcessRepository: IRepository
    {
        IList<ProcessTemplate> GetAllProcessTemplate();
    }
}
