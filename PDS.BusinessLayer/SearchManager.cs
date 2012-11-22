using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;
using PDS.DataLayer;

namespace PDS.BusinessLayer
{
    public class SearchManager
    {
        public List<Patient> SearchPatients(string firstName, string lastName, string phoneNumber)
        {
            return new PatientRepository().SearchPatients(firstName, lastName, phoneNumber);
        }
    }
}
