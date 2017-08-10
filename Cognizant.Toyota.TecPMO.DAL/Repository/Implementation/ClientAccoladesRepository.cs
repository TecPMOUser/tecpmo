using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Implementation
{
    public class ClientAccoladesRepository: Repository, IClientAccoladesRepository
    {
        public IList<ClientAccolades> GetAllAccolades()
        {
            return GetAll<ClientAccolades>().OrderByDescending(x=>x.Date).ToList();
        }

        public int SaveAccolades(List<ClientAccolades> accolades)
        {
            int count = 0;
            try
            {
                AddRange(accolades);
                count = Save();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return count;


        }
        public int RemoveAccolades(ClientAccolades accolades)
        {
            try
            {
                int result = 0;
                if (accolades != null)
                {
                    var id = GetAll<ClientAccolades>().Where(x => x.ID == accolades.ID).FirstOrDefault();
                    if (id != null)
                    {
                        Delete(id);
                        result = Save();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
