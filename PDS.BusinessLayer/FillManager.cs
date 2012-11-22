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
        public void Create(Fill fill)
        {
            new FillRepository().Create(fill);
        }

        public Fill Load(int fillId)
        {
            return new Fill();
        }


        public void Submit(Fill fill)
        {

        }

        public void ReSubmit(Fill fill)
        {

        }

        public void ApproveDUE(Fill fill)
        {
        }

        public void PerformRPHVerificaiton(Fill fill)
        {

        }

        public void PrintLabel(Fill fill)
        {

        }

        public void Sell(Fill fill)
        {

        }
    }
}
