using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.DataLayer
{
    public class PrescriptionRepository
    {
        public Prescription Create(Prescription prescription)
        {
             PDSRx pdsRx = null;
            using (var context = new PDSEntities())
            {
                pdsRx = new PDSRx();
                MapParescriptiontoPDSRx(prescription, pdsRx);

                context.AddToPDSRxes(pdsRx);
                context.SaveChanges();
            }

            if(pdsRx != null)
            {
            prescription.Id = pdsRx.ID;
            }
            return prescription;
        }

        private void MapParescriptiontoPDSRx(Prescription prescription, PDSRx pdsRx)
        {
            pdsRx.SIG = prescription.SIG;
            pdsRx.PatientID = prescription.Patient.Id;
            pdsRx.PrescriberID = prescription.Prescriber.Id;
            pdsRx.ProductID = prescription.Product.Id;
            pdsRx.RefillsAllowed = prescription.RefillsAllowed;
            pdsRx.WrittenDate = prescription.WrittenDate;
            pdsRx.ExpirationDate = prescription.ExpirationDate;
        }

        public Prescription Load(int rxId)
        {
            Prescription prescription = new Prescription();
            using (var context = new PDSEntities())
            {

                PDSRx pdsRx = context.PDSRxes.SingleOrDefault(p=>p.ID == rxId);
                MapPDSRxToPrescription(pdsRx,prescription);               
            }

            prescription.Patient = new PatientRepository().Load(prescription.Patient.Id);
            prescription.Product = new ProductRepository().Load(prescription.Product.Id);
            prescription.Prescriber = new PrescriberRepository().Load(prescription.Prescriber.Id);

            return prescription;
        }

        private void MapPDSRxToPrescription(PDSRx pdsRx, Prescription prescription)
        {
            prescription.Id = pdsRx.ID;
            prescription.Patient = new Patient { Id = pdsRx.PatientID};
            prescription.Prescriber = new Prescriber { Id = pdsRx.PrescriberID};
            prescription.Product = new Product { Id = pdsRx.ProductID };
            prescription.SIG = pdsRx.SIG;
            prescription.WrittenDate = pdsRx.WrittenDate.HasValue ? pdsRx.WrittenDate.Value : DateTime.Now;
            prescription.RefillsAllowed = pdsRx.RefillsAllowed;
        }
    }

    
}
