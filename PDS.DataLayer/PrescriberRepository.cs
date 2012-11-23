using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.DataLayer
{
    public class PrescriberRepository
    {
        List<Prescriber> _prescribers = new List<Prescriber>() {
                                               new Prescriber{ Id = 300000, FirstName="George", LastName = "Peter", DEA="AB123123123", NPI="98988989"},
                                               new Prescriber{ Id = 300001,FirstName="George", LastName= "Alexander", DEA="BC9009099", NPI="9879889"}
                                                };
        public Prescriber Load(int prescriberId)
        {
            var prescriber = _prescribers.SingleOrDefault(p => p.Id == prescriberId);

            if (prescriber == null)
            {
                prescriber = new Prescriber { Id = prescriberId, FirstName = "Jon", LastName = "Doe", DEA = "333333333", NPI = "44444444444" };
            }
            return prescriber;
        }

        public List<Prescriber> SearchForPrescribers(string drugName, string NDC)
        {
            return _prescribers;
        }

    }
}
