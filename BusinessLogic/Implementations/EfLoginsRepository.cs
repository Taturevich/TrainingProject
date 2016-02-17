using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class EfLoginsRepository : ILoginsRepository
    {
        private EfDataBaseContext context;

        public EfLoginsRepository(EfDataBaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Login> GetAllUsers()
        {
            return context.Logins;
        }

        public Login GetUserById(int id)
        {
            return context.Logins.FirstOrDefault(x=>x.Id == id);
        }

        public Login GetUserByName(string userName)
        {
            return context.Logins.FirstOrDefault(x => x.Name == userName);
        }

        public MembershipUser GetMembershipUserByName(string userName)
        {
            Login login = context.Logins.FirstOrDefault(x => x.Name == userName);
            if (login != null)
            {
                return new MembershipUser(
                    Membership.Provider.Name,
                    login.Name,
                    login.Id,
                    login.Email,
                    "",
                    null,
                    true,
                    false,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now
                    );
            }
            return null;
        }

        public MembershipUser GetMembershipUserById(int userId)
        {
            Login login = context.Logins.FirstOrDefault(x => x.Id == userId);
            if (login != null)
            {
                return new MembershipUser(
                    Membership.Provider.Name,
                    login.Name,
                    login.Id,
                    login.Email,
                    "",
                    null,
                    true,
                    false,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now
                    );
            }
            return null;
        }



        public string GetUserNameByEmail(string email)
        {
            Login login = context.Logins.FirstOrDefault(x => x.Email == email);
            return login != null ? login.Name : "";
        }

        public void CreateUser(string userName, string password, string email, string phone, string roleId)
        {
            Login login = new Login
            {
                Name = userName,
                Password = password,
                Email = email,
                Phone = phone,
                RoleId = roleId
            };
            SaveUser(login);
        }

        public bool ValidateUser(string userName, string password)
        {
            Login login = context.Logins.FirstOrDefault(x => x.Name == userName);
            if (login != null && login.Password == password)
                return true;
            return false;
        }

        public void SaveUser(Login user)
        {
            if (user.Id == 0)
                context.Logins.Add(user);
            else
                context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
