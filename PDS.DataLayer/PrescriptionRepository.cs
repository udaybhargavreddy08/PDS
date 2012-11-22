﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.DataLayer
{
    public class PrescriptionRepository
    {
        public void Save(Prescription prescription)
        {
            using (var context = new PDSEntities())
            {
                PDSRx pdsRx = new PDSRx();
                MapParescriptiontoPDSRx(prescription, pdsRx);

                context.AddToPDSRxes(pdsRx);
                context.SaveChanges();
            }
        }

        private void MapParescriptiontoPDSRx(Prescription prescription, PDSRx pdsRx)
        {
            pdsRx.SIG = prescription.SIG;
            pdsRx.PatientID = prescription.Patient.Id;
            pdsRx.PrescriberID = prescription.Prescriber.Id;
            pdsRx.ProductID = prescription.Product.Id;
            pdsRx.RefillsAllowed = prescription.RefillsAllowed;
            pdsRx.WrittenDate = prescription.WrittenDate;            
        }

        public Prescription Load(int rxId)
        {
            Prescription prescription = new Prescription();
            using (var context = new PDSEntities())
            {
                PDSRx pdsRx = new PDSRx();
                MapPDSRxToPrescription(pdsRx,prescription);               
            }

            return prescription;
        }

        private void MapPDSRxToPrescription(PDSRx pdsRx, Prescription prescription)
        {
            prescription.Id = pdsRx.ID;
            prescription.Patient = new Patient { Id = pdsRx.ID };
            prescription.Prescriber = new Prescriber { Id = pdsRx.ID };
            prescription.Product = new Product { Id = pdsRx.ID };
            prescription.SIG = pdsRx.SIG;
            prescription.WrittenDate = pdsRx.WrittenDate.HasValue ? pdsRx.WrittenDate.Value : DateTime.Now;
            prescription.RefillsAllowed = pdsRx.RefillsAllowed;
        }
    }

    
}