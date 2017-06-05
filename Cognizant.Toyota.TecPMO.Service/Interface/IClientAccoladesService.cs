using Cognizant.Toyota.TecPMO.Core.Model;
using System.Collections.Generic;

namespace Cognizant.Toyota.TecPMO.Service.Interface
{
    public interface IClientAccoladesService
    {
        IList<ClientAccolades> GetAllAccolades();

        int SaveAccolades(List<ClientAccolades> accolades);
    }
}
