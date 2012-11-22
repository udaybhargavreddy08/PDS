using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;
using PDS.DataLayer;

namespace PDS.BusinessLayer
{
    public class PrescriptionManager
    {
        public Prescription Create(Prescription prescription)
        {
            return new PrescriptionRepository().Create(prescription);            
        }

      

        public Prescription Load(int rxId)
        {
            return new Prescription();
        }


    }
}
