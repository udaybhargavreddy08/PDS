using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;
using PDS.DataLayer;

namespace PDS.BusinessLayer
{
    public class PrescriberManager
    {
        public Prescriber Load(int prescriberId)
        {
            return new PrescriberRepository().Load(prescriberId);
        }

        public List<Prescriber> SearchForPrescriber(string firstName, string lastName)
        {
            return new PrescriberRepository().SearchForPrescribers(firstName, lastName);
        }
    }
}
