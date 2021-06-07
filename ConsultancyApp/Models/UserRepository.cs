using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultancyApp.Models
{
    public class UserRepository : IDisposable
    {
        UserSecurity userSecurity = new UserSecurity();

        public UsersSecurity ValidateUser(string username, string password)
        {
            return userSecurity.UsersSecurities.FirstOrDefault(user =>
            user.Name.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Password == password);
        }
        public void Dispose()
        {
            userSecurity.Dispose();
        }
    }
}