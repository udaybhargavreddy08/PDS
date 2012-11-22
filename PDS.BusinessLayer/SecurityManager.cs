using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.BusinessLayer
{
    public class SecurityManager
    {

        public bool Authenticate(string userName, string password, out User user)
        {
            user = new User();
            return true;
        }

        public Role GetUserRole(string userId)
        {
            return new Role();
        }

    }
}
