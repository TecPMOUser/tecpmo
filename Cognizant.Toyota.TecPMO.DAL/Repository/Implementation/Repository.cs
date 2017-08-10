using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository
{
    public class Repository:IRepository,IDisposable
    {

        protected readonly TecPMOContext context = new TecPMOContext();
        private bool disposed;

        public IQueryable<T> GetSingle<T>(Expression<Func<T, bool>> Condition) where T : class
        {
            IQueryable<T> Result = context.Set<T>().Where(Condition);
            return Result;
        }

        public virtual void Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
        }
        public virtual void AddRange<T>(List<T> entity) where T : class
        {
            context.Set<T>().AddRange(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> GetAll<T>() where T : class
        {
            IQueryable<T> Result = context.Set<T>();
            return Result;
        }
        public virtual int Save()
        {
            return context.SaveChanges();
        }

        public virtual void Update<T>(T entity) where T : class
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> CallStoredProcedure<T>(string spName, params object[] param) where T : class
        {
            context.Database.CommandTimeout = 300;
            return context.Database.SqlQuery<T>(spName, param).AsQueryable<T>();
        }

        public virtual void ExecuteSQLCommand(string sqlCommand, ref SqlParameter[] param, int timeout = 30)
        {
            context.Database.CommandTimeout = timeout;
            context.Database.ExecuteSqlCommand(sqlCommand, param);
        }


        /// <summary>
        /// Calls a given Sql function and returns a singular value
        /// </summary>
        /// <param name="db">Current DbContext instance</param>
        /// <typeparam name="T">CLR Type</typeparam>
        /// <param name="sql">Sql function</param>
        /// <param name="parameters">Sql function parameters</param>
        /// <param name="schema">Owning schema</param>
        /// <returns>Value of T</returns>
        public T SqlScalarResult<T>(DbContext db,
                                    string sql,
                                    SqlParameter[] parameters,
                                    string schema = "dbo")
        {

            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentException("function");
            }

            if (parameters == null || parameters.Length == 0)
            {
                throw new ArgumentException("parameters");
            }

            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentException("schema");
            }

            string cmdText = "";
             //   @"SELECT {schema}.{sql}({string.Join(",",parameters.Select(p => "@" + p.ParameterName).ToList())});";

            return db.Database.SqlQuery<T>(cmdText, parameters).FirstOrDefault();

        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }
    }
}
