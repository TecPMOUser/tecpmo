using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Interface
{
   public interface IRepository
    {

        /// <summary>
        /// Get a selected extiry by the object primary key ID
        /// </summary>
        /// <param name="id">Primary key ID</param>
        IQueryable<T> GetSingle<T>(Expression<Func<T, bool>> Condition) where T : class;

        /// <summary>
        /// Add entity to the repository
        /// </summary>
        /// <param name="entity">the entity to add</param>
        /// <returns>The added entity</returns>
        void Add<T>(T entity) where T : class;

        /// <summary>
        /// Mark entity to be deleted within the repository
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// Updates entity within the the repository
        /// </summary>
        /// <param name="entity">the entity to update</param>
        /// <returns>The updates entity</returns>
        void Update<T>(T entity) where T : class;

        /// <summary>
        /// Get all the element of this repository
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll<T>() where T : class;

        /// <summary>
        /// To save the context changes
        /// </summary>
        int Save();
    }
}
