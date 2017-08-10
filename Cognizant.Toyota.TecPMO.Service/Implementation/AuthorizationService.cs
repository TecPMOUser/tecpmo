using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Implementation;
using Cognizant.Toyota.TecPMO.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
         private readonly AuthorizationRepository repository = null;
        public AuthorizationService():this(new AuthorizationRepository()) { }

        public AuthorizationService(AuthorizationRepository authorizeRepository)
        {
            repository = authorizeRepository;
        }
        public IList<UserRoleModel> GetAllUserRole()
        {
            return repository.GetAllUserRole();
        }
    }
}
