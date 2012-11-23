using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;
using PDS.DataLayer;

namespace PDS.BusinessLayer
{
    public class FillManager
    {
        public Fill Create(Fill fill)
        {
            return new FillRepository().Create(fill);
        }

        public Fill Load(int fillId)
        {
            return new Fill();
        }


        public void Submit(Fill fill)
        {
            //Process Submit button
            var queueState = fill.QueueState;


            // Process Adjudication
            if (!fill.IsAdjudicated && !fill.Prescription.Patient.IsBillingMethodCash)
            {
                fill.QueueState = QueueStates.ThirdPartyRejects;
            }
            else
            {
                fill.IsAdjudicated = true;
            }

            if (fill.IsAdjudicated)
            {
                if (fill.Prescription.Product.DrugClass > 0)
                {
                    fill.QueueState = QueueStates.DUE;
                }
                else
                {
                    fill.IsDUEApproved = true;
                    fill.QueueState = QueueStates.PrintLabel;
                }
            }
            new FillRepository().Update(fill);
            

        }

        public void ReSubmit(Fill fill)
        {
            fill.IsAdjudicated = true;
            Submit(fill);
             
        }

        public void ApproveDUE(Fill fill)
        {
            fill.IsDUEApproved = true;
            fill.QueueState = QueueStates.PrintLabel;
            new FillRepository().Update(fill);
        }

        public void PerformRPHVerificaiton(Fill fill)
        {
            fill.IsRPHApproved = true;
            fill.QueueState = QueueStates.WillCall;
            new FillRepository().Update(fill);
        }

        public void PrintLabel(Fill fill)
        {
            fill.IsPrintLabelCompleted = true;
            fill.QueueState = QueueStates.RPHVerificaiton;
            new FillRepository().Update(fill);
        }

        public void Sell(Fill fill)
        {
            fill.IsSold = true;
            fill.QueueState = QueueStates.Sold;
            new FillRepository().Update(fill);
        }
    }
}
