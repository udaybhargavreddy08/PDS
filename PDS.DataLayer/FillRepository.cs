using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.DataLayer
{
    public class FillRepository
    {
            public void Create(Fill fill)
            {
                using (var context = new PDSEntities())
                {
                    PDSFill pdsFill = new PDSFill();
                    MapFilltoPDSFill(fill, pdsFill);

                    context.AddToPDSFills(pdsFill);
                    context.SaveChanges();
                }
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
                        MapPDSFilltoFill(pdsFill, fill);
                    }
                    context.SaveChanges();
                }
                return fill;
            }
            
        
    }
}
