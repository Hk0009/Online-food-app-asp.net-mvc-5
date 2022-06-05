using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Prectice1.Models;
namespace Prectice1
{
    public class webRoleProvider : RoleProvider
    {
        private readonly foodieEntities1 _roleContext;
        public webRoleProvider()
        {
            _roleContext=new foodieEntities1(); 
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var rolesResult=(from user in _roleContext.Logins
                            join role in _roleContext.roles on user.UserId equals role.UserId
                            where user.UserName==username
                            select role.Role1).ToArray();

            return rolesResult;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}