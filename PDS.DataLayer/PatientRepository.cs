using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.DataLayer
{
    public class PatientRepository
    {

       public void SavePatient(Patient patient)
        {
            using (var context = new PDSEntities())
            {
                PDSPatient pdsPatient = new PDSPatient();

                MapPatientToPDSPatient(patient, pdsPatient);
        
                context.AddToPDSPatients(pdsPatient);
                context.SaveChanges();
            }
        }

       public Patient Load( int patientId)
       {
           Patient patient  = new Patient { Id = patientId };

           using (var context = new PDSEntities())
           {

               var pdsPatient = context.PDSPatients.SingleOrDefault(p => p.ID == patientId);

               if (pdsPatient != null)
               {
                   MapPDSPatientToPatient(patient, pdsPatient);
               }
           }

           return patient;
       }
      

       public List<Patient> SearchPatients(string fisrtName, string lastName, string phoneNumber)
       {
           List<Patient> patients = new List<Patient>();
           List<PDSPatient> pdsPatients = new List<PDSPatient>();
           using (var context = new PDSEntities())
           {
               pdsPatients = context.PDSPatients.Where(p => p.FirstName.Equals(fisrtName, StringComparison.InvariantCultureIgnoreCase) ||
                                                       p.LastName.Equals(lastName,StringComparison.InvariantCultureIgnoreCase) ||
                                                        p.Phone.Equals(phoneNumber, StringComparison.InvariantCultureIgnoreCase)
                                                      ).ToList();
           }

           foreach (var p in pdsPatients)
           {
               Patient patient = new Patient();
               MapPDSPatientToPatient(patient, p);
               patients.Add(patient);
           }

           return patients;
       }

       public void UpdatePatient(Patient patient)
       {
           using (var context = new PDSEntities())
           {
               var pdsPatient = context.PDSPatients.FirstOrDefault(P => P.ID == patient.Id);

               if (pdsPatient != null)
               {
                   MapPatientToPDSPatient(patient, pdsPatient);
                   context.SaveChanges();
               }
           }
       }

       private static void MapPatientToPDSPatient(Patient patient, PDSPatient pdsPatient)
       {
           pdsPatient.FirstName = patient.FirstName;
           pdsPatient.LastName = patient.LastName;
           pdsPatient.DOB = patient.DOB;
           pdsPatient.Phone = patient.PhoneNumber;
           pdsPatient.IsBillingMethodCash = patient.IsBillingMethodCash;
           pdsPatient.MiddleName = patient.MiddleName;

           if (patient.Address != null)
           {
               pdsPatient.Address1 = patient.Address.Address1;
               pdsPatient.Address2 = patient.Address.Address2;
               pdsPatient.City = patient.Address.City;
               pdsPatient.State = patient.Address.State;
               pdsPatient.ZIP = patient.Address.ZipCode;
           }

       }


       private static void MapPDSPatientToPatient(Patient patient, PDSPatient pdsPatient)
       {
           patient.FirstName = pdsPatient.FirstName;
           patient.LastName = pdsPatient.LastName;
           patient.DOB = pdsPatient.DOB;
           patient.PhoneNumber = pdsPatient.Phone;
           patient.IsBillingMethodCash = pdsPatient.IsBillingMethodCash.HasValue ? pdsPatient.IsBillingMethodCash.Value : false;
           patient.MiddleName = pdsPatient.MiddleName;


           patient.Address = new Address
           {
               Address1 = pdsPatient.Address1,
               Address2 = pdsPatient.Address2,
               City = pdsPatient.City,
               State = pdsPatient.State,
               ZipCode = pdsPatient.ZIP
           };
       }

    }
}
