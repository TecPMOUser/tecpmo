using Cognizant.Toyota.TecPMO.Core.Model;
using System.Collections.Generic;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Interface
{
    public interface IClientAccoladesRepository: IRepository
    {
        IList<ClientAccolades> GetAllAccolades();

        int SaveAccolades(List<ClientAccolades> accolades);

        int RemoveAccolades(ClientAccolades accolades);
    }
}
