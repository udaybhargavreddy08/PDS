using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.DataLayer
{
    public class FillRepository
    {
        public Fill Create(Fill fill)
            {
                PDSFill pdsFill = null;
                using (var context = new PDSEntities())
                {
                    pdsFill = new PDSFill();
                    MapFilltoPDSFill(fill, pdsFill);

                    context.AddToPDSFills(pdsFill);
                    context.SaveChanges();
                }

                if (pdsFill != null)
                {
                    fill.Id = pdsFill.ID;
                }
                return fill;
            }

            private void MapFilltoPDSFill(Fill fill, PDSFill pdsFill)
            {
                pdsFill.RxID = fill.Prescription.Id;
                pdsFill.DispensedQty = fill.DispensedQty;
                pdsFill.DispensedDate = fill.DispensedDate;
                pdsFill.IsAdjudicated = fill.IsAdjudicated;
                pdsFill.IsDueApproved = fill.IsDUEApproved;
                pdsFill.IsLabelPrinted = fill.IsPrintLabelCompleted;
                pdsFill.IsRPHVerified = fill.IsRPHApproved;
                pdsFill.WrittenQty = fill.WrittenQty;
                pdsFill.DispensedQty = fill.DispensedQty;
                pdsFill.IsSold = fill.IsSold;
                pdsFill.State = (int)fill.QueueState;               

            }

            public Fill Load(int fillId)
            {
                Fill fill = new Fill { Id = fillId };
                PDSFill pdsFill = null;
                using (var context = new PDSEntities())
                {
                   pdsFill = context.PDSFills.SingleOrDefault(p => p.ID == fillId);
                   if (pdsFill != null)
                   {
                       MapPDSFilltoFill( pdsFill,fill);
                   }
                }

                if(pdsFill != null)
                {
                    fill.Prescription = new PrescriptionRepository().Load(pdsFill.RxID);
                }

                return fill;
            }

            private void MapPDSFilltoFill(PDSFill pdsFill, Fill fill)
            {
                fill.Id = pdsFill.ID;
                try
                {
                    fill.Prescription = new PrescriptionRepository().Load(pdsFill.RxID);
                }
                catch
                {
                
                }
                fill.DispensedQty = pdsFill.DispensedQty.Value;
                fill.DispensedDate = pdsFill.DispensedDate.Value;
                fill.IsAdjudicated = pdsFill.IsAdjudicated;
                fill.IsDUEApproved = pdsFill.IsDueApproved;
                fill.IsPrintLabelCompleted = pdsFill.IsLabelPrinted;
                fill.IsRPHApproved = pdsFill.IsRPHVerified;
                fill.WrittenQty = pdsFill.WrittenQty.Value;
                fill.DispensedQty = pdsFill.DispensedQty.Value;
                fill.IsSold = pdsFill.IsSold;
                fill.QueueState = (QueueStates)Enum.ToObject(typeof(QueueStates), pdsFill.State.Value); 
            }


            public Fill Update(Fill fill)
            {
                
                using (var context = new PDSEntities())
                {
                    var pdsFill = context.PDSFills.SingleOrDefault(p => p.ID == fill.Id);
                    if (pdsFill != null)
                    {
                        MapFilltoPDSFill(fill,pdsFill);
                    }
                    context.SaveChanges();
                }
                return fill;
            }


            public QueueSnapshot GetQueueSnapShot(int queueId)
            {
                QueueSnapshot snapShot = new QueueSnapshot();

                List<PDSFill> selectedPDSFillList = new List<PDSFill>();


                 var pdsQueues = new List<PDSQueue>()
                            {
                                new PDSQueue { StateId = (int)QueueStates.DUE, Name="DUE", Code="DUE"},
                                new PDSQueue { StateId = (int)QueueStates.ThirdPartyRejects, Name="3RD PARTY REJECTS", Code="MAR"},
                                new PDSQueue { StateId = (int)QueueStates.PrintLabel, Name="PRINT LABEL", Code="PLABEL"},
                                new PDSQueue { StateId = (int)QueueStates.RPHVerificaiton, Name="RPH VERIFICATION", Code="RPH"},
                                new PDSQueue { StateId = (int)QueueStates.WillCall, Name="WILL CALL",  Code="WILLCALL"}
                            };

                 using (var context = new PDSEntities())
                 {
                     var groupedFills = context.PDSFills.GroupBy(p => p.State);

                     foreach (var fillGroup in groupedFills)
                     {
                         int stateId = fillGroup.Key.Value;

                         if (pdsQueues.Count(p => p.StateId == stateId) > 0)
                         {
                             pdsQueues.Single(p => p.StateId == stateId).Count = fillGroup.Count();
                         }
                         if (fillGroup.Key.Value == queueId)
                         {
                             selectedPDSFillList = fillGroup.ToList();
                         }
                     }
                 }

                List<Fill> selectedFills = new List<Fill>();
                foreach (var pdsFill in selectedPDSFillList)
                {
                    var fill = new Fill();
                    MapPDSFilltoFill(pdsFill, fill);
                    selectedFills.Add(fill);

                }

                snapShot.Queues = pdsQueues;
                snapShot.SelectedQueueFills = selectedFills;

                return snapShot;

            }
        
    }
}
