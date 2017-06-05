using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using System.Collections.Generic;

namespace Cognizant.Toyota.TecPMO.Service.Implementation
{
    public class ClientAccoladesService:IClientAccoladesService
    {
        private readonly ClientAccoladesRepository repository = null;
        public ClientAccoladesService():this(new ClientAccoladesRepository()) { }

        public ClientAccoladesService(ClientAccoladesRepository accoladesRepository)
        {
            repository = accoladesRepository;
        }

        public IList<ClientAccolades> GetAllAccolades()
        {
            return repository.GetAllAccolades();
        }

        public int SaveAccolades(List<ClientAccolades> accolades)
        {
            return repository.SaveAccolades(accolades);
        }
    }
}
