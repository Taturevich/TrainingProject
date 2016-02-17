using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using BusinessLogic.Interfaces;
using Domain.Entities;
using Ninject;

namespace BusinessLogic
{
    public class CustomRoleProvider : RoleProvider
    {
        [Inject]
        public ILoginsRepository Logins { get; set; }
        public bool IsUserInRole(int userId, string roleName)
        {
            if (Logins.GetUserById(userId).RoleId.Equals(roleName))
                return true;
            return false;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            const int numberOfRoles = 1;
            string[] userRoles = new string[numberOfRoles];
            Login user = Logins.GetUserByName(username);
            userRoles[0] = user.RoleId;
            return userRoles;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
