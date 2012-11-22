using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.UI
{
    public class ClientContext
    {
        public User LoggedInUser { get; set; }
        public Role UserRole { get; set; }


    }

}
