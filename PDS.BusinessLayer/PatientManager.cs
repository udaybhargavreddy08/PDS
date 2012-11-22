using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;
using PDS.DataLayer;

namespace PDS.BusinessLayer
{
    public class PatientManager
    {
        public Patient Load(int id)
        {
            //Load patinet and send 
            return new Patient();
        }

        public void Save(Patient patient)
        {
            new PatientRepository().SavePatient(patient);
        }
        
      
        
    }
}
