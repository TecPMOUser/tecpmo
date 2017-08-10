using Cognizant.Toyota.TecPMO.Core.Model;
using Cognizant.Toyota.TecPMO.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.Toyota.TecPMO.DAL.Repository.Implementation
{
    public class AuthorizationRepository : Repository, IAuthorizationRepository
    {
        List<User> userList = new List<User>();
        List<Role> roleList = new List<Role>();
        List<UserRoleMapping> userRoleMappingList = new List<UserRoleMapping>();
        List<Authorization> authorizationList = new List<Authorization>();
        public AuthorizationRepository()
        {
            userList = GetAll<User>().ToList();
            roleList = GetAll<Role>().ToList();
            userRoleMappingList = GetAll<UserRoleMapping>().ToList();
            authorizationList = GetAll<Authorization>().ToList();
        }
        public IList<UserRoleModel> GetAllUserRole()
        {
            List<UserRoleModel> usermodel = (from t1 in authorizationList
                     join t2 in roleList
                     on t1.Role equals t2.ID
                     join t3 in userRoleMappingList
                     on t2.ID equals t3.RoleID
                     join t4 in userList
                     on t3.UserID equals t4.ID
                     where t1.IsActive == true && t2.IsActive == true && t3.IsActive == true && t4.IsActive == true
                     select new UserRoleModel()
                     {
                         Controller = t1.Controller,
                         Action = t1.Action,
                         RoleName = t2.RoleName,
                         UserName = t4.UserName
                     }).ToList();
            return usermodel;
        }
    }

}
